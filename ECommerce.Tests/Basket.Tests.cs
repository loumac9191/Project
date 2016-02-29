using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ECommerce.Project;

namespace ECommerce.Tests
{
    [TestClass]
    public class BasketTests
    {
        [TestMethod]
        public void TestAddItem_ReturnsADictionaryOfOneItemWithOneCount_WhenGivenOneItem()
        {
            //Arrange
            Basket tBasket = new Basket();
            Item tItem = new Item();
            Dictionary<Item,int> tDictionary = new Dictionary<Item,int>();
            //Act
            Dictionary<Item, int> tOutput = tBasket.AddItem(tItem);
            tDictionary.Add(tItem,1);
            //Assert
            Assert.AreEqual(tDictionary.Count, tOutput.Count);
        }
    }
}
