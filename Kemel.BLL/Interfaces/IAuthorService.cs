using System.Collections.Generic;
using Kemel.BLL.Models;

namespace Kemel.BLL.Interfaces
{
    public interface IAuthorService : IService
    {
        IEnumerable<AuthorBusinessModel> Authors();
        ExecuteResult AddAuthor(AuthorBusinessModel model);
        ExecuteResult UpdateAuthor(AuthorBusinessModel model);
        ExecuteResult DeleteAuthor(int id);
        AuthorBusinessModel FindById(int id);
    }
}
