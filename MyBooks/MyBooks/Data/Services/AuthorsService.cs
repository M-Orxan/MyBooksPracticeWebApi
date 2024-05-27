using Microsoft.AspNetCore.Mvc;
using MyBooks.Data.Models;
using MyBooks.Data.ViewModels;

namespace MyBooks.Data.Services
{
    public class AuthorsService
    {

        private AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }


        public void AddAuthor(AuthorVM authorVM)
        {
            Author author = new Author()
            {
                FullName = authorVM.FullName,
            };

            _context.Authors.Add(author);
            _context.SaveChanges();
        }


        public List<Author> GetAllAuthors() => _context.Authors.ToList();
        public AuthorWithBooksVM GetAuthorById(int id)
        {
            AuthorWithBooksVM authorWithBooks = _context.Authors.Select(n => new AuthorWithBooksVM
            {
                FullName = n.FullName,
                BookNames = n.Book_Authors.Select(n => n.Book.Title).ToList()

            }).FirstOrDefault();

            return authorWithBooks;



        }



        public Author UpdateAuthorById(int id, AuthorVM newAuther)
        {
            Author dbAuthor = _context.Authors.FirstOrDefault(x => x.Id == id);

            if (dbAuthor != null)
            {
                dbAuthor.FullName = newAuther.FullName;
            }
            _context.SaveChanges();


            return dbAuthor;
        }


        public void DeletAuthorById(int id)
        {
            Author dbAuthor = _context.Authors.FirstOrDefault(x => x.Id == id);
            if (dbAuthor != null)
            {
                _context.Authors.Remove(dbAuthor);
                _context.SaveChanges();
            }



        }



    }
}
