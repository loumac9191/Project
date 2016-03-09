using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using EntityFramework.Project;
using ECommerce.Project;

namespace ECommerce.Tests
{
    [TestClass]
    public class StockCheckTests
    {
        [TestMethod]
        public void TestStockChecker_ReturnsAStringDetailingWhetherAnItemIsInStock_WhenOneItemIsPassedInToTheStockCheckerMethod()
        {
            //Arrange
            var mockSet = new Mock<ProjectDatabaseEntities>();

            string itemName = "adidas Mens Brazuca Top Replique Ball";
            Mock<ItemRepository> iRepos = new Mock<ItemRepository>(mockSet.Object);
            item returnedItem = new item() { name = itemName, item_id = 1 };
            Stock stockCheck = new Stock(iRepos.Object);

            iRepos.Setup(x => x.RetrieveItemByName(It.Is<string>(s => s == itemName))).Returns(returnedItem);

            //Act
            string stockCheckResult = stockCheck.StockChecker(itemName);

            //Assert
            Assert.AreEqual(stockCheckResult, "adidas Mens Brazuca Top Replique Ball is in stock.");
        }
        [TestMethod]
        public void TestRemoveStock_ReturnsAStringDetailingThatAnItemInTheDatabaseHasBeenRemoved_WhenGivenTheNameOfThatItem()
        {
            //Arrange
            var mockSet = new Mock<ProjectDatabaseEntities>();

            string itemName = "adidas Mens Brazuca Top Replique Ball";
            Mock<ItemRepository> iRepos = new Mock<ItemRepository>(mockSet.Object);
            item returnedItem = new item() { name = itemName, item_id = 1 };
            Stock stockCheck = new Stock(iRepos.Object);

            iRepos.Setup(x => x.RemoveItem(It.Is<string>(s => s == itemName))).Returns(String.Format("{0} has been removed from the Database.", itemName));

            //Act
            string removeItemResult = stockCheck.RemoveStock(itemName);

            //Assert
            Assert.AreEqual(removeItemResult, "adidas Mens Brazuca Top Replique Ball has been removed from the Database.");

        }
        //[TestMethod]
        //public void TestAddStock_ReturnsAStringDetailingThatAnItemHasBeenAddedToTheDatabase_WhenTheItemPropertiesAreHandedToTheAddItemMethod()
        //{

        //}
    }
}
