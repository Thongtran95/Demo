using System.ComponentModel.DataAnnotations;

namespace DemoRepository.ViewModel
{
    public class RegisterViewModel
    {
        
        public string Username { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Congirm Password")]
        [Compare("Password",
            ErrorMessage = "Password and congirmation password do not match")]
        public string ConfirmPassword { get; set; }
    }
}