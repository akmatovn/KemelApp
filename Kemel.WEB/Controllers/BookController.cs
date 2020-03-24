using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kemel.BLL.Interfaces;
using Kemel.WEB.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Kemel.WEB.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
    }

    public class BookGridController : Controller
    {
        public ActionResult BookRead([DataSourceRequest] DataSourceRequest request)
        {
            var data = UnityConfig.ServiceHost.GetService<IBookService>().BookList();
            var res = data.Select(x => new BookViewModel(x));
            return Json(res.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult BookCreate([DataSourceRequest] DataSourceRequest request, BookViewModel book)
        {

            if (book != null && ModelState.IsValid)
            {
                book.PublishedAt = DateTime.Today;
                book.Authors = new List<int> { 1, 2, 7 };

                var res = UnityConfig.ServiceHost.GetService<IBookService>().AddBook(book.ToModel());
                if (!res.IsSuccess)
                {
                    ModelState.AddModelError("", res.Message);
                }
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult BookUpdate([DataSourceRequest] DataSourceRequest request, BookViewModel book)
        {
            if (book != null && ModelState.IsValid)
            {
                var res = UnityConfig.ServiceHost.GetService<IBookService>().UpdateBook(book.ToModel());
                if (!res.IsSuccess)
                {
                    ModelState.AddModelError("", res.Message);
                }
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult BookDelete([DataSourceRequest] DataSourceRequest request, BookViewModel book)
        {
            if (book != null)
            {
                var res = UnityConfig.ServiceHost.GetService<IBookService>().DeleteBook(book.Id);
                if (!res.IsSuccess)
                {
                    ModelState.AddModelError("", res.Message);
                }
            }

            return Json(new[] { book }.ToDataSourceResult(request, ModelState));
        }
    }
}