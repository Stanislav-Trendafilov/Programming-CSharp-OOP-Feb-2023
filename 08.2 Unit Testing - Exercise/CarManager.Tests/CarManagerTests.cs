namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }

        [Test]
        public void Test_ConstructorMake()
        {
            Car car= new Car("BMW", "X6", 20, 20);

            Assert.AreEqual("BMW",car.Make);
        }

        [Test]
        public void Test_ConstructorModel()
        {
            Car car = new Car("BMW", "X6", 20, 20);

            Assert.AreEqual("X6", car.Model);
        }

        [Test]
        public void Test_ConstructorFuelConsumption()
        {
            Car car = new Car("BMW", "X6", 20, 20);

            Assert.AreEqual(20, car.FuelConsumption);
        }

        [Test]
        public void Test_ConstructorFuelCapacity()
        {
            Car car = new Car("BMW", "X6", 20, 20);

            Assert.AreEqual(20, car.FuelCapacity);
        }



        [Test]
        public void Test_CreatingCarWithNullMake()
        {
            Assert.Throws<ArgumentException>(() => new Car(null, "BMW", 20, 20));
        }

        [Test]
        public void Test_CreatingCarWithEmptyMake()
        {
            Assert.Throws<ArgumentException>(() => new Car(string.Empty, "BMW", 20, 20));
        }

        [Test]
        public void Test_CreatingCarWithNullModel()
        {
            Assert.Throws<ArgumentException>(() => new Car("BmW", null, 20, 20));
        }

        [Test]
        public void Test_CreatingCarWithEmptyModel()
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", string.Empty, 20, 20));
        }

        [Test]
        public void Test_CarFuelAmount()
        {
            Car car = new Car("B", "M", 10, 10);

            Assert.AreEqual(0,car.FuelAmount);
        }

        [Test]
        public void Test_CreatingCarWithZeroFuelConsumption()
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X6", 0, 50));
        }
        [Test]
        public void Test_CreatingCarWithNegativeFuelConsumption()
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X6", -1, 50));
        }

        [Test]
        public void Test_CreatingCarWithZeroFuelCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X6", 20, 0));
        }
        [Test]
        public void Test_CreatingCarWithNegativeFuelCapacity()
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X6", 20, -1));
        }

        [Test]
        public void Test_RefuelWithZeroFuel()
        {
            Car car = new Car("B", "M", 11, 11);
            Assert.Throws<ArgumentException>(() => car.Refuel(0));
        }

        [Test]
        public void Test_RefuelWithNegativeFuel()
        {
            Car car = new Car("B", "M", 11, 11);
            Assert.Throws<ArgumentException>(() => car.Refuel(-10));
        }

        [Test]
        public void Test_RefuelMethod()
        {
            Car car = new Car("B", "M", 15, 20);
            car.Refuel(10);

            Assert.AreEqual(10, car.FuelAmount);
        }

        [Test]
        public void Test_RefuelWithMoreFuelThanCapacity()
        {
            Car car = new Car("B", "M", 15, 10);
            car.Refuel(25);

            Assert.AreEqual(10, car.FuelAmount);
        }

        [Test]
        public void Test_DriveDistance()
        {
            Car car = new Car("B", "M", 10, 20);

            car.Refuel(100);

            car.Drive(100);

            Assert.AreEqual(10,car.FuelAmount);
        }

        [Test]
        public void Test_DriveDistanceWithoutEnoughFuel()
        {
            Car car = new Car("B", "M", 10, 20);

            Assert.Throws<InvalidOperationException>(() => car.Drive(200));
        }
    }
}