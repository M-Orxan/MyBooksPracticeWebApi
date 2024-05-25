﻿using MyBooks.Data.Models;
using MyBooks.Data.ViewModels;

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
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead=book.IsRead ? book.DateRead.Value : null,
                Author=book.Author,
                Genre=book.Genre,
                Rate=book.IsRead? book.Rate.Value:null,
                CoverUrl=book.CoverUrl,
                DateAdded=DateTime.Now
            };

            _context.Books.Add(_book);
            _context.SaveChanges();
        }
    }
}