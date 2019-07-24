using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoRepository.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }
        
        [Required(ErrorMessage = "Email is requaired")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Please enter UserName")]
        public string UserName { get; set; }
        
        public List<string> Users { get; set; }
    }
}