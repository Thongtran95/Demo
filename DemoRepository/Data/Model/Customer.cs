using System.ComponentModel.DataAnnotations;

namespace DemoRepository.Data.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        
        [Required,MinLength(3),MaxLength(50)]
        public string Name { get; set; }
        
    }
}