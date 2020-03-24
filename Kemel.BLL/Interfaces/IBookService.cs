using System.Collections.Generic;
using Kemel.BLL.Models;

namespace Kemel.BLL.Interfaces
{
    public interface IBookService : IService
    {
        IEnumerable<BookBusinessModel> BookList();
        ExecuteResult AddBook(BookBusinessModel model);
        ExecuteResult UpdateBook(BookBusinessModel model);
        ExecuteResult DeleteBook(int id);
        BookBusinessModel FindById(int id);
    }
}
