using NUnit.Framework;
using System.Collections.Generic;
using TheRace;
using System.Linq;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar car;
        private UnitDriver driver;
        private RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            this.car = new UnitCar("Lada", 5, 2000);
            this.driver = new UnitDriver("Gogi", this.car);
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void AddDriver_isNull()
        {
            driver = null;
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriver_DontContainDriver()
        {
            raceEntry.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriver_Result()
        {
            raceEntry.AddDriver(driver);
            Assert.That(driver.Name, Is.EqualTo("Gogi")); // pod vypros
        }

        [Test]
        public void CalculateAvarage_throwsException()
        {
            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }
         [Test]
        public void CalculateAvarage_Result()
        {
            raceEntry.AddDriver(driver);
            var newCar = new UnitCar("Volga", 5, 2500);
            var newDriver = new UnitDriver("Gosho", newCar);
            raceEntry.AddDriver(newDriver);
            var newCar1 = new UnitCar("BMW", 5, 3500);
            var newDriver1 = new UnitDriver("Sime", newCar1);
            raceEntry.AddDriver(newDriver1);
            var result = 5.0d;
            Assert.That(this.raceEntry.CalculateAverageHorsePower, Is.EqualTo(result));
        }
    }
}