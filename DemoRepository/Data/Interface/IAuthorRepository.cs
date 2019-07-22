using System.Collections.Generic;
using DemoRepository.Data.Model;

namespace DemoRepository.Data.Interface
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IEnumerable<Author> GetAllWithBooks();

        Author GetWithBooks(int id);
    }
}