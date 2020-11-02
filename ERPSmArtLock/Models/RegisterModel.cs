
using System.ComponentModel.DataAnnotations;


namespace ERPSmArtLock.Models
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Pwd { get; set; }
        public string Role { get; set; }
    }
}
