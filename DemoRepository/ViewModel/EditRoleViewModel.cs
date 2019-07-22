using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoRepository.ViewModel
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }
        
        [Required(ErrorMessage = "Role Name is requaired")]
        public string RoleName { get; set; }
        
        public List<string> Users { get; set; }
    }
}