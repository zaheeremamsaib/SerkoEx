using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serko.Controllers;
using Serko.Models;

namespace Serko.Tests.Controllers
{
    [TestClass]
    public class TotalExpenseControllerTest
    {
        [TestMethod]
        public void TotalIndex()
        {
            // Arrange
            TotalExpenseController controller = new TotalExpenseController();

            // Act
            ViewResult result = controller.Index() as ViewResult;
            var totalExpense = (TotalExpense)result.ViewData.Model;
            
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }

       
    }
}
