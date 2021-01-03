using Bookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IEnumerable<Author> GetAuthorsWithBooks();
        Author GetAuthorWithBooks(int? id);
    }
}
