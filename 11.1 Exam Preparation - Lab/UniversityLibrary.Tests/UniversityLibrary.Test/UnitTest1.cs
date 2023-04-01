namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    public class Tests
    {
        private UniversityLibrary libraly;
        private TextBook textBook;
        [SetUp]
        public void Setup()
        {
            libraly = new UniversityLibrary();
            textBook = new TextBook("Ha", "Vazow", "Horror");
        }

        [TearDown]
        public void TearDown()
        {
            libraly = null;
            textBook = null;
        }

        [Test]
        public void Test_UniversityConstructor()
        {
            Assert.AreEqual(0, libraly.Catalogue.Count);
        }

        [Test]
        public void Test_AddTextBookToLibrary()
        {
            var answer=libraly.AddTextBookToLibrary(textBook);

            Assert.AreEqual(1, libraly.Catalogue.Count);

            Assert.AreEqual(textBook.ToString(), answer);
        }

        [Test]
        public void Test_LoanBookWhichIsReturned()
        {
            libraly.AddTextBookToLibrary(textBook);

            Assert.AreEqual($"Ha loaned to Ivan.", libraly.LoanTextBook(1, "Ivan"));

            Assert.AreEqual("Ivan", textBook.Holder);
        }

        [Test]
        public void Test_LoanBookWhichIsntReturned()
        {
            libraly.AddTextBookToLibrary(textBook);

            libraly.LoanTextBook(1, "Ivan");

            Assert.AreEqual(libraly.LoanTextBook(1, "Ivan"), "Ivan still hasn't returned Ha!");
        }

        [Test]
        public void Test_ReturnBook()
        {
            libraly.AddTextBookToLibrary(textBook);

            string text=libraly.ReturnTextBook(1);

            Assert.AreEqual("Ha is returned to the library.", text);

            Assert.AreEqual(string.Empty, textBook.Holder);
        }
    }
}