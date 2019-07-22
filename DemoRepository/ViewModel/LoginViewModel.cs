using System.ComponentModel.DataAnnotations;

namespace DemoRepository.ViewModel
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}