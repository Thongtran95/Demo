using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DemoRepository.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using DemoRepository.Models;
using DemoRepository.ViewModel;

namespace DemoRepository.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICustomerRepository _customerRepository;
      
        public HomeController(IBookRepository bookRepository,
            IAuthorRepository authorRepository,
            ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            // create home view model
            var homeVM = new HomeViewModel()
            {
                AuthorCount = _authorRepository.Count(x => true),
                CustomerCount = _customerRepository.Count(x=>true),
                BookCount = _bookRepository.Count(x => true),
                LendBookCount= _bookRepository.Count(x => x.Borrower != null)
            };
            // call view
            return View(homeVM);
        }

      
       
    }
}