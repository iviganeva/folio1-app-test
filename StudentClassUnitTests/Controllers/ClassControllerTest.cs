using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using StudentClass.Controllers;
using StudentClass.DAL;
using StudentClass.Models;

namespace StudentClassUnitTests.Controllers
{
    [TestClass]
    public class ClassControllerTest
    {
        [TestMethod]
        public void TestIsStudentWithTheSameLastNameExists()
        {
            var fakeItems = new FakeDbSet<Student>
            {
                new Student {ID = 1, LastName = "LastName1"},
                new Student {ID = 2, LastName = "LastName2"},
                new Student {ID = 3, LastName = "LastName3"},
                new Student {ID = 4, LastName = "LastName4"}
            };

            var mockData = Substitute.For<IStudentClassContext>();
            mockData.Students.Returns(fakeItems);

            var studentsController = new StudentController(mockData);

            var result = studentsController.IsStudentWithTheSameLastNameNotExists("LastName1");

            Assert.IsFalse((bool)result.Data);
        }
    }
}
