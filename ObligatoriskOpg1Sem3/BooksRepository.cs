using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatoriskOpg1Sem3
{
    public class BooksRepository
    {
        private List<Book> books = new List<Book> 
        {
            new Book {Id = 1, Title = "Dracula", Price = 20},
            new Book {Id = 2, Title = "Don Quixote", Price = 25},
            new Book {Id = 3, Title = "War and Peace", Price = 30},
            new Book {Id = 4, Title = "The Great Gatsby", Price = 35},
            new Book {Id = 5, Title = "Hamlet", Price = 40},
        };

        //Method overloading
        //Default method
        public List<Book> Get() 
        {
            return books;
        } 

        //Price method
        public List<Book> Get(int price)
        {
            return books.FindAll(book => book.Price == price);        
        }

        //Title and Price method
        public List<Book> Get(string title, int price) 
        {
            return books.FindAll(book => book.Title == title && book.Price == price);        
        }


        public Book GetById(int id) 
        {
            return books.FirstOrDefault(x => x.Id == id);
        }

        public Book Add(Book book) 
        {
            if (book == null) 
            {
                throw new ArgumentNullException("Book can't be null");
            }
            book.Id = books.Count > 0 ? books.Max(x => x.Id) + 1 : 1;
            books.Add(book);
            return book;
        }

        public Book Delete(int id)
        {
            Book book = GetById(id);
            if (book != null)
            {
                books.Remove(book);
            }
            return book;
        }

        public Book Update(int id, Book info) {
            Book book = GetById(id);
            if (book != null)
            {
                book.Title = info.Title;
                book.Price = info.Price;
            }
            return book;
        }
    }
}
