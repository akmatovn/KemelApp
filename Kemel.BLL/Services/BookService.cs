using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Kemel.BLL.Interfaces;
using Kemel.BLL.Models;
using Kemel.DAL.Entity;
using Kemel.DAL.Repository;

namespace Kemel.BLL.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IRepository _repository;
        public BookService(IRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<BookBusinessModel> BookList()
        {
            var entities = _repository.All<Book>().ToList();
            return Mapper.Map<List<Book>, List<BookBusinessModel>>(entities);
        }

        public ExecuteResult AddBook(BookBusinessModel model)
        {
            return Execute(() =>
            {
                var all = _repository.All<Author>().ToList();
                var authors = all.Where(x => model.Authors.Any(c => c == x.Id)).ToList();
                var books = Mapper.Map<Book>(model);
                books.Authors = authors;
                _repository.Save(books);

                return ExecuteResult.Success();
            });
        }

        public ExecuteResult UpdateBook(BookBusinessModel model)
        {
            return Execute(() =>
            {
                var all = _repository.All<Author>().ToList();
                var authors = all.Where(x => model.Authors.Any(c => c == x.Id)).ToList();
                var res = Mapper.Map<Book>(model);
                res.Authors.Clear();
                res.Authors = authors;
                _repository.Save(res);

                return ExecuteResult.Success();
            });
        }

        public ExecuteResult DeleteBook(int id)
        {
            return Execute(() =>
            {
                _repository.Delete(_repository.GetById(typeof(Book), id));
                return ExecuteResult.Success();
            });
        }

        public BookBusinessModel FindById(int id)
        {
            return Mapper.Map<BookBusinessModel>(_repository.GetById(typeof(Book), id));
        }
    }
}
