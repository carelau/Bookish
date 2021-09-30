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
            List<Book> Books =_libraryContext.Books.ToList();
            return Books;
        }

    }
}
