using System.Web.Mvc;
using Kemel.BLL.Interfaces;
using Kemel.BLL.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Kemel.WEB.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            return View();
        }
    }

    public class AuthorGridController : Controller
    {
        public ActionResult AuthorRead([DataSourceRequest] DataSourceRequest request)
        {
            var res = UnityConfig.ServiceHost.GetService<IAuthorService>().Authors();
            return Json(res.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult AuthorCreate([DataSourceRequest] DataSourceRequest request, AuthorBusinessModel author)
        {
            if (author != null && ModelState.IsValid)
            {
                var res = UnityConfig.ServiceHost.GetService<IAuthorService>().AddAuthor(author);
                if (!res.IsSuccess)
                {
                    ModelState.AddModelError("", res.Message);
                }
            }

            return Json(new[] { author }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult AuthorUpdate([DataSourceRequest] DataSourceRequest request, AuthorBusinessModel author)
        {
            if (author != null && ModelState.IsValid)
            {
                var res = UnityConfig.ServiceHost.GetService<IAuthorService>().UpdateAuthor(author);
                if (!res.IsSuccess)
                {
                    ModelState.AddModelError("", res.Message);
                }
            }

            return Json(new[] { author }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult AuthorDelete([DataSourceRequest] DataSourceRequest request, AuthorBusinessModel author)
        {
            if (author != null)
            {
                var res = UnityConfig.ServiceHost.GetService<IAuthorService>().DeleteAuthor(author.Id);
                if (!res.IsSuccess)
                {
                    ModelState.AddModelError("", res.Message);
                }
            }

            return Json(new[] { author }.ToDataSourceResult(request, ModelState));
        }
    }
}