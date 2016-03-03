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
            string itemName = "adidas Mens Brazuca Top Replique Ball";
            Mock<IItemRepository> iRepos = new Mock<IItemRepository>();
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
            string itemName = "adidas Mens Brazuca Top Replique Ball";
            Mock<IItemRepository> iRepos = new Mock<IItemRepository>();
            item returnedItem = new item() { name = itemName, item_id = 1 };
            Stock stockCheck = new Stock(iRepos.Object);
            string resultString = String.Format("{0} has been removed from the Database.", itemName);

            iRepos.Setup(x => x.RemoveItem(It.Is<string>(s => s == itemName))).Returns(resultString);
            
            //Act
            string removeItemResult = stockCheck.RemoveStock(itemName);
            
            //Assert
            Assert.AreEqual(removeItemResult, resultString);
        }
    }
}
