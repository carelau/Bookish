using System;
using Microsoft.EntityFrameworkCore;
using Bookish.Models;


namespace Bookish.Database
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=LibraryDB;Trusted_Connection=True;");
        }
    }
}

