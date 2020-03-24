using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Kemel.BLL.Interfaces;
using Kemel.BLL.Models;
using Kemel.DAL.Entity;
using Kemel.DAL.Repository;

namespace Kemel.BLL.Services
{
    public class AuthorService : BaseService, IAuthorService
    {
        private readonly IRepository _repository;
        public AuthorService(IRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<AuthorBusinessModel> Authors()
        {
            var entities = _repository.All<Author>().ToList();
            return Mapper.Map<List<Author>, List<AuthorBusinessModel>>(entities);
        }

        public ExecuteResult AddAuthor(AuthorBusinessModel model)
        {
            return Execute(() =>
            {
                var res = Mapper.Map<Author>(model);
                _repository.Save(res);
                return ExecuteResult.Success();
            });
        }

        public ExecuteResult UpdateAuthor(AuthorBusinessModel model)
        {
            return Execute(() =>
            {
                var res = Mapper.Map<Author>(model);
                _repository.Save(res);
                return ExecuteResult.Success();
            });
        }

        public ExecuteResult DeleteAuthor(int id)
        {
            return Execute(() =>
            {
                _repository.Delete(_repository.GetById(typeof(Author), id));
                return ExecuteResult.Success();
            });
        }

        public AuthorBusinessModel FindById(int id)
        {
            return Mapper.Map<AuthorBusinessModel>(_repository.GetById(typeof(Author), id));
        }
    }
}
