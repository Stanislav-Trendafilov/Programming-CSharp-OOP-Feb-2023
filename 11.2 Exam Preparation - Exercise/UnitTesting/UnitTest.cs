using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;
        [SetUp]
        public void Setup()
        {
            hotel = new Hotel("Alba", 4);
        }

        [TearDown]
        public void TearDown()
        {
            hotel = null;
        }

        [Test]
        public void Test_HotelConstructorSettingRightValues()
        {
            Assert.AreEqual("Alba", hotel.FullName);
            Assert.AreEqual(4, hotel.Category);
            Assert.AreEqual(0, hotel.Bookings.Count);
            Assert.AreEqual(0, hotel.Rooms.Count);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void Test_SettingInvalidFullNameShouldThrowException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(name, 4));
        }


        [Test]
        [TestCase(0)]
        [TestCase(6)]
        public void Test_CategoryShouldBeBetween1And5(int num)
        {
            Assert.Throws<ArgumentException>(() => new Hotel("Sun palace", num));
        }

        [Test]
        public void Test_MethodAdd()
        {
            hotel.AddRoom(new Room(3, 50));

            Assert.AreEqual(1, hotel.Rooms.Count);
        }


        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void Test_BookedRoomedCannotBeWithNegativeCountAdults(int num)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(num, 1, 2, 399));
        }


        [Test]
        [TestCase(-20)]
        [TestCase(-1)]
        public void Test_BookedRoomedCannotBeWithNegativeCountchildren(int num)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(3, num, 2, 399));
        }


        [Test]
        [TestCase(-10)]
        [TestCase(0)]
        public void Test_BookedRoomed_ResidenceCannotBeLowerThan1(int num)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(3, 1, num, 399));
        }

        [Test]
        public void Test_BookedRoomed()
        {
            hotel.AddRoom(new Room(3, 100));
            hotel.BookRoom(2, 1, 3, 1200);

            Assert.AreEqual(1, hotel.Bookings.Count);
            Assert.AreEqual(300, hotel.Turnover);
        }

    }
}