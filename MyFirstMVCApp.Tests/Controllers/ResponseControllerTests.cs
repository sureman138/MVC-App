using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFirstMVCApp.Web.Models;
using Moq;
using MyFirstMVCApp.Controllers;
using System.Linq;
using MyFirstMVCApp.DataAccessLayer;
using System.Web.Mvc;



namespace MyFirstMVCApp.Tests.Controllers
{
    [TestClass()]
    public class ResponseControllerTests
    {
        private Mock<IResponseDAL> mockDal;
        private Libs testLib;

        [TestInitialize]
        public void Initialize()
        {
            testLib = new Libs
            {
                responseId = 1,
                Name = "Crazy Lib",
                InputOne = "Grey",
                InputTwo = "Big",
                InputThree = "Rhino",
                InputFour = "Crazy",
                InputFive = "Stumble"
            };

            mockDal = new Mock<IResponseDAL>();

            mockDal
                .Setup(d => d.GetLibById(1))
                .Returns(testLib);
        }

        [TestMethod]
        public void UpdateHTTPGet_ValidIdReturnsResultsView()
        {
            var controller = new ResponseController(mockDal.Object);
            const int ValidId = 1;

            var result = controller.PuzzleOneResult(ValidId) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("PuzzleOneResult", result.ViewName);

            var model = result.Model as Libs;

            Assert.IsNotNull(model);
            Assert.AreEqual(testLib.responseId, model.responseId);
            Assert.AreEqual(testLib.Name, model.Name);
            Assert.AreEqual(testLib.InputOne, model.InputOne);
            Assert.AreEqual(testLib.InputTwo, model.InputTwo);
            Assert.AreEqual(testLib.InputThree, model.InputThree);
            Assert.AreEqual(testLib.InputFour, model.InputFour);
            Assert.AreEqual(testLib.InputFive, model.InputFive);
        }



    }
}
