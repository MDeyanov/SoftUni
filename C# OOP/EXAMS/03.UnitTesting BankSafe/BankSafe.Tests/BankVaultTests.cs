
using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            this.bankVault = new BankVault();
            item = new Item("me", "1");
        }

        [Test]
        public void AddItem_ThrowsException_WhenCellDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("nqma takyv", item));
        }

        [Test]
        public void AddItem_CellisNotNull()
        {
            this.bankVault.AddItem("A1", item);
            var newItem = new Item("gosho", "2");
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", newItem));
        }
        [Test]
        public void AddItem_WhenitemId_exist()
        {
            var newItem = new Item("gosho", "1");
            bankVault.AddItem("A1", newItem);
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("A2", item));
        }
        [Test]
        public void AddItem_SuccesfullAddsItem()
        {
            string result = bankVault.AddItem("B3", item);
            Assert.AreEqual(result, $"Item:{item.ItemId} saved successfully!");
        }

        [Test]
        public void RemoveItems_CellDoesntExist()
        {
            bankVault.AddItem("A1", item);
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("drug", item));
        }

        [Test]
        public void RemoveItems_ItemInCellDoesntExist()
        {
            bankVault.AddItem("A1", item);
            var newItem = new Item("gosho", "1");
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("A1", newItem));
        }

        [Test]
        public void RemovedItem_Sucessfuly()
        {
            bankVault.AddItem("A1", item);
            string result = bankVault.RemoveItem("A1", item);
            Assert.AreEqual(result, $"Remove item:{item.ItemId} successfully!");
        }


    }
}