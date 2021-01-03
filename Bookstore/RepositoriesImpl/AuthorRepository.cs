using Bookstore.Data;
using Bookstore.Models;
using Bookstore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Bookstore.RepositoriesImpl
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookstoreContext context) : base(context) { }

        public IEnumerable<Author> GetAuthorsWithBooks()
        {
            return BookstoreContext.Authors.Include(a => a.Books).ToList();
        }

        public Author GetAuthorWithBooks(int? id)
        {
            return BookstoreContext.Authors.Include(a => a.Books).First(a => a.Id == id);
        }

        public BookstoreContext BookstoreContext
        {
            get { return context as BookstoreContext; }
        }
    }
}