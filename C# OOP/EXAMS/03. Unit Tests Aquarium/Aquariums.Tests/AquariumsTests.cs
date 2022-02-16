namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;
        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium("Grozen", 5);
            fish = new Fish("Gosho");
        }

        [Test]
        public void AquariumName_exceptionIfNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(null, 5));
        }
        [Test]
        public void AquariumName_empty()
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 5));
        }

        [Test]
        public void AquariumCap_exceptionIfUnderZero()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Gogi", -5));
        }
        [Test]
        public void CountOfFishInAquarium()
        {
            aquarium.Add(fish);
            Fish nov = new Fish("gogi");
            aquarium.Add(nov);
            Assert.AreEqual(aquarium.Count, 2);
        }
        [Test]
        public void AquariumAdd_throwException_WhenFull()
        {
            Aquarium nov = new Aquarium("ribarnika", 2);
            nov.Add(fish);
            Fish newFish = new Fish("gogi");
            nov.Add(newFish);
            Assert.Throws<InvalidOperationException>(() => nov.Add(new Fish("peSho")));
        }
        [Test] // na tva remove moje a se naloji oshte 1 dali e premahnata ...
        public void RemoveFish_throwException_whenFishIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Pesho"));
        }
        [Test]  
        public void RemoveFish_RemovetheFish()
        {
            aquarium.Add(fish);
            aquarium.Add(new Fish("pepi"));
            aquarium.RemoveFish("pepi");
            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]  
        public void SellFish_throwException_whenFishIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Pesho"));
        }
        [Test]
        public void SellFish_fishIsUnavaiable()
        {
            aquarium.Add(fish);

            var expected = fish;
            var actual = aquarium.SellFish("Gosho");

            Assert.AreEqual(expected, actual);
            Assert.That(fish.Available, Is.EqualTo(false));
        
        }
        [Test]
        public void ReportTest()
        {
            aquarium.Add(fish);
            Fish newFish = new Fish("gogi");
            aquarium.Add(newFish);
            string report = $"Fish available at {"Grozen"}: {"Gosho, gogi"}";
            Assert.AreEqual(report, aquarium.Report());
        }
        [Test]
        public void SellFish_WhenFishIsNotFound_ShouldThrowInvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Gosho"));
            StringAssert.Contains($"Fish with the name {"Gosho"} doesn't exist!", ex.Message);
        }
        [Test]
        public void Constructor_WithValidParameters_ShouldSetTheFieldsCorrectlyAndInitializeAList()
        {
            var expected = 0;
            var actual = aquarium.Count;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual("Grozen", aquarium.Name);
            Assert.AreEqual(5, aquarium.Capacity);
        }
        //[Test]
        //public void SellFish_WhenFishIsFound_ShouldReturnTheFishAndSetNotAvailable()
        //{
        //    aquarium.Add(fish);

        //    var expected = fish;
        //    var actual = aquarium.SellFish("Gosho");

        //    Assert.AreEqual(expected, actual);
        //    Assert.IsFalse(fish.Available);
        //}
    }
}
