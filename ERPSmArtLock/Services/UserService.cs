using ERPSmArtLock.Data;
using ERPSmArtLock.Entities;
using ERPSmArtLock.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Generators;

namespace ERPSmArtLock.Services
{
    public interface IUserService
    {
        Users Authenticate ( string username, string password );
        IEnumerable<Users> GetAll ( );
        Users GetById ( int id );
        Users Create ( Users user, string password );
        Users Update ( Users user, string password = null );
        void Delete ( int id );
    }
    public class UserService : IUserService
    {
        private readonly ERPContext _context;
        private readonly AppSettings _appSettings;

        public UserService ( ERPContext context, IOptions<AppSettings> appSettings )
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
       public Users Authenticate ( string username, string password )
        {
            
            var users = _context.Set<Users>().ToList();

            if (string.IsNullOrEmpty ( username ) || string.IsNullOrEmpty ( password ))
                return null;

            //var user = _context.Users.SingleOrDefault ( x => x.userName == username && x.pwd == password );
            var user = users.SingleOrDefault(x => x.userName == username);

            bool passwordValid = BCrypt.Net.BCrypt.Verify(password,user.pwd);
            if (passwordValid == true)
            {
                Debug.WriteLine(password + " is valid.");
            }
            else
            {
                Debug.WriteLine(password + " is NOT valid.");
                user = null;
            }

            // check if username exists
            if (user == null)
                return null;

            // authentication successful so generate JWT Token
            var tokenHandler = new JwtSecurityTokenHandler ();
            var key = Encoding.ASCII.GetBytes ( _appSettings.Secret );
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.ImeiNo = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
            //return null;
        }

        public IEnumerable<Users> GetAll()
        {
            return _context.Users.WithoutPasswords();
        }

        public Users GetById ( int id )
        {
            return _context.User.Find ( id );
        }

        public Users Create ( Users user, string password )
        {
            // validation
            if(string.IsNullOrWhiteSpace ( password ))
                throw new AppException ( "Password is required" );

            if(_context.Users.Any ( x => x.userName == user.userName ))
                throw new AppException ( "Username \"" + user.userName + "\" is already taken" );

            _context.Users.Add ( user );
            _context.SaveChanges ();

            return user;
        }


       public Users Update ( Users userParam, string password = null )
        {
            var user = _context.Users.Find ( userParam.Id );

            if(user == null)
                throw new AppException ( "User not found" );

            // update username if it has changed
            if(!string.IsNullOrWhiteSpace ( userParam.userName ) && userParam.userName != user.userName)
            {
                // throw error if the new username is already taken
                if(_context.Users.Any ( x => x.userName == userParam.userName ))
                    throw new AppException ( "Username " + userParam.userName + " is already taken" );

                user.userName = userParam.userName;
                user.Role = userParam.Role;
            }

            // update user properties if provided
            if(!string.IsNullOrWhiteSpace ( userParam.Address ))
                user.Address = userParam.Address;

            if(!string.IsNullOrWhiteSpace ( userParam.Email ))
                user.Email = userParam.Email;

            _context.Users.Update ( user );
            _context.SaveChanges ();
            return user;
        }

        public void Delete ( int id )
        {
            var user = _context.Users.Find ( id );
            if(user != null)
            {
                _context.Users.Remove ( user );
                _context.SaveChanges ();
            }
        }

    }
}
