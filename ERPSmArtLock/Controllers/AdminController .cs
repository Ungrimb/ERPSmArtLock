using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ERPSmArtLock.Models;
using Microsoft.AspNetCore.Cors;
using ERPSmArtLock.Data.Repositories;

namespace ERPSmArtLock.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : GenericController<Admin, AdminRepository>
    {
        private readonly AdminRepository _repository;

        public AdminController(AdminRepository repository) : base(repository)
        {
            _repository = repository;
        }
        // POST: api/Admin
        [HttpPost("admin")]
        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        {
        var newAdmin = new Admin
            {
                Id = admin.Id,
                Name = admin.Name,
                Image = admin.Image,
                Email = admin.Email,
                Password = admin.Password,
                Mobile = admin.Mobile,
                Address = admin.Address
        };

            return await _repository.Add(newAdmin);
        }

        [HttpPut("edit/{id}")]
        public async Task<ActionResult<Admin>> EditAdmin(Admin admin)
        {

            var adminEdited = await _repository.Get(admin.Id);

            adminEdited.Id = admin.Id;
            adminEdited.Name = admin.Name;
            adminEdited.Image = admin.Image;
            adminEdited.Email = admin.Email;
            adminEdited.Password = admin.Password;
            adminEdited.Mobile = admin.Mobile;
            adminEdited.Address = admin.Address;

            return await _repository.Update(adminEdited);

        }
        // DELETE: api/Admin/5
        [HttpDelete("{id}")]
        public Task<ActionResult<Admin>> DeleteAdmin(int id)
        {
            return _repository.DeleteAdmin(id);
        }
    }
}
