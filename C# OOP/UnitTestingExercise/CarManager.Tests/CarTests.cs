using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car Car;
        [SetUp]
        public void Setup()
        {
            this.Car = new Car("Make", "Model", 10, 100);
        }

        [Test]
        [TestCase("", "Model", 10, 100)]
        [TestCase(null, "Model", 10, 100)]
        [TestCase("Make", null, 10, 100)]
        [TestCase("Make", "", 10, 100)]
        [TestCase("Make", "Model", 0, 100)]
        [TestCase("Make", "Model", -10, 100)]
        [TestCase("Make", "Model", 10, 0)]
        [TestCase("Make", "Model", 10, -50)]
        public void Ctor_ThrowsException_WhenDataIsInvalid(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void Ctor_SetInitialValues_WhenArgumentsAreValid()
        {
            string make = "Make";
            string model = "Model";
            double fuelConsumption = 10.0;
            double fuelCapacity = 100.0;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(car.Make, Is.EqualTo(make));
            Assert.That(car.Model, Is.EqualTo(model));
            Assert.That(car.FuelConsumption, Is.EqualTo(fuelConsumption));
            Assert.That(car.FuelCapacity, Is.EqualTo(fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20)]
        public void Refuel_ThrowsException_WhenFuelIsZeroOrNegative(double fuel)
        {
            Assert.Throws<ArgumentException>(() => Car.Refuel(fuel));
        }

        [Test]
        public void Refuel_IncreaseFuelAmount_WhenFuelAmountIsValid()
        {
            double refuelAmount = this.Car.FuelCapacity / 2;
            this.Car.Refuel(refuelAmount);

            Assert.That(this.Car.FuelAmount, Is.EqualTo(refuelAmount));
        }

        [Test]
        public void Refuel_SetFuelAmountToCapacity_WhenCapacityIsExceeded()
        {
            double refuelAmount = this.Car.FuelCapacity * 1.2;
            this.Car.Refuel(refuelAmount);

            Assert.That(this.Car.FuelAmount, Is.EqualTo(this.Car.FuelCapacity));
        }

        [Test]
        public void Drive_ThrowsException_WhenTankIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.Car.Drive(100));
        }

        [Test]
        public void Drive_DecreasesFuelAmount_WhenDistanceIsValid()
        {
            double initialFuel = this.Car.FuelCapacity;
            this.Car.Refuel(initialFuel);

            this.Car.Drive(100);

            //Assert.That(this.Car.FuelAmount, Is.LessThan(initialFuel));
            Assert.That(this.Car.FuelAmount, Is.EqualTo(initialFuel - this.Car.FuelConsumption));
        }

        [Test]
        public void Drive_DecreasesFuelAmount_WhenRequiredFuelIsEqualAsFuelAmount()
        {
            double initialFuel = this.Car.FuelCapacity;
            this.Car.Refuel(initialFuel);
            double distance = this.Car.FuelCapacity * this.Car.FuelConsumption;

            this.Car.Drive(distance);
            Assert.That(this.Car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void FuelAmount_ThrowsException_WhenNegativeValueIsPassed()
        {
            this.Car.Refuel(this.Car.FuelCapacity);

        }
    }
}