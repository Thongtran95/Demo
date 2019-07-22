using System;
using System.Collections.Generic;
using System.Linq;
using DemoRepository.Data.Interface;
using DemoRepository.Data.Model;
using DemoRepository.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoRepository.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookController(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        [Route("Book")]
        public IActionResult List(int? authorId, int? borrowerId, string sortOrder, string search = null)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var links = _bookRepository.GetAllWithAuthor();
            // Thứ tự sắp xếp theo thuộc tính LinkName
            switch (sortOrder)
            {
                // Nếu biến sortOrder sắp giảm thì sắp giảm theo LinkName
                case "name_desc":
                    links = links.OrderByDescending(s => s.BookId);
                    break;
      
                // Mặc định thì sẽ sắp tăng
                default:
                    links = links.OrderBy(s => s.BookId);
                    break;
            }
            if (!String.IsNullOrEmpty(search))
            {
                links = links.Where(a => a.Title.Contains(search));
              
                return View(links.ToList());
            }
            // 4. Trả kết quả về Views
            return View(links.ToList());
           
        }
        public IActionResult CheckBooks(IEnumerable<Book> books)
        {
            if (books.Count() == 0)
            {
                return View("Empty");
            }
            else
            {
                return View(books);
            }
        }

        public IActionResult Create()
        {
            var bookVM = new BookViewModel()
            {
                Author = _authorRepository.GetAll()
            };
            return View(bookVM);
        }

        [HttpPost]
        public IActionResult Create(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                bookViewModel.Author = _authorRepository.GetAll();
                return View(bookViewModel);
            }

            _bookRepository.Create(bookViewModel.Book);

            return RedirectToAction("List");
        }

        public IActionResult Update(int id)
        {
            var bookVM = new BookViewModel()
            {
                Book = _bookRepository.GetById(id),
                Author = _authorRepository.GetAll()
            };
            return View(bookVM);
        }

        [HttpPost]
        public IActionResult Update(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid)
            {
                bookViewModel.Author = _authorRepository.GetAll();
                return View(bookViewModel);
            }

            _bookRepository.Update(bookViewModel.Book);

            return RedirectToAction("List");
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var book = _bookRepository.GetById(id);

            _bookRepository.Delete(book);

            return RedirectToAction("List");
        }
    }
}