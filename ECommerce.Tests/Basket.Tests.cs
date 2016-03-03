using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ECommerce.Project;
using EntityFramework.Project;
using Moq;

namespace ECommerce.Tests
{
    [TestClass]
    public class BasketTests
    {
        //doubles need to be changed to decimal
        [TestMethod]
        public void TestGetContents_ReturnsAnEmptyDictionaryWithKeyAsItemAndValueAsInt_WhenGivenNoItems()
        {
            //Arrange
            Dictionary<item, int> tDictionary = new Dictionary<item, int>();
            IItemRepository iRepository = new ItemRepository();
            Basket basket = new Basket(iRepository);

            //Act
            Dictionary<item, int> testBasket = basket.GetContents();

            //Assert
            Assert.AreEqual(testBasket.Values.Count, tDictionary.Values.Count);

        }
        [TestMethod]
        public void TestAddItem_ReturnsADictionaryOfOneItemWithOneCount_WhenGivenOneItem()
        {
            //Arrange
            string itemName = "adidas Mens Brazuca Top Replique Ball";
            Mock<ItemRepository> iRepository = new Mock<ItemRepository>();
            item returnedItem = new item() {name = itemName, item_id = 1};
            Basket tBasket = new Basket(iRepository.Object);

            //takes irepo mock object, setup method - when its given a string that matches the itemname that was defined above
            //always return the item instantiated above with its properties
            //controlling how it behaves
            iRepository.Setup(x => x.RetrieveItemByName(It.Is<string>(s => s == itemName))).Returns(returnedItem);

            //Act
            tBasket.AddItem(itemName);
            Dictionary<item, int> tOutput = tBasket.GetContents();

            //Assert
            Assert.AreEqual(1, tOutput.Count);
        }
        [TestMethod]
        public void TestAddItem_ReturnsADictionaryOfOneItemWithTwoCount_WhenGivenOneItem()
        {
            //Arrange
            string itemName = "adidas Mens Brazuca Top Replique Ball";
            string itemName2 = "American Psycho";
            Mock<ItemRepository> iRepository = new Mock<ItemRepository>();
            item returnedItem = new item() { name = itemName, item_id = 1 };
            item returnedItem2 = new item() { name = itemName2, item_id = 2 };
            Basket tBasket = new Basket(iRepository.Object);

            iRepository.Setup(x => x.RetrieveItemByName(It.Is<string>(s => s == itemName))).Returns(returnedItem);
            iRepository.Setup(x => x.RetrieveItemByName(It.Is<string>(s => s == itemName2))).Returns(returnedItem2);

            //Act
            tBasket.AddItem(returnedItem2.name);
            tBasket.AddItem(returnedItem.name);
            Dictionary<item, int> tOutput = tBasket.GetContents();

            //Assert
            Assert.AreEqual(2, tOutput.Values.Count);
        }
        [TestMethod]
        public void TestRemoveItem_ReturnsADictionaryOfOneItemWithOneCount_WhenGivenTwoItemsAndHaveOneRemoved()
        {
            //Arrange
            string itemName = "adidas Mens Brazuca Top Replique Ball";
            string itemName2 = "American Psycho";
            Mock<ItemRepository> iRepository = new Mock<ItemRepository>();
            item returnedItem = new item() { name = itemName, item_id = 1 };
            item returnedItem2 = new item() { name = itemName2, item_id = 2 };
            Basket tBasket = new Basket(iRepository.Object);

            iRepository.Setup(x => x.RetrieveItemByName(It.Is<string>(s => s == itemName))).Returns(returnedItem);
            iRepository.Setup(x => x.RetrieveItemByName(It.Is<string>(s => s == itemName2))).Returns(returnedItem2);

            //Act
            tBasket.AddItem(returnedItem2.name);
            tBasket.AddItem(returnedItem.name);
            tBasket.RemoveItem("adidas Mens Brazuca Top Replique Ball");
            Dictionary<item, int> tOutput = tBasket.GetContents();

            //Assert
            Assert.AreEqual(1, tOutput.Values.Count);
        }
        [TestMethod]
        public void TestCalculatePrice_ReturnsTotalPriceOfItemsInBasket_WhenGivenOneItemWithPriceOf25GBP()
        {
            //Arrange
            string itemName = "adidas Mens Brazuca Top Replique Ball";
            Mock<ItemRepository> iRepository = new Mock<ItemRepository>();
            item returnedItem = new item() { name = itemName, item_id = 1, price = 25.00m};
            Basket tBasket = new Basket(iRepository.Object);

            iRepository.Setup(x => x.RetrieveItemByName(It.Is<string>(s => s == itemName))).Returns(returnedItem);

            //Act
            tBasket.AddItem(itemName);
            decimal total = tBasket.CalculatePrice();

            //Assert
            Assert.AreEqual(25, total);
        }
        [TestMethod]
        public void TestCalculatePrice_ReturnsTotalPriceOfItemsInBasket_WhenGivenTwoItemsBothWithPriceOf25GBP()
        {
            //Arrange
            string itemName = "adidas Mens Brazuca Top Replique Ball";
            string itemName2 = "American Psycho";
            Mock<ItemRepository> iRepository = new Mock<ItemRepository>();
            item returnedItem = new item() { name = itemName, item_id = 1, price = 25.00m };
            item returnedItem2 = new item() { name = itemName2, item_id = 2, price = 25.00m };
            Basket tBasket = new Basket(iRepository.Object);

            iRepository.Setup(x => x.RetrieveItemByName(It.Is<string>(s => s == itemName))).Returns(returnedItem);
            iRepository.Setup(x => x.RetrieveItemByName(It.Is<string>(s => s == itemName2))).Returns(returnedItem2);

            //Act
            tBasket.AddItem(returnedItem2.name);
            tBasket.AddItem(returnedItem.name);
            decimal total = tBasket.CalculatePrice();

            //Assert
            Assert.AreEqual(50, total);
        }
    }
}
