using System.Linq;
using System.Web.Mvc;
using Kemel.BLL.Interfaces;
using Kemel.WEB.Models;

namespace Kemel.WEB.Controllers
{
    public class DropDownListController : Controller
    {
        public ActionResult LookUpPublisher()
        {
            var data = UnityConfig.ServiceHost.GetService<IPublisherService>().GetPublishers();
            var res = data.Select(x => new PublisherViewModel(x));
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LookUpAuthor()
        {
            var data = UnityConfig.ServiceHost.GetService<IAuthorService>().Authors();
            var res = data.Select(x => new AuthorViewModel(x));
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}