using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcGET.Controllers;
using System.Web.Mvc;
using MvcGET.Models;
using System.Net;
using Moq;
using System.Data.Entity;

namespace MvcGET.Tests.Controller
{
    /// <summary>
    /// Summary description for StudentsControllerTest
    /// </summary>
    [TestClass]
    public class StudentsControllerTest
    {

        [TestMethod]
        public void Index()
        {
            // Arrange
            var context = new SkolaDBContext();
            var controller = new StudentsController(context);
            var expected = typeof(IEnumerable<Student>);

            // Act
            var result = controller.Index() as ViewResult;
            var actual = (result == null) ? null : result.Model;


            // Assert
            Assert.IsNotNull(result);

            Assert.IsInstanceOfType(actual, expected);
        }

        [TestMethod]
        public void Details()
        {
            // Arrange
            var context = new SkolaDBContext();
            var controller = new StudentsController(context);
            var expectedBadRequestCode = 400;
            int? idNull = null;
            var expectedNotFoundCode = 404;
            int? idWrong = -1;

            // Act
            var resultResponseBadRequest = controller.Details(idNull) as HttpStatusCodeResult;
            var resultResponseNotFound = controller.Details(idWrong) as HttpStatusCodeResult;
            var actualBadRequestCode = (resultResponseBadRequest == null)? -1: resultResponseBadRequest.StatusCode;
            var actualNotFoundCode = (resultResponseNotFound == null) ? -1 : resultResponseNotFound.StatusCode;

            // Assert
            Assert.AreEqual(expectedBadRequestCode, actualBadRequestCode);

            Assert.AreEqual(expectedNotFoundCode, actualNotFoundCode);

        }

        [TestMethod]
        public void Create()
        {
            // Arrange
            var mockSet = new Mock<DbSet<Student>>();
            var mockContext = new Mock<ISkolaDBContext>();
            mockContext.Setup(m => m.Students).Returns(mockSet.Object);
            var expectedStudent = new Student
            {
                Ime = "Frank",
                Prezime = "Vega",
                Adresa = "Cerska",
                Grad = "Beograd"
            };
            var controller = new StudentsController(mockContext.Object);
            
            
            // Act
            controller.Create(expectedStudent);
            
            // Assert
            mockSet.Verify(m => m.Add(It.IsAny<Student>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }


    }
}
