namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {

        [Test]
        public void Test_DatabaseCount()
        {
            Database database = new Database(1,2,3);

            Assert.AreEqual(database.Count, 3);
        }

        [Test]
        public void Test_DatabaseArraysCapacity()
        {
            Assert.Throws<InvalidOperationException>(()=> new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 2, 3, 4, 5, 6, 7,123,1));
        }

        [Test]
        public void Test_AddingElements()
        {
            Database db = new Database(1, 2);
            db.Add(2);
            Assert.AreEqual(3,db.Count );
        }

        [Test]
        public void Test_AddElementInFullDatabse()
        {
            Database database = 
                new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

            Assert.Throws<InvalidOperationException>(() => database.Add(17));

        }

        [Test]
        public void Test_RemovingElements()
        {
            Database db = new Database(1, 2);
            db.Remove();
            Assert.AreEqual(1, db.Count);
        }

        [Test]
        public void Test_RemoveElementFromEmptyDatabase()
        {
            Database database =
             new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());

        }

        [Test]
        public void Test_FetchMethod()
        {
            Database database = new Database(1, 2, 3);

            Assert.AreEqual(database.Count,database.Fetch().Length);
        }

    }
}
