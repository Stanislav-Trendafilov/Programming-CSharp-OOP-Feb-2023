namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }

        [TearDown]
        public void TearDown()
        {
            database = null;
        }
        [Test]
        public void Test_AddPerson()
        {

            database.Add(new Person(12, "Ivan"));

            Assert.AreEqual(database.Count,1);
        }

        [Test]
        public void Test_AddPersonWithExistingName()
        {
            database.Add(new Person(12, "Ivan"));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(13, "Ivan")));
        }

        [Test]
        public void Test_AddPersonWithExistingID()
        {

            database.Add(new Person(12, "Ivan"));

            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(12, "Asen")));
        }

        [Test]
        public void Test_AddPersonInFullDatabase()
        {
            database.Add(new Person(1, "Ivan"));
            database.Add(new Person(2, "a"));
            database.Add(new Person(3, "b"));
            database.Add(new Person(4, "Honk"));
            database.Add(new Person(5, "c"));
            database.Add(new Person(6, "d"));
            database.Add(new Person(7, "e"));
            database.Add(new Person(8, "f"));
            database.Add(new Person(9, "g"));
            database.Add(new Person(10, "h"));
            database.Add(new Person(11, "i"));
            database.Add(new Person(12, "j"));
            database.Add(new Person(13, "k"));
            database.Add(new Person(14, "l"));
            database.Add(new Person(15, "m"));
            database.Add(new Person(16, "n"));


            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(1243, "Asencho")));
        }

        [Test]
        public void Test_RemovePersonFromAnEmptyBase() 
        { 
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void Test_RemovePerson()
        {
            database.Add(new Person(11, "Ivan"));
            database.Remove();

            Assert.AreEqual(database.Count, 0);
        }

        [Test]
        public void Test_FindNullString()
        {
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }

        [Test]
        public void Test_FindNonExistingPerson()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Ivan"));
        }

        [Test]
        public void Test_FindByUsernameFunction()
        {
           database.Add(new Person(11, "Gosho"));

            Assert.AreEqual(database.FindByUsername("Gosho").UserName, "Gosho");
        }

        [Test]
        public void Test_FindIdFunction()
        {
            database.Add(new Person(11, "Ivan"));

            Assert.AreEqual("Ivan", database.FindById(11).UserName);
        }

        [Test]
        public void Test_FindNonExistingId()
        {
            Assert.Throws<InvalidOperationException>(() => database.FindById(11));
        }

        [Test]
        public void Test_FindWithNegativeId()
        {
            database.Add(new Person(11, "Gosho"));

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));
        }


    }
}