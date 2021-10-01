using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bookish.Models;
using Bookish.Database;

namespace Bookish.Services
{

    public class BookService
    {
        private readonly LibraryContext _libraryContext;

        public BookService(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        public List<Book> GetBooks()
        {
            List<Book> Books = _libraryContext.Books.ToList();
            return Books;
        }

        public Book GetASingleBook(int bookId)
        {
            var book = _libraryContext.Books
                           .Where(b => b.Id == bookId)
                           .FirstOrDefault();
            return book;
        }

        public int CreateBook(Book model)
        {
            // var book = new Book()
            // {
            //     Title = model.Title,
            //     Author = model.Author
            // };
            _libraryContext.Books.Add(model);
            _libraryContext.SaveChanges();

            return model.Id;
        }

        public void DeleteBook(Book model)
        {

            using (var context = new LibraryContext())
            {
                context.Books.Remove(model);
                context.SaveChanges();
            }
            // _libraryContext.Books.Remove(model);
            //  _libraryContext.SaveChanges();

        }


    }
}
