using System.Collections.Generic;
using DemoRepository.Data.Model;

namespace DemoRepository.ViewModel
{
    public class LendViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}