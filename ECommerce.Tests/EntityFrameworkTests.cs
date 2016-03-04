using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFramework.Project;
using Moq;
using ECommerce.Project;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace ECommerce.Tests
{
    [TestClass]
    public class EntityFrameworkTests
    {
        [TestMethod]
        public void TestBasketAddItem_CallsIItemRepositoryAddItem_WhenGivenAnItemToAdd()
        {
            //Arrange
            var mockSet = new Mock<ProjectDatabaseEntities>();

            string itemName = "adidas Mens Brazuca Top Replique Ball";
            Mock<ItemRepository> iRepository = new Mock<ItemRepository>(mockSet.Object);
            item returnedItem = new item() { name = itemName, item_id = 1 };
            Basket tBasket = new Basket(iRepository.Object);

            iRepository.Setup(x => x.RetrieveItemByName(It.Is<string>(s => s == itemName))).Returns(returnedItem);

            //Act
            tBasket.AddItem(itemName);

            //Assert
            iRepository.Verify(r => r.RetrieveItemByName(returnedItem.name));
        }

        [TestMethod]
        public void TestRetrieveItemByName_ReturnsAnItemWithNameAbc_WhenInjectingAQueryableListOfItemsIntoAMockedEntityFrameworkThatIncludesAnItemWithNameAbc()
        {
            //Arrange
            item expectedItem = new item() { name = "abc" };

            var data = new List<item>()
            {
                new item() { name="abc"},
                new item() {name ="def"},
                new item() { name="test"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<item>>();
            mockSet.As<IQueryable<item>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<item>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<item>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<item>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            Mock<ProjectDatabaseEntities> mockContext = new Mock<ProjectDatabaseEntities>();
            mockContext.Setup(c => c.items).Returns(mockSet.Object);

            IItemRepository iRepository = new ItemRepository(mockContext.Object);

            //Act
            item resultItem = iRepository.RetrieveItemByName("abc");

            //Assert
            Assert.AreEqual(expectedItem.name, resultItem.name);
        }
    }
}
