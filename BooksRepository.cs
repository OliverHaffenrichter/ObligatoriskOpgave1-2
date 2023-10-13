using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ObligatoriskOpgave1
{
    public class BooksRepository
    {
        private int _nextId = 1;
        private readonly List<Book> _books = new List<Book>()
        {
            //new Book() {Id = 1, Title = "Bird", Price = 117},
            //new Book() {Id = 2, Title = "Sun", Price = 109},
            //new Book() {Id = 3, Title = "Cave", Price = 125},
            //new Book() {Id = 4, Title = "Yard", Price = 148},
            //new Book() {Id = 5, Title = "Grapes", Price = 153},
        };

        public IEnumerable<Book> Get(int? MaxFilterPrice = null, int? MinFilterPrice = null, string? orderBy = null)
        {
            IEnumerable<Book> copy = new List<Book>(_books);

            if (MaxFilterPrice == null && MinFilterPrice != null)
            
            {
                copy = copy.Where(m => m.Price <= MinFilterPrice);
            }
            if (MaxFilterPrice != null && MinFilterPrice == null)
            {
                copy = copy.Where(m => m.Price >= MaxFilterPrice);
            }
            if (MaxFilterPrice != null && MinFilterPrice != null)
            {
                copy = copy.Where(m => m.Price >= MaxFilterPrice && m.Price <= MinFilterPrice);
            }
            if (MaxFilterPrice == null && MinFilterPrice == null)
            {
                return copy;
            }

            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "title":
                    case "title_asc":
                        copy = copy.OrderBy(m => m.Title);
                        break;
                    case "title_desc":
                        copy = copy.OrderByDescending(m => m.Title);
                        break;
                    case "price":
                    case "price_asc":
                        copy = copy.OrderBy(m => m.Price);
                        break;
                    case "price_desc":
                        copy = copy.OrderByDescending(m => m.Price);
                        break;
                    default:
                        throw new ArgumentException("Uknown" +  orderBy);
                        break;
                }
            }
            return copy;
        }

        public Book? GetById(int id)
        {
            if (id == null)
            {
                return null;
            }
            return _books.Find(book => book.Id == id);
        }


        public Book Add(Book book)
        {
            book.Validate();
            book.Id = _nextId++;
            _books.Add(book);
            return book;
        }

        public Book? Delete(int id)
        {
            Book? book = GetById(id);
            if (book == null)
            {
                return null;
            }
            _books.Remove(book);
            return book;
        }

        public Book? Update(int id, Book book)
        {
            book.Validate();
            Book? SameBook = GetById(id);
            if (SameBook == null)
            {
                return null;
            }
            SameBook.Title = book.Title;
            SameBook.Price = book.Price;
            return SameBook;
        }
    }
}
