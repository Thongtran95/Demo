using System.Collections.Generic;
using System.Linq;
using DemoRepository.Data.Interface;
using DemoRepository.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoRepository.Data.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context) : base(context)
        {

        }

        public IEnumerable<Author> GetAllWithBooks()
        {
            return _context.Author.Include(a => a.Books);
        }

        public Author GetWithBooks(int id)
        {
            return _context.Author
                .Where(a => a.AuthorId == id)
                .Include(a => a.Books)
                .FirstOrDefault();
        }
    }
}