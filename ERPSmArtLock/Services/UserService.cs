using ERPSmArtLock.Data;
using ERPSmArtLock.Entities;
using ERPSmArtLock.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ERPSmArtLock.Services
{
    public interface IUserService
    {
        User Authenticate ( string username, string password );
        IEnumerable<User> GetAll ( );
        User GetById ( int id );
        User Create ( User user, string password );
        User Update ( User user, string password = null );
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
       public User Authenticate ( string username, string password )
        {

            if(string.IsNullOrEmpty ( username ) || string.IsNullOrEmpty ( password ))
                return null;

            var user = _context.Users.SingleOrDefault ( x => x.UserName == username && x.Pwd == password );

            // check if username exists
            if(user == null)
                return null;

            // authentication successful so generate JWT Token
            var tokenHandler = new JwtSecurityTokenHandler ();
            var key = Encoding.ASCII.GetBytes ( _appSettings.Secret );
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity ( new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays ( 7 ),
                SigningCredentials = new SigningCredentials ( new SymmetricSecurityKey ( key ), SecurityAlgorithms.HmacSha256Signature )
            };

            var token = tokenHandler.CreateToken ( tokenDescriptor ) ;
            user.ImeiNo = tokenHandler.WriteToken ( token );
        
            return user.WithoutPassword();
        }

        public IEnumerable<User> GetAll ( )
        {
            return _context.Users.WithoutPasswords();
        }

        public User GetById ( int id )
        {
            return _context.Users.Find ( id );
        }

        public User Create ( User user, string password )
        {
            // validation
            if(string.IsNullOrWhiteSpace ( password ))
                throw new AppException ( "Password is required" );

            if(_context.Users.Any ( x => x.UserName == user.UserName ))
                throw new AppException ( "Username \"" + user.UserName + "\" is already taken" );

            _context.Users.Add ( user );
            _context.SaveChanges ();

            return user;
        }


       public User Update ( User userParam, string password = null )
        {
            var user = _context.Users.Find ( userParam.Id );

            if(user == null)
                throw new AppException ( "User not found" );

            // update username if it has changed
            if(!string.IsNullOrWhiteSpace ( userParam.UserName ) && userParam.UserName != user.UserName)
            {
                // throw error if the new username is already taken
                if(_context.Users.Any ( x => x.UserName == userParam.UserName ))
                    throw new AppException ( "Username " + userParam.UserName + " is already taken" );

                user.UserName = userParam.UserName;
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
