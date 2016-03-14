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
            Stock stockCheck = new Stock(iRepos.Object);

            iRepos.Setup(x => x.RemoveItem(It.Is<string>(s => s == itemName),It.Is<int>(s => s == quantityOfItem))).Returns(String.Format("{0} has been removed from the Database.", itemName));

            //Act
            string removeItemResult = stockCheck.RemoveStock(itemName,quantityOfItem);

            //Assert
            Assert.AreEqual(removeItemResult, "adidas Mens Brazuca Top Replique Ball has been removed from the Database.");
        }
        [TestMethod]
        public void TestRemoveStock_ReturnsAStringDetailingThatAnItemsStockLevelHasBeenReduced_WhenGivenTheNameOfThatItemAndTheQuantityToReduce()
        {
            //Arrange
            string itemName = "adidas Mens Brazuca Top Replique Ball";
            int quantityOfItemToRemove = 1;

            var data = new List<item>()
            {
                new item() { name="adidas Mens Brazuca Top Replique Ball", item_description="You can kick this.",category="Sports", price=5.99m,quantityOfItem=2 },
            }.AsQueryable();

            string expectedResult = String.Format("There are now a total of {0} of {1} in stock", 1, itemName);

            var mockSet = new Mock<DbSet<item>>();
            mockSet.As<IQueryable<item>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<item>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<item>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<item>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            Mock<ProjectDatabaseEntities> mockContext = new Mock<ProjectDatabaseEntities>();
            mockContext.Setup(c => c.items).Returns(mockSet.Object);

            ItemRepository iRepository = new ItemRepository(mockContext.Object);
            Stock stockCheck = new Stock(iRepository);
            
            //Act
            string actualResult = stockCheck.RemoveStock(itemName, quantityOfItemToRemove);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void Test_RemoveStock_ReturnsAStringDetailingThatAnItemDoesNotExistInTheDatabase_WhenGivenItemNameThatDoesNotExistInTheDatabase()
        {
            string itemName = "test";
            int quantityOfItemToRemove = 1;

            var data = new List<item>()
            {
                new item() { name="adidas Mens Brazuca Top Replique Ball", item_description="You can kick this.",category="Sports", price=5.99m,quantityOfItem=2 },
            }.AsQueryable();

            string expectedResult = String.Format("{0} could not be removed as this does not exist within the database", itemName);

            var mockSet = new Mock<DbSet<item>>();
            mockSet.As<IQueryable<item>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<item>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<item>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<item>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            Mock<ProjectDatabaseEntities> mockContext = new Mock<ProjectDatabaseEntities>();
            mockContext.Setup(c => c.items).Returns(mockSet.Object);

            ItemRepository iRepository = new ItemRepository(mockContext.Object);
            Stock stockCheck = new Stock(iRepository);

            //Act
            string actualResult = stockCheck.RemoveStock(itemName, quantityOfItemToRemove);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestMethod]
        public void TestAddStock_ReturnsAStringDetailingThatAnItemHasBeenAddedToTheDatabase_WhenTheItemPropertiesAreHandedToTheAddItemMethodAndThatItemDoesNotAlreadyExistInDatabase()
        {
            //Arrange
            var mockSet = new Mock<ProjectDatabaseEntities>();

            string itemName = "adidas Mens Brazuca Top Replique Ball";
            string itemDescription = "You can kick this.";
            string itemCategory = "Sports";
            decimal itemPrice = 5.99m;
            int quantityOfItem = 1;
            string expectedResult = String.Format("{0} has been added to the Database", itemName);
            Mock<ItemRepository> iRepos = new Mock<ItemRepository>(mockSet.Object);
            Stock stockCheck = new Stock(iRepos.Object);

            iRepos.Setup(x => x.AddItem(It.Is<string>(s => s == itemName), It.Is<string>(s => s == itemCategory), It.Is<string>(s => s == itemDescription), It.Is<decimal>(s => s == itemPrice), It.Is<int>(s => s == quantityOfItem))).Returns(String.Format("{0} has been added to the Database", itemName));

            //Act
            string addItemResult = stockCheck.AddStock(itemName, itemCategory, itemDescription, itemPrice, quantityOfItem);

            //Assert
            Assert.AreEqual(addItemResult, expectedResult);
        }
        [TestMethod]
        public void TestAddStock_ReturnsAStringConfirmingTheIncreasedStockLevel_WhenGivenAnItemThatAlreadyExistsInTheDatabase()
        {
            //Arrange
            string itemName = "adidas Mens Brazuca Top Replique Ball";
            string itemDescription = "You can kick this.";
            string itemCategory = "Sports";
            decimal itemPrice = 5.99m;
            int quantityOfItem = 1;

            var data = new List<item>()
            {
                new item() { name="adidas Mens Brazuca Top Replique Ball", item_description="You can kick this.",category="Sports", price=5.99m,quantityOfItem=1 },
            }.AsQueryable();

            string expectedResult = String.Format("There are now a total of {0} of {1} in stock", (quantityOfItem + data.ElementAt(0).quantityOfItem), itemName);

            var mockSet = new Mock<DbSet<item>>();
            mockSet.As<IQueryable<item>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<item>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<item>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<item>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            Mock<ProjectDatabaseEntities> mockContext = new Mock<ProjectDatabaseEntities>();
            mockContext.Setup(c => c.items).Returns(mockSet.Object);

            ItemRepository iRepository = new ItemRepository(mockContext.Object);
            Stock stockCheck = new Stock(iRepository);

            //Act
            string addItemResult = stockCheck.AddStock(itemName, itemCategory, itemDescription, itemPrice, quantityOfItem);

            //Assert
            Assert.AreEqual(addItemResult, expectedResult);
        }
        [TestMethod]
        public void TestStockRetriever_ReturnsANewItemWithNoAttributes_WhenGivenAnItemNameThatDoesNotExistInTheDatabase()
        {
            //Arrange
            string itemName = "test";
            item expectedItem = new item();

            var data = new List<item>()
            {
                new item() { name = "adidas Mens Brazuca Top Replique Ball", item_description = "You can kick this.", category = "Sports", price = 5.99m, quantityOfItem = 1 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<item>>();
            mockSet.As<IQueryable<item>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<item>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<item>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<item>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            Mock<ProjectDatabaseEntities> mockContext = new Mock<ProjectDatabaseEntities>();
            mockContext.Setup(c => c.items).Returns(mockSet.Object);

            ItemRepository iRepository = new ItemRepository(mockContext.Object);
            Stock stockCheck = new Stock(iRepository);

            //Act
            item actualItem = stockCheck.StockRetriever(itemName);

            //Assert
            Assert.AreEqual(expectedItem.name, actualItem.name);
        }
        [TestMethod]
        public void TestStockRetriever_ReturnsTheRequestedItem_WhenGivenTheNameOfThatItem()
        {
            //Arrange
            string itemName = "adidas Mens Brazuca Top Replique Ball";
            var data = new List<item>()
            {
                new item() { name = "adidas Mens Brazuca Top Replique Ball", item_description = "You can kick this.", category = "Sports", price = 5.99m, quantityOfItem = 1 },
            }.AsQueryable();

            item expectedItem = data.ElementAt(0);

            var mockSet = new Mock<DbSet<item>>();
            mockSet.As<IQueryable<item>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<item>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<item>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<item>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            Mock<ProjectDatabaseEntities> mockContext = new Mock<ProjectDatabaseEntities>();
            mockContext.Setup(c => c.items).Returns(mockSet.Object);

            ItemRepository iRepository = new ItemRepository(mockContext.Object);
            Stock stockCheck = new Stock(iRepository);

            //Act
            item actualItem = stockCheck.StockRetriever(itemName);

            //Assert
            Assert.AreEqual(expectedItem, actualItem);
        }
    }
}
