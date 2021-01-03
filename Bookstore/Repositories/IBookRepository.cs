using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetBooksWithAuthor();
        Book GetBookWithAuthor(int? id);
        IEnumerable<Book> GetAllBooksByTitleOrAuthorName(string search);
        IEnumerable<Book> OrderBooksByCount();
    }
}
