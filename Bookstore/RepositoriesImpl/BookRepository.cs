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
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookstoreContext context) : base(context) { }

        public IEnumerable<Book> GetAllBooksByTitleOrAuthorName(string search)
        {
            return BookstoreContext.Books.Include(b => b.Author).Where(book => book.Title.ToLower().Contains(search.ToLower()) || 
                book.Author.Name.ToLower().Contains(search.ToLower()));
        }

        public IEnumerable<Book> OrderBooksByCount()
        {
            return BookstoreContext.Books.OrderByDescending(book => book.Count).ToList();
        }

        public IEnumerable<Book> GetBooksWithAuthor()
        {
            return BookstoreContext.Books.Include(b => b.Author).ToList();
        }

        public Book GetBookWithAuthor(int? id)
        {
            return BookstoreContext.Books.Include(b => b.Author).First(b => b.Id == id);
        }

        public BookstoreContext BookstoreContext
        {
            get { return context as BookstoreContext; }
        }
    }
}