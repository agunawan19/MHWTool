using System.Web.Mvc;
using Mhw.ApiV1.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mhw.ApiV1.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
