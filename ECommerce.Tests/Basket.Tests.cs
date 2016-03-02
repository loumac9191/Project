using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ECommerce.Project;
using EntityFramework.Project;

namespace ECommerce.Tests
{
    [TestClass]
    public class BasketTests
    {
        //doubles need to be changed to decimal
        [TestMethod]
        public void TestAddItem_ReturnsADictionaryOfOneItemWithOneCount_WhenGivenOneItem()
        {
            //Arrange
            IItemRepository iRepository = new ItemRepository();
            Basket tBasket = new Basket(iRepository);
            item tItem = new item();

            //Act
            tBasket.AddItem(tItem);
            Dictionary<item, int> tOutput = tBasket.GetContents();

            //Assert
            Assert.AreEqual(1, tOutput.Count);
        }
        [TestMethod]
        public void TestAddItem_ReturnsADictionaryOfOneItemWithTwoCount_WhenGivenOneItem()
        {
            //Arrange
            IItemRepository iRepository = new ItemRepository();
            Basket tBasket = new Basket(iRepository);
            item tItem = new item();
            item tItem2 = new item();

            //Act
            tBasket.AddItem(tItem2);
            tBasket.AddItem(tItem);
            Dictionary<item, int> tOutput = tBasket.GetContents();

            //Assert
            Assert.AreEqual(2, tOutput.Values.Count);
        }
        [TestMethod]
        public void TestRemoveItem_ReturnsADictionaryOfOneItemWithOneCount_WhenGivenTwoItemsAndHaveOneRemoved()
        {
            //Arrange
            IItemRepository iRepository = new ItemRepository();
            Basket tBasket = new Basket(iRepository);
            item tItem = new item();
            tItem.name = "ProductName";
            item tItem2 = new item();

            //Act
            tBasket.AddItem(tItem2);
            tBasket.AddItem(tItem);
            tBasket.RemoveItem("ProductName");
            Dictionary<item,int> tOutput = tBasket.GetContents();

            //Assert
            Assert.AreEqual(1, tOutput.Values.Count);
        }
        [TestMethod]
        public void TestCalculatePrice_ReturnsTotalPriceOfItemsInBasket_WhenGivenOneItemWithPriceOf25GBP()
        {
            //Arrange
            IItemRepository iRepository = new ItemRepository();
            Basket tBasket = new Basket(iRepository);
            item tItem = new item();
            tItem.price = 25;

            //Act
            tBasket.AddItem(tItem);
            decimal total = tBasket.CalculatePrice();

            //Assert
            Assert.AreEqual(25, total);
        }
        [TestMethod]
        public void TestCalculatePrice_ReturnsTotalPriceOfItemsInBasket_WhenGivenTwoItemsBothWithPriceOf25GBP()
        {
            //Arrange
            IItemRepository iRepository = new ItemRepository();
            Basket tBasket = new Basket(iRepository);
            item tItem = new item();
            tItem.price = 25;
            item tItem2 = new item();
            tItem2.price = 25;

            //Act
            tBasket.AddItem(tItem);
            tBasket.AddItem(tItem2);
            decimal total = tBasket.CalculatePrice();

            //Assert
            Assert.AreEqual(50, total);
        }
    }
}
