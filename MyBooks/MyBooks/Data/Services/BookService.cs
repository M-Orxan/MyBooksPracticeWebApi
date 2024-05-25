using MyBooks.Data.Models;
using MyBooks.Data.ViewModels;
using System.Threading;

namespace MyBooks.Data.Services
{
    public class BookService
    {
        private AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }


        public void AddBook(BookVM book)
        {
            Book _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead.Value : null,
                Author = book.Author,
                Genre = book.Genre,
                Rate = book.IsRead ? book.Rate.Value : null,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };

            _context.Books.Add(_book);
            _context.SaveChanges();
        }



        public List<Book> GetAllBooks() => _context.Books.ToList();



        public Book GetBookById(int id) => _context.Books.FirstOrDefault(x => x.Id == id);


        public Book UpdateBook(int id, BookVM newBook)
        {

            Book dbBbook = _context.Books.FirstOrDefault(x => x.Id == id);
            if (dbBbook != null)
            {
                dbBbook.Title = newBook.Title;
                dbBbook.Description = newBook.Description;
                dbBbook.IsRead = newBook.IsRead;
                dbBbook.DateRead = newBook.IsRead ? newBook.DateRead.Value : null;
                dbBbook.Author = newBook.Author;
                dbBbook.Genre = newBook.Genre;
                dbBbook.Rate = newBook.IsRead ? newBook.Rate.Value : null;
                dbBbook.CoverUrl = newBook.CoverUrl;

                _context.SaveChanges();
            }

            return dbBbook;

        }


        public void DeleteBookById(int id)
        {
          Book book=  _context.Books.FirstOrDefault(x => x.Id == id);

            _context.Remove(book);
            _context.SaveChanges();
        }



    }
}
