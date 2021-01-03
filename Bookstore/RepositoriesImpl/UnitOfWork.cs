using Bookstore.Data;
using Bookstore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookstore.RepositoriesImpl
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookstoreContext _context;
        

        public UnitOfWork(BookstoreContext context)
        {
            _context = context;
            Books = new BookRepository(_context);
            Authors = new AuthorRepository(_context);
        }

        public IBookRepository Books { get; private set; }
        public IAuthorRepository Authors { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}