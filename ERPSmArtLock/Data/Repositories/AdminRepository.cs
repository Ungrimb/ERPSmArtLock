using ERPSmArtLock.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSmArtLock.Data.Repositories
{
    public class AdminRepository : DataRepository<Admin, ERPContext>
    {

        private readonly ERPContext _context;
        public AdminRepository(ERPContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Admin>> GetAll()
        {
            return await _context.Admin
                .ToListAsync();
        }

        public override async Task<Admin> Get(int id)
        {
            return await _context.Admin
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Admin> AddAdmin(Admin admin)
        {

            var newAdmin = new Admin();

            newAdmin.Name = admin.Name;
            newAdmin.Image = admin.Image;
            newAdmin.Email = admin.Email;
            newAdmin.Password = admin.Password;
            newAdmin.Mobile = admin.Mobile;
            newAdmin.Address = admin.Address;
            _context.Set<Admin>().Add(newAdmin);
            await _context.SaveChangesAsync();

            return newAdmin;
        }
        public async Task<ActionResult<Admin>> DeleteAdmin([FromBody] int id)
        {
            var admin = await _context.Admin.FindAsync(id);

            _context.Admin.Remove(admin);
            await _context.SaveChangesAsync();

            return admin;
        }

    }
}
