using System;

namespace Presents.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        //private Bag bag;
        //private Present present;

      
        //[SetUp]
        //public void SetUp()
        //{
        //    this.bag = new Bag();
        //    this.present = new Present("kur", 2);
        //}

        [Test]
        public void Create_ThrowException_null()
        {
            Present presentNew = null;
            Bag bag = new Bag();
            Assert.Throws<ArgumentNullException>(() => bag.Create(presentNew));

        }

        [Test]
        public void Create_SamePresentThrowException()
        {
            Bag bag2 = new Bag();
            Present newPresent = new Present("Toy", 2);
            bag2.Create(newPresent);

            Assert.Throws<InvalidOperationException>(() => bag2.Create(newPresent));   
        }

        [Test]
        public void Create_returnMessage()
        {
            Bag bag2 = new Bag();
            Present newPresent = new Present("Toy", 2);
            string message = bag2.Create(newPresent);
            string message2 = $"Successfully added present Toy.";
            Assert.AreEqual(message, message2);
        }

        [Test]
        public void Remove_removePresent()
        {
            Bag bag2 = new Bag();
            Present newPresent = new Present("Toy", 2);
            bag2.Create(newPresent);
            Assert.That(bag2.Remove(newPresent), Is.EqualTo(true));
        }

        [Test]
        public void Get_GetPresentWithLeastMagic()
        {
            Bag bag2 = new Bag();
            Present newPresent = new Present("Toy", 2);
            bag2.Create(newPresent);
            Present newPresent1 = new Present("Toy1", 1);
            bag2.Create(newPresent1);

            Assert.That(bag2.GetPresentWithLeastMagic(), Is.EqualTo(newPresent1));
        }

        [Test]
        public void Get_PresentWithName()
        {
            Bag bag2 = new Bag();
            Present newPresent = new Present("Toy", 2);
            bag2.Create(newPresent);
            Present newPresent1 = new Present("Toy1", 1);
            bag2.Create(newPresent1);

            Assert.That(bag2.GetPresent("Toy"), Is.EqualTo(newPresent));
        }

        [Test]
        public void Get_PressentsCollection()
        {
            Bag bag2 = new Bag();
            Present newPresent = new Present("Toy", 2);
            bag2.Create(newPresent);
            Present newPresent1 = new Present("Toy1", 1);
            bag2.Create(newPresent1);
            var collection = bag2.GetPresents();

            Assert.AreEqual(collection, bag2.GetPresents());
        }
    }
}
