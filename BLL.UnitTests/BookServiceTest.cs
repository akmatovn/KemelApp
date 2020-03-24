using System.Collections.Generic;
using Kemel.BLL;
using Kemel.BLL.Interfaces;
using Kemel.BLL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BLL.UnitTests
{
    [TestClass]
    public class BookServiceTest
    {
        private readonly Mock<IBookService> _service;
        private readonly BookBusinessModel _model;
        private readonly List<BookBusinessModel> _listModel;

        public BookServiceTest()
        {
            _service = new Mock<IBookService>();
            _model = new BookBusinessModel();
            _listModel = new List<BookBusinessModel>();

        }

        [TestMethod]
        public void BookTest()
        {
            _service.Setup(x => x.AddBook(_model))
                .Returns(ExecuteResult.Success);
            _service.Setup(x => x.BookList())
                .Returns(_listModel);
        }
    }
}
