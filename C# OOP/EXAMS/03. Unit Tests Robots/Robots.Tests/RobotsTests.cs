using NUnit.Framework;
using System;

namespace Robots.Tests
{
   

    [TestFixture]
    public class RobotsTests
    {
        private RobotManager robotManager;
        private Robot robot;
        [SetUp]
        public void Setup()
        {
            this.robotManager = new RobotManager(5);
            this.robot = new Robot("Gosho", 100);
        }

        [Test]
        public void RobotManager_Capacity()
        {
            Assert.That(robotManager.Capacity, Is.EqualTo(5));
        }

        [Test]
        public void Test_Count()
        {
            robotManager.Add(robot);
            Assert.That(robotManager.Count, Is.EqualTo(1));
        }
        [Test]
        public void RobotManager_ThrowsException_lessThenZero()
        {
            Assert.Throws<ArgumentException>(() =>new RobotManager(-1));
        }

        [Test]
        public void Add_ThrowsException_WhenAddSameNameRobot()
        {
            robotManager.Add(robot);
            var newRobot = new Robot("Gosho", 100);
            Assert.Throws<InvalidOperationException>(()=> this.robotManager.Add(newRobot));
        }
        [Test]
        public void Add_ThrowsException_WhenCapacityisMore()
        {
            robotManager.Add(robot);
            var newRobot = new Robot("Gossswwewho", 100);
            robotManager.Add(newRobot);
            robotManager.Add(new Robot("gogi", 50));
            robotManager.Add(new Robot("gogiw", 30));
            robotManager.Add(new Robot("gogie", 20));
            var newRobotee = new Robot("Gossssho", 100);
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Add(newRobotee));
        }

        [Test]
        public void Remove_ThrowsException()
        {
            string name = null;
            Assert.Throws<InvalidOperationException>(()=>robotManager.Remove(name));
        }
        [Test]
        public void Word_throwsException_WhenRobotDontExist()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Gogi", "Neznam", 5));
        }
        [Test]
        public void ThrowsExceptionWhenCurrentBatteryUsageIsLessThanExpected()
        {
            var robotManager = new RobotManager(10);
            var robot = new Robot("Test", 10);

            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work("Test", "manager", 1000));
        }

        [Test]
        public void Charge_throwsException_WhenRobotDontExist()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge("Gogi"));
        }
        [Test]
        public void Word_BatteryUsage()
        {
            robotManager.Add(robot);
            robotManager.Work("Gosho", "nekvarabota", 5);
            Assert.That(robot.Battery, Is.EqualTo(95));
        }
        [Test]
        public void Charge_WhenRobotCharge()
        {
            robotManager.Add(robot);
            robot.Battery = 50;// kato proverqvam neshto po dobre da mu zadam stoinost otkoloto da go namalqm kato tuka primerno s WORK metoda
            robotManager.Charge("Gosho");
            Assert.That(robot.Battery, Is.EqualTo(100)); // kato iskam da proverqvam nqkakva stoinost po dobre da pisha chisloto
        }
        [Test]
        public void RemovedRobot()
        {
            robotManager.Add(robot);
            robotManager.Add(new Robot("gogi", 50));
            robotManager.Remove("gogi");
            Assert.That(robotManager.Count, Is.EqualTo(1));
        }
        [Test]
        public void ConstructorShouldInitializeCorrectlyAllProperties()
        {
            int expectedCapacity = 5;
            int actualCapacity = this.robotManager.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
    }
}
