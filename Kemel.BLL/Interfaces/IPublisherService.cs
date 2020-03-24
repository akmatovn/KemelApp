using System.Collections.Generic;
using Kemel.BLL.Models;

namespace Kemel.BLL.Interfaces
{
    public interface IPublisherService : IService
    {
        IEnumerable<PublisherBusinessModel> GetPublishers();
        ExecuteResult AddPublisher(PublisherBusinessModel model);
        ExecuteResult UpdatePublisher(PublisherBusinessModel model);
        ExecuteResult DeletePublisher(int id);
        PublisherBusinessModel FindById(int id);
    }
}
