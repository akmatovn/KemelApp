using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Kemel.BLL.Interfaces;
using Kemel.BLL.Models;
using Kemel.DAL.Entity;
using Kemel.DAL.Repository;

namespace Kemel.BLL.Services
{
    public class PublisherService : BaseService, IPublisherService
    {
        private readonly IRepository _repository;
        public PublisherService(IRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<PublisherBusinessModel> GetPublishers()
        {
            var entities = _repository.All<Publisher>().ToList();
            return Mapper.Map<List<Publisher>, List<PublisherBusinessModel>>(entities);
        }

        public ExecuteResult AddPublisher(PublisherBusinessModel model)
        {
            return Execute(() =>
            {
                var res = Mapper.Map<Publisher>(model);
                _repository.Save(res);
                return ExecuteResult.Success();
            });
        }

        public ExecuteResult UpdatePublisher(PublisherBusinessModel model)
        {
            return Execute(() =>
            {
                var res = Mapper.Map<Publisher>(model);
                _repository.Save(res);
                return ExecuteResult.Success();
            });
        }

        public ExecuteResult DeletePublisher(int id)
        {
            return Execute(() =>
            {
                _repository.Delete(_repository.GetById(typeof(Publisher), id));
                return ExecuteResult.Success();
            });
        }

        public PublisherBusinessModel FindById(int id)
        {
            return Mapper.Map<PublisherBusinessModel>(_repository.GetById(typeof(Publisher), id));
        }
    }
}
