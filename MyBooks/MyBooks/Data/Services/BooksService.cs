using MyBooks.Data.Models;
using MyBooks.Data.ViewModels;
using System.Threading;

namespace MyBooks.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }


        public void AddBookWithAuthor(BookVM bookVM)
        {
            Book book = new Book()
            {
                Title = bookVM.Title,
                Description = bookVM.Description,
                IsRead = bookVM.IsRead,
                DateRead = bookVM.IsRead ? bookVM.DateRead.Value : null,
                Genre = bookVM.Genre,
                Rate = bookVM.IsRead ? bookVM.Rate.Value : null,
                CoverUrl = bookVM.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = bookVM.PublisherId
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            foreach (int id in bookVM.AuthorIds)
            {
                Book_Author book_Author = new Book_Author()
                {

                    AuthorId = id,
                    BookId = book.Id
                };

                _context.Books_Authors.Add(book_Author);
                _context.SaveChanges();
            }
        }



        public List<Book> GetAllBooks() => _context.Books.ToList();



        public BookWithAuthorsVM GetBookById(int id)
        {
            BookWithAuthorsVM bookWithAuthors = _context.Books.Where(n=>n.Id==id).Select(n => new BookWithAuthorsVM
            {
                Title = n.Title,
                Description = n.Description,
                IsRead = n.IsRead,
                DateRead = n.IsRead ? n.DateRead.Value : null,
                Genre = n.Genre,
                Rate = n.IsRead ? n.Rate.Value : null,
                CoverUrl = n.CoverUrl,

                PublisherName = n.Publisher.Name,
                AuthorNames = n.Book_Authors.Select(b => b.Author.FullName).ToList()
            }).FirstOrDefault() ;

            return bookWithAuthors;
        }


        public Book UpdateBook(int id, BookVM newBook)
        {

            Book dbBbook = _context.Books.FirstOrDefault(x => x.Id == id);
            if (dbBbook != null)
            {
                dbBbook.Title = newBook.Title;
                dbBbook.Description = newBook.Description;
                dbBbook.IsRead = newBook.IsRead;
                dbBbook.DateRead = newBook.IsRead ? newBook.DateRead.Value : null;
               
                dbBbook.Genre = newBook.Genre;
                dbBbook.Rate = newBook.IsRead ? newBook.Rate.Value : null;
                dbBbook.CoverUrl = newBook.CoverUrl;

                _context.SaveChanges();
            }

            return dbBbook;

        }


        public void DeleteBookById(int id)
        {
            Book book = _context.Books.FirstOrDefault(x => x.Id == id);

            _context.Remove(book);
            _context.SaveChanges();
        }



    }
}
