using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EntityFramework.Project;
using ECommerce.Project;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace ECommerce.Tests
{
    [TestClass]
    public class StockCheckTests
    {
        [TestMethod]
        public void TestStockChecker_ReturnsAStringDetailingTheStockLevelOfAnItem_WhenOneItemIsPassedInToTheStockCheckerMethodAndThatItemsStockLevelIs1()
        {
            //Arrange
            var mockSet = new Mock<ProjectDatabaseEntities>();
            string itemName = "adidas Mens Brazuca Top Replique Ball";
            int quantityOfItemToCheck = 1;
            string expectedResult = String.Format("{0} stock count is: {1}", itemName, quantityOfItemToCheck);
            Mock<ItemRepository> iRepos = new Mock<ItemRepository>(mockSet.Object);
            
            Stock stockCheck = new Stock(iRepos.Object);

            iRepos.Setup(x => x.GetStockCount(It.Is<string>(s => s == itemName))).Returns(quantityOfItemToCheck);

            //Act
            string stockCheckResult = stockCheck.StockChecker(itemName);

            //Assert
            Assert.AreEqual(stockCheckResult, expectedResult);
        }

        [TestMethod]
        public void TestStockChecker_ReturnsAStringDetailingTheStockLevelOfAnItem_WhenOneItemIsPassedInToTheStockCheckerMethodAndThatItemsStockLevelIs0()
        {
            //Arrange
            var mockSet = new Mock<ProjectDatabaseEntities>();
            string itemName = "adidas Mens Brazuca Top Replique Ball";
            int quantityOfItemToCheck = 0;
            string expectedResult = String.Format("{0} is not in stock", itemName);
            Mock<ItemRepository> iRepos = new Mock<ItemRepository>(mockSet.Object);

            Stock stockCheck = new Stock(iRepos.Object);

            iRepos.Setup(x => x.GetStockCount(It.Is<string>(s => s == itemName))).Returns(quantityOfItemToCheck);

            //Act
            string stockCheckResult = stockCheck.StockChecker(itemName);

            //Assert
            Assert.AreEqual(stockCheckResult, expectedResult);
        }

        [TestMethod]
        public void TestRemoveStock_ReturnsAStringDetailingThatAnItemInTheDatabaseHasBeenRemoved_WhenGivenTheNameOfThatItemAndTheQuantityToRemove()
        {
            //Arrange
            var mockSet = new Mock<ProjectDatabaseEntities>();

            string itemName = "adidas Mens Brazuca Top Replique Ball";
            int quantityOfItem = 1;
            Mock<ItemRepository> iRepos = new Mock<ItemRepository>(mockSet.Object);
            item returnedItem = new item() { name = itemName, item_id = 1 };
            Stock stockCheck = new Stock(iRepos.Object);

            iRepos.Setup(x => x.RemoveItem(It.Is<string>(s => s == itemName),It.Is<int>(s => s == quantityOfItem))).Returns(String.Format("{0} has been removed from the Database.", itemName));

            //Act
            string removeItemResult = stockCheck.RemoveStock(itemName,quantityOfItem);

            //Assert
            Assert.AreEqual(removeItemResult, "adidas Mens Brazuca Top Replique Ball has been removed from the Database.");

        }

        // ANOTHER REMOVE TEST TO TEST THAT THE STOCK LEVEL HAS BEEN REDUCED

        [TestMethod]
        public void TestAddStock_ReturnsAStringDetailingThatAnItemHasBeenAddedToTheDatabase_WhenTheItemPropertiesAreHandedToTheAddItemMethod()
        {
            //Arrange
            var mockSet = new Mock<ProjectDatabaseEntities>();

            string itemName = "adidas Mens Brazuca Top Replique Ball";
            int quantityOfItem = 1;
            //string expectedResult = String.Format("",);
            Mock<ItemRepository> iRepos = new Mock<ItemRepository>(mockSet.Object);
            item returnedItem = new item() { name = itemName, item_id = 1 };
            Stock stockCheck = new Stock(iRepos.Object);

            iRepos.Setup(x => x.RemoveItem(It.Is<string>(s => s == itemName),It.Is<int>(s => s == quantityOfItem))).Returns(String.Format("{0} has been removed from the Database.", itemName));

            //Act
            string removeItemResult = stockCheck.RemoveStock(itemName,quantityOfItem);

            //Assert
            Assert.AreEqual(removeItemResult, ".");
        }

        // ANOTHER ADD TEST TO CHEK THAT THE STOCK LEVEL HAS BEEN INCREASED
    }
}
