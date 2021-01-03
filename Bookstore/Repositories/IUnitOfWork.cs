using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }
        IAuthorRepository Authors { get; }
        int Complete();
    }
}
