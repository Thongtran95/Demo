using System.Collections.Generic;
using DemoRepository.Data.Model;

namespace DemoRepository.ViewModel
{
    public class BookViewModel
    {
        
        public Book Book { get; set; }
        public IEnumerable<Author> Author { get; set; }
    }
}