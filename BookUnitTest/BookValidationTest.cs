using ObligatoriskOpg1Sem3;

namespace BookUnitTest
{
    [TestClass]
    public class BookValidationTest
    {
        [TestMethod]
        public void ToStringTest()
        {
            //Arrange
            Book book = new Book {Id = 1, Title = "Dracula", Price = 100 };

            //Act
            string result = book.ToString();

            //Assert
            Assert.AreEqual("1 Dracula 100", result);
        }

        [TestMethod]
        public void ValidateTitleNullTest() 
        {
            //Arrange
            Book book = new Book { Id = 1, Title = null, Price = 100 };

            //Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => book.ValidateTitle());
        }

        [TestMethod]
        public void ValidateTitleCharTest()
        {
            //Arrange
            Book book = new Book {Id = 1, Title = "", Price = 100 };

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => book.ValidateTitle());
        }

        [TestMethod]
        public void ValidatePriceTest()
        {
            //Arrange
            Book book = new Book { Id = 1, Title = "Dracula", Price = 0 };

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => book.ValidatePrice());
        }

        [TestMethod]
        public void ValidateTitleMethodTest() 
        {
            //Arrange
            Book book = new Book {Id = 1, Title = "", Price = 100 };

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => book.Validate());
        }

        [TestMethod]
        public void ValidatePriceMethodTest()
        {
            //Arrange
            Book book = new Book {Id = 1, Title = "Dracula", Price = 0 };

            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => book.Validate());
        }

        [TestMethod]
        public void ValidateTitleAndPriceInput() 
        {
            //Arrange
            Book book = new Book {Id = 1, Title = "Harry Potter", Price = 120 };

            //Act & Assert
            Assert.IsTrue(book.ValidateTitle());
            Assert.IsTrue(book.ValidatePrice());
        }
    }
}