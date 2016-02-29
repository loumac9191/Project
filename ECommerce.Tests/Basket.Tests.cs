﻿using System;
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

            //Act
            Dictionary<Item, int> tOutput = tBasket.AddItem(tItem);

            //Assert
            Assert.AreEqual(1, tOutput.Count);
        }
        [TestMethod]
        public void TestAddItem_ReturnsADictionaryOfOneItemWithTwoCount_WhenGivenOneItem()
        {
            //Arrange
            Basket tBasket = new Basket();
            Item tItem = new Item();
            Item tItem2 = new Item();

            //Act
            tBasket.AddItem(tItem2);
            Dictionary<Item, int> tOutput = tBasket.AddItem(tItem);

            //Assert
            Assert.AreEqual(2, tOutput.Values.Count);
        }
        [TestMethod]
        public void TestRemoveItem_ReturnsADictionaryOfOneItemWithOneCount_WhenGivenTwoItemsAndHaveOneRemoved()
        {
                        //Arrange
            Basket tBasket = new Basket();
            Item tItem = new Item();
            tItem.ItemName = "ProductName";
            Item tItem2 = new Item();

            //Act
            tBasket.AddItem(tItem2);
            tBasket.AddItem(tItem);
            tBasket.RemoveItem("ProductName");
            tBasket.A

            //Assert
            Assert.AreEqual(2, tBasket.);
        }
    }
}
