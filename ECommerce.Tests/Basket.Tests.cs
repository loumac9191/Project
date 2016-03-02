using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ECommerce.Project;

namespace ECommerce.Tests
{
    [TestClass]
    public class BasketTests
    {
        [TestMethod]
        public void TestAddItem_ReturnsADictionaryOfOneItemWithOneCount_WhenGivenOneItem()
        {
            //Arrange
            Basket tBasket = new Basket();
            Item tItem = new Item();

            //Act
            tBasket.AddItem(tItem);
            Dictionary<Item, int> tOutput = tBasket.GetContents();

            //Assert
            Assert.AreEqual(1, tOutput.Count);
        }
        [TestMethod]
        public void TestAddItem_ReturnsADictionaryOfOneItemWithTwoCount_WhenGivenOneItem()
        {
            //Arrange
            Basket tBasket = new Basket();
            Item tItem = new Item();
            Item tItem2 = new Item();

            //Act
            tBasket.AddItem(tItem2);
            tBasket.AddItem(tItem);
            Dictionary<Item, int> tOutput = tBasket.GetContents();

            //Assert
            Assert.AreEqual(2, tOutput.Values.Count);
        }
        [TestMethod]
        public void TestRemoveItem_ReturnsADictionaryOfOneItemWithOneCount_WhenGivenTwoItemsAndHaveOneRemoved()
        {
            //Arrange
            Basket tBasket = new Basket();
            Item tItem = new Item();
            tItem.ItemName = "ProductName";
            Item tItem2 = new Item();

            //Act
            tBasket.AddItem(tItem2);
            tBasket.AddItem(tItem);
            tBasket.RemoveItem("ProductName");
            Dictionary<Item,int> tOutput = tBasket.GetContents();

            //Assert
            Assert.AreEqual(1, tOutput.Values.Count);
        }
        [TestMethod]
        public void TestCalculatePrice_ReturnsTotalPriceOfItemsInBasket_WhenGivenOneItemWithPriceOf25GBP()
        {
            //Arrange
            Basket tBasket = new Basket();
            Item tItem = new Item();
            tItem.Price = 25;

            //Act
            tBasket.AddItem(tItem);
            double total = tBasket.CalculatePrice();

            //Assert
            Assert.AreEqual(25, total);
        }
        [TestMethod]
        public void TestCalculatePrice_ReturnsTotalPriceOfItemsInBasket_WhenGivenTwoItemsBothWithPriceOf25GBP()
        {
            //Arrange
            Basket tBasket = new Basket();
            Item tItem = new Item();
            tItem.Price = 25;
            Item tItem2 = new Item();
            tItem2.Price = 25;

            //Act
            tBasket.AddItem(tItem);
            tBasket.AddItem(tItem2);
            double total = tBasket.CalculatePrice();

            //Assert
            Assert.AreEqual(50, total);
        }
    }
}
