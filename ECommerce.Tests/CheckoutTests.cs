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
        public void TestCurrentDiscountOffers_IsCalled_WhenTheDiscounterMethodIsCalledInTheCheckoutClass()
        {
            //Arrange
            string test = "TW3NTYFIV3";
            decimal output = 0.75m;
            Mock<ProjectDatabaseEntities> mockContext = new Mock<ProjectDatabaseEntities>();
            Mock<ItemRepository> iRepo = new Mock<ItemRepository>(mockContext.Object);
            Mock<Basket> basket = new Mock<Basket>(iRepo.Object);
            Mock<Discount> mdiscount = new Mock<Discount>();
            mdiscount.Setup(d => d.CurrentDiscountOffers(It.Is<string>(s => s == test))).Returns(output);
            Checkout checkout = new Checkout(basket.Object, mdiscount.Object);

            //Act
            checkout.Discounter(test);
            
            //Assert
            mdiscount.Verify(x => x.CurrentDiscountOffers(test), Times.Once);
        }
        [TestMethod]
        public void TestCalculateTotal_IsCalled_WhenACheckoutObjectIsInstantiated()
        {
            //Arrange
            Mock<ProjectDatabaseEntities> mockContext = new Mock<ProjectDatabaseEntities>();
            Mock<ItemRepository> iRepo = new Mock<ItemRepository>(mockContext.Object);
            Mock<Basket> basket = new Mock<Basket>(iRepo.Object);
            Mock<Discount> mdiscount = new Mock<Discount>();

            //Act
            Checkout checkout = new Checkout(basket.Object, mdiscount.Object);

            //Assert
            basket.Verify(x => x.CalculatePrice(), Times.Once);
        }
        [TestMethod]
        public void TestDiscounter_ReturnsATwentyFivePercentDiscountToTheTotalPriceOfItems_WhenGivenABasketWithOneItemAndTheTwentyFivePercentDiscountString()
        {
            //Arrange
            string twentyFive = "TW3NTYFIV3";
            string itemName = "adidas Mens Brazuca Top Replique Ball";
            decimal expectedTotal = 18.75m;
            Mock<ProjectDatabaseEntities> mockContext = new Mock<ProjectDatabaseEntities>();
            Mock<ItemRepository> iRepo = new Mock<ItemRepository>(mockContext.Object);
            item returnedItem = new item() { name = itemName, item_id = 1, price = 25.00m };
            iRepo.Setup(x => x.RetrieveItemByName(It.Is<string>(s => s == itemName))).Returns(returnedItem);
            Basket basket = new Basket(iRepo.Object);
            basket.AddItem(itemName);            
            Discount discount = new Discount();
            Checkout checkout = new Checkout(basket, discount);

            //Act
            decimal expectedOutput = checkout.Discounter(twentyFive);

            //Assert
            Assert.AreEqual(expectedOutput, expectedTotal);
        }
        [TestMethod]
        public void TestDiscounter_ReturnsAFiftyPercentDiscountToTheTotalPriceOfItems_WhenGivenABasketWithOneItemAndTheFiftyPercentDiscountString()
        {
            //Arrange
            string twentyFive = "!F1FTY!";
            string itemName = "adidas Mens Brazuca Top Replique Ball";
            decimal expectedTotal = 12.5m;
            Mock<ProjectDatabaseEntities> mockContext = new Mock<ProjectDatabaseEntities>();
            Mock<ItemRepository> iRepo = new Mock<ItemRepository>(mockContext.Object);
            item returnedItem = new item() { name = itemName, item_id = 1, price = 25.00m };
            iRepo.Setup(x => x.RetrieveItemByName(It.Is<string>(s => s == itemName))).Returns(returnedItem);
            Basket basket = new Basket(iRepo.Object);
            basket.AddItem(itemName);            
            Discount discount = new Discount();
            Checkout checkout = new Checkout(basket, discount);

            //Act
            decimal expectedOutput = checkout.Discounter(twentyFive);

            //Assert
            Assert.AreEqual(expectedOutput, expectedTotal);
        }
        [TestMethod]
        public void TestDiscounter_ReturnsNoDiscountToTheTotalPriceOfItems_WhenGivenAnIncorrectDiscountString()
        {
            //Arrange
            string twentyFive = "This Won't Work";
            string itemName = "adidas Mens Brazuca Top Replique Ball";
            decimal expectedTotal = 25m;
            Mock<ProjectDatabaseEntities> mockContext = new Mock<ProjectDatabaseEntities>();
            Mock<ItemRepository> iRepo = new Mock<ItemRepository>(mockContext.Object);
            item returnedItem = new item() { name = itemName, item_id = 1, price = 25.00m };
            iRepo.Setup(x => x.RetrieveItemByName(It.Is<string>(s => s == itemName))).Returns(returnedItem);
            Basket basket = new Basket(iRepo.Object);
            basket.AddItem(itemName);
            Discount discount = new Discount();
            Checkout checkout = new Checkout(basket, discount);

            //Act
            decimal expectedOutput = checkout.Discounter(twentyFive);

            //Assert
            Assert.AreEqual(expectedOutput, expectedTotal);
        }
    }
}
