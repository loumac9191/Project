using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ECommerce.Project;
using EntityFramework.Project;
using Moq;
using System.Data.Entity;
using System.Linq;

namespace ECommerce.Tests
{
    [TestClass]
    public class CheckoutTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Mock<ItemRepository> iRepo = new Mock<ItemRepository>();
            Basket basket = new Basket(iRepo.Object);
            Discount discount = new Discount();
            Checkout checkout = new Checkout(basket, discount);

            //Act
            checkout.Discounter()
            //Assert

        }
    }
}
