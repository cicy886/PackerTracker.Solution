using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackerTracker.Models;

namespace PackerTracker.Tests
{
    [TestClass]
    public class ItemTests : IDisposable
    {
        public void Dispose()
        {
            Item.ClearAll();
        }

        [TestMethod]
        public void ItemConstructor_CreatesInstanceOfItem_Item()
        {
            Item newItem = new Item("test","test2");
            Assert.AreEqual(typeof (Item), newItem.GetType());
        }

        [TestMethod]
        public void GetDescription_ReturnsDescription_String()
        {
            //Arrange
            string description = "Walk the dog.";
            string name = "sam";

            //Act
            Item newItem = new Item(description, name);
            string result1 = newItem.Description;
            //string result2 = newItem.Name;

            //Assert
            Assert.AreEqual (description, result1);
           // Assert.AreEqual (description, result2);
        }

        [TestMethod]
        public void SetDescription_SetDescription_String()
        {
            //Arrange
            string description = "Walk the dog.";
            string name = "sam";
            Item newItem = new Item(description,name);
            //Item newItem2 = new Item(name);

            //Act
            string updatedDescription = "Do the dishes";
            string updatedName = "Jerry";
            newItem.Description = updatedDescription;
            newItem.Name = updatedName;
            string result1 = newItem.Description;
            //string result2 = newItem2.Name;

            //Assert
            Assert.AreEqual (updatedDescription, result1);
           // Assert.AreEqual (updatedDescription, result2);
        }

        [TestMethod]
        public void GetAll_ReturnsEmptyList_ItemList()
        {
            // Arrange
            List<Item> newList = new List<Item> { };

            // Act
            List<Item> result = Item.GetAll();

            // Assert
            CollectionAssert.AreEqual (newList, result);
        }

        [TestMethod]
        public void GetAll_ReturnsItems_ItemList()
        {
            //Arrange
            string description01 = "Walk the dog";
            string description02 = "Wash the dishes";
            string name1 = "sam";
            string name2 = "jerry";
            Item newItem1 = new Item(description01,name1);
            Item newItem2 = new Item(description02,name2);
            // Item name1 = new Item(name1);
            // Item name2 = new Item(name2);
            List<Item> newList1 = new List<Item> { newItem1, newItem2 };
            //List<Item> newList2 = new List<Item> { name1, name2 };

            //Act
            List<Item> result = Item.GetAll();

            //Assert
            CollectionAssert.AreEqual (newList1, result);
            //CollectionAssert.AreEqual (newList2, result);
        }
    }
}
