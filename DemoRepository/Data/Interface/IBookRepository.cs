using System;
using System.Collections.Generic;
using System.Linq;
using DemoRepository.Data.Model;

namespace DemoRepository.Data.Interface
{
    public interface IBookRepository :IRepository<Book>
    {
        IEnumerable<Book> GetAllWithAuthor();
        IEnumerable<Book> FindWithAuthor(Func<Book, bool> predicate);
        IEnumerable<Book> FindWithAuthorAndBorrower(Func<Book, bool> predicate);
        IOrderedEnumerable<Book> FindWithAuthor();
        IEnumerable<Book> SearchBook(string search);
    } 
}