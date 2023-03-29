using Library;

namespace LibraryTests
{
    [TestClass]
    public class BookTests
    {
        private readonly Book _sut;
        public BookTests()
        {
            _sut = new Book("123", "Test Author", "Test Title");
        }

        //1. att det inte går att låna en bok ifall alla är utlånade
        [TestMethod]
        public void Cannot_Loan_Book_If_All_Are_Loaned_ReturnsFalse()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book("12223","Nils Nilsson", "Fantastiska dikter"),
                new Book("55551234","Åsa Åsasson", "Mina bästa TV-spel")
            };

            books[1].BuyNewEx(2);

            var borrower1 = "Richard";
            if (books[1].IsBorrower(borrower1) == false)
                books[1].Borrow(borrower1);

            var borrower2 = "Stefan";
            if (books[1].IsBorrower(borrower2) == false)
                books[1].Borrow(borrower2);

            var borrower3 = "No book left!";

            // Act
            bool result = _sut.Borrow(borrower3);

            // Assert
            // (expected , received)
            Assert.IsFalse(result);
        }

        //2. att man blir en borrower när man lånar en bok
        [TestMethod]
        public void Become_Borrower_When_Loaning_Book_ReturnsTrue()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book("12223","Nils Nilsson", "Fantastiska dikter"),
                new Book("55551234","Åsa Åsasson", "Mina bästa TV-spel")
            };

            books[0].BuyNewEx(1);
            var borrower = "Richard";

            // Act
            bool result = false;
            if (books[0].IsBorrower(borrower) == false)
                result = books[0].Borrow(borrower);

            // Assert
            // (expected , received)
            Assert.IsTrue(result);
        }

        //3. att antalet ex ökar när man köper in nya exemplar
        [TestMethod]
        public void Number_Of_Books_Increases_When_Ordered()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book("12223","Nils Nilsson", "Fantastiska dikter"),
                new Book("55551234","Åsa Åsasson", "Mina bästa TV-spel")
            };

            books[0].BuyNewEx(1);
            books[0].BuyNewEx(9);
            var expectedNumberOfBooks = 10; // 1 + 9

            // Act
            var result = books[0].Count;

            // Assert
            // (expected , received)
            Assert.AreEqual(expectedNumberOfBooks, result);
        }
    }
}