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
            //Mock<ItemRepository> mockIRepos = new Mock<ItemRepository>();
            //Mock<item> mItem = new Mock<item>();
            //mItem.Object.name = "adidas Mens Brazuca Top Replique Ball";
            //Basket basket = new Basket(mockIRepos.Object);

            string itemName = "adidas Mens Brazuca Top Replique Ball";
            Mock<ItemRepository> iRepository = new Mock<ItemRepository>();
            item returnedItem = new item() { name = itemName, item_id = 1 };
            Basket tBasket = new Basket(iRepository.Object);

            iRepository.Setup(x => x.RetrieveItemByName(It.Is<string>(s => s == itemName))).Returns(returnedItem);
            //Act
            tBasket.AddItem(itemName);

            //Assert
            iRepository.Verify(r => r.RetrieveItemByName(returnedItem.name));
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
        //[TestMethod]
        //public void MyTestMethod()
        //{
        //    //Arrange

        //    //Act

        //    //Assert


        //}
    }
}
