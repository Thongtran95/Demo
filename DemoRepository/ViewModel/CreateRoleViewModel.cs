using System.ComponentModel.DataAnnotations;

namespace DemoRepository.ViewModel
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}