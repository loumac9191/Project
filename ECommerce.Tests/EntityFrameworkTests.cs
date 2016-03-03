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
            mockIRepos.Verify(r => r.RetrieveItemByName(mItem.Object));
        }
        //[TestMethod]
        //public void TestBasketRemoveItem_CallsIItemRepositoryRemoveItem_WhenGivenAnItemToRemove()
        //{
        //    //Arrange
        //    Mock<IItemRepository> mockIRepos = new Mock<IItemRepository>();
        //    Mock<item> mItem = new Mock<item>();
        //    mItem.Object.name = "TestingForTheSakeOfTheCode";
        //    Basket basket = new Basket(mockIRepos.Object);

        //    //Act
        //    basket.RemoveItem(mItem.Object.name);

        //    //Assert
        //    mockIRepos.Verify(r => r.RemoveItem(mItem.Object));
        //}
        [TestMethod]
        public void MyTestMethod()
        {
            //Arrange

            //Act

            //Assert


        }
    }
}
