using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bookstore.Data
{
    public class BookstoreContext : DbContext
    {
        //public BookstoreContext() : base("name=BookstoreContext") { }
        public BookstoreContext() : base("BookstoreDatabase")
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}