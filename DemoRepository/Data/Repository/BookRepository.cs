using System;
using System.Collections.Generic;
using System.Linq;
using DemoRepository.Data.Interface;
using DemoRepository.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DemoRepository.Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private IBookRepository _bookRepositoryImplementation;

        public BookRepository(LibraryDbContext context) : base(context)
        {
        }

        public IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate)
        {
            return _context.Book
                .Include(a => a.Author)
                .Where(predicate);
        }

        public IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate)
        {
            return _context.Book
                .Include(a => a.Author)
                .Include(a => a.Borrower)
                .Where(predicate);
        }

        public IOrderedEnumerable<Book> FindWithAuthor()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> SearchBook(string search)
        {
            return _context.Book
                .Include(a=>a.Author)
                .Where(a => a.Title.Contains(search))
                .ToList();
        }

        public IEnumerable<Book> GetAllWithAuthor()
        {
            return _context.Book.Include(a => a.Author);
        }
    }

}