using System.ComponentModel.DataAnnotations;

namespace DemoRepository.Data.Model
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        
        public string Role { get; set; }
    }
}