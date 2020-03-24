using System.Web.Mvc;
using Kemel.BLL.Interfaces;
using Kemel.BLL.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Kemel.WEB.Controllers
{
    public class PublisherController : Controller
    {
        // GET: Publisher
        public ActionResult Index()
        {
            return View();
        }
    }

    public class PublisherGridController : Controller
    {
        public ActionResult PublisherRead([DataSourceRequest] DataSourceRequest request)
        {
            var res = UnityConfig.ServiceHost.GetService<IPublisherService>().GetPublishers();
            return Json(res.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult PublisherCreate([DataSourceRequest] DataSourceRequest request, PublisherBusinessModel publisher)
        {
            if (publisher != null && ModelState.IsValid)
            {
                var res = UnityConfig.ServiceHost.GetService<IPublisherService>().AddPublisher(publisher);
                if (!res.IsSuccess)
                {
                    ModelState.AddModelError("", res.Message);
                }
            }

            return Json(new[] { publisher }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult PublisherUpdate([DataSourceRequest] DataSourceRequest request, PublisherBusinessModel publisher)
        {
            if (publisher != null && ModelState.IsValid)
            {
                var res = UnityConfig.ServiceHost.GetService<IPublisherService>().UpdatePublisher(publisher);
                if (!res.IsSuccess)
                {
                    ModelState.AddModelError("", res.Message);
                }
            }

            return Json(new[] { publisher }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult PublisherDelete([DataSourceRequest] DataSourceRequest request, BookBusinessModel book)
        {
            if (book != null)
            {
                var res = UnityConfig.ServiceHost.GetService<IPublisherService>().DeletePublisher(book.Id);
                if (!res.IsSuccess)
                {
                    ModelState.AddModelError("", res.Message);
                }
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
        }
    }
}