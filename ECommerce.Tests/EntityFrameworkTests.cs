using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFramework.Project;
using Moq;
using ECommerce.Project;

namespace ECommerce.Tests
{
    [TestClass]
    public class EntityFrameworkTests
    {
        [TestMethod]
        public void TestBasketAddItem_CallsIItemRepositoryAddItem_WhenGivenAnItemToAdd()
        {
            //Arrange
            Mock<IItemRepository> mockIRepos = new Mock<IItemRepository>();
            Mock<item> mItem = new Mock<item>();
            Basket basket = new Basket(mockIRepos.Object);

            //Act
            basket.AddItem(mItem.Object);

            //Assert
            mockIRepos.Verify(r => r.AddItem(mItem.Object));
        }
        [TestMethod]
        public void MyTestMethod()
        {

        }
    }
}
