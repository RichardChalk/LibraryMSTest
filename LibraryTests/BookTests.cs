using Library;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryTests
{
    [TestClass]
    public class BookTests
    {
        private readonly List<Book> _sut;
        public BookTests()
        {
            _sut = new List<Book>
            {
                new Book("12223","Nils Nilsson", "Fantastiska dikter"),
                new Book("55551234","Åsa Åsasson", "Mina bästa TV-spel")
            };
        }

        //1. att det inte går att låna en bok ifall alla är utlånade
        [TestMethod]
        public void Cannot_Loan_Book_If_All_Are_Loaned_ReturnsFalse()
        {
            // Arrange
            _sut[1].BuyNewEx(2);

            var borrower1 = "Richard";
            if (_sut[1].IsBorrower(borrower1) == false)
                _sut[1].Borrow(borrower1);

            var borrower2 = "Stefan";
            if (_sut[1].IsBorrower(borrower2) == false)
                _sut[1].Borrow(borrower2);

            var borrower3 = "No book left!";

            // Act
            bool result = _sut[1].Borrow(borrower3);

            // Assert
            // (expected , received)
            Assert.IsFalse(result);
        }

        //2. att man blir en borrower när man lånar en bok
        [TestMethod]
        public void Become_Borrower_When_Loaning_Book_ReturnsTrue()
        {
            // Arrange
            _sut[0].BuyNewEx(1);
            var borrower = "Richard";

            // Act
            bool result = false;
            if (_sut[0].IsBorrower(borrower) == false)
                result = _sut[0].Borrow(borrower);

            // Assert
            // (expected , received)
            Assert.IsTrue(result);
        }

        //3. att antalet ex ökar när man köper in nya exemplar
        [TestMethod]
        public void Number_Of_Books_Increases_When_Ordered()
        {
            // Arrange
            _sut[0].BuyNewEx(1);
            _sut[0].BuyNewEx(9);
            var expectedNumberOfBooks = 10; // 1 + 9

            // Act
            var result = _sut[0].Count;

            // Assert
            // (expected , received)
            Assert.AreEqual(expectedNumberOfBooks, result);
        }
    }
}