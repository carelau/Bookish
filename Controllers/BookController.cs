using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bookish.Models;
using Bookish.Database;
using Bookish.Services;

namespace Bookish.Controllers
{

    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly BookService _bookService;


        public BookController(ILogger<BookController> logger, BookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        public IActionResult Library()
        {
            return View(_bookService.GetBooks());
        }

        public IActionResult SearchBook(bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public IActionResult SingleBook(Book book)
        {
            Book searchedbook = _bookService.GetASingleBook(book.Id);
            if (searchedbook == null)
            {
                return RedirectToAction("SearchBook", new { isSuccess = true });
            }
            return View(searchedbook);
        }

        public IActionResult AddNewBook(bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public IActionResult AddBookToDatabase(Book book)
        {
            if (ModelState.IsValid)
            {
                int bookId = _bookService.CreateBook(book);

                if (bookId > 0)
                {
                    return RedirectToAction("AddNewBook", new { isSuccess = true });
                }
            }
            return View();
        }

        public IActionResult DeleteBook(bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public IActionResult DeleteBookInDatabase(Book book)

        {
            Book searchedbook = _bookService.GetASingleBook(book.Id);
            if (searchedbook == null)
            {
                return RedirectToAction("DeleteBook", new { isSuccess = true });
            }
            _bookService.DeleteBook(book);
            return View();

        }
    }
}

/*  public IActionResult Index()
  {

        List<Book> myBookList = new List<Book>()
       {
          new Book {Id= 1, Title = "Klara and the Sun", Author = "Kazuo Ishiguro"},
          new Book {Id= 2, Title = "Effortless", Author = "Greg McKeown"},
          new Book {Id= 3, Title = "Gold Diggers", Author = "Sanjena Sathian"},
       };

      return View(myBookList);
  }
  */


// [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
// public IActionResult Error()
// {
//     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
// }
/*
        private void AddBook()
        {
            using (var context = new LibraryContext())
            {
                var std = new Book()
                {
                    Title = "Klara and the Sun",
                    Author = "Kazuo Ishiguro"
                };

                context.Books.Add(std);

                // or
                // context.Add<Student>(std);

                context.SaveChanges();
            }
            */

