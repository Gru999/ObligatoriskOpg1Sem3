using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObligatoriskOpg1Sem3;

namespace BookUnitTest
{
    [TestClass]
    public class BooksRepositoryTest
    {
        [TestMethod]
        public void AddBookTest()
        {
            //Arrange
            BooksRepository booksRepository = new BooksRepository();
            Book book = new Book{Id = 1, Title = "Harry Potter", Price = 120};

            //Act
            Book newBook = booksRepository.Add(book);

            //Assert
            Assert.IsNotNull(newBook);
            Assert.AreEqual(book.Id, newBook.Id);
            Assert.AreEqual(book.Title, newBook.Title);
            Assert.AreEqual(book.Price, newBook.Price);
        }

        [TestMethod]
        public void GetBookTest()
        {
            //Can be modified to check the other overloads

            //Arrange
            BooksRepository booksRepository = new BooksRepository();
            booksRepository.Add(new Book { Id = 1, Title = "Harry Potter", Price = 120 });
            booksRepository.Add(new Book { Id = 2, Title = "Lord of the Rings", Price = 150 });
            booksRepository.Add(new Book { Id = 3, Title = "The Hobbit", Price = 200 });

            //Act
            var requestedBooks = booksRepository.Get();

            //Assert
            Assert.IsNotNull(requestedBooks);

                //The 3 books we just added and the 5 books that gets added when the repo is instantiated
            Assert.AreEqual(8, requestedBooks.Count);
        }

        [TestMethod]
        public void DeleteBookTest()
        {
            //Arrange
            BooksRepository booksRepository = new BooksRepository();
            Book book = new Book { Id = 1, Title = "Harry Potter", Price = 120 };
            booksRepository.Add(book);

            //Act
            Book deletedBook = booksRepository.Delete(book.Id);

            //Assert
            Assert.IsNotNull(deletedBook);
            Assert.AreEqual(book.Id, deletedBook.Id);
            Assert.AreEqual(book.Title, deletedBook.Title);
            Assert.AreEqual(book.Price, deletedBook.Price);
        }

        [TestMethod]
        public void GetBooksByPrice()
        {
            //Arrange
            BooksRepository booksRepository = new BooksRepository();
            booksRepository.Add(new Book { Id = 1, Title = "Harry Potter", Price = 120 });
            booksRepository.Add(new Book { Id = 2, Title = "Lord of the Rings", Price = 150 });
            booksRepository.Add(new Book { Id = 3, Title = "The Hobbit", Price = 200 });
            booksRepository.Add(new Book { Id = 4, Title = "Frankenstein", Price = 120 });

            //Act
            var requestedBooks = booksRepository.Get(120);

            //Assert
            Assert.IsNotNull(requestedBooks);
            Assert.AreEqual(2, requestedBooks.Count);
        }

        [TestMethod]
        public void GetBooksByTitleAndPrice() 
        {
            //Arrange
            BooksRepository booksRepository = new BooksRepository();
            booksRepository.Add(new Book { Id = 1, Title = "Harry Potter", Price = 120 });
            booksRepository.Add(new Book { Id = 2, Title = "Lord of the Rings", Price = 150 });
            booksRepository.Add(new Book { Id = 3, Title = "The Hobbit", Price = 200 });
            booksRepository.Add(new Book { Id = 4, Title = "Harry Potter", Price = 120 });

            //Act
            var requestedBooks = booksRepository.Get("Harry Potter", 120);

            //Assert
            Assert.IsNotNull(requestedBooks);
            Assert.AreEqual(2, requestedBooks.Count);
            Assert.AreEqual("Harry Potter", requestedBooks[0].Title);
            Assert.AreEqual(120, requestedBooks[0].Price);
        }

        [TestMethod]
        public void UpdateBook() 
        {
            //Arrange
            BooksRepository booksRepository = new BooksRepository();
            booksRepository.Add(new Book { Id = 1, Title = "Harry Potter", Price = 120 });
            Book updateInfo = new Book { Id = 1, Title = "Frankenstein", Price= 200 };

            //Act
            Book updateBook = booksRepository.Update(1, updateInfo);

            //Assert
            Assert.IsNotNull(updateBook);
            Assert.AreEqual(updateInfo.Title, updateBook.Title);
            Assert.AreEqual(updateInfo.Price, updateBook.Price);            
        }
    }
}
