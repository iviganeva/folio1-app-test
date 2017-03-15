using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentClass.Controllers;
using System.Web.Mvc;

namespace StudentClassUnitTests.Controllers
{    
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {         
            HomeController controller = new HomeController();
        
            ViewResult result = controller.Index() as ViewResult;
          
            Assert.IsNotNull(result);
        }
    }       
}
