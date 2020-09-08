using BookStore.Data.Entity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Data.Repositories
{
    public class BookRepository
    {
        private BookStoreDBContext _context;
        public BookRepository(BookStoreDBContext context)
        {
            _context = context;

            if (!_context.Books.Any())
            {
                _context.Books.Add(new Books
                {
                    Id = 1,
                    Author = "tac gia A",
                    BookName = "Sach A",
                    Publisher = "Kim dong"
                });
                _context.Books.Add(new Books
                {
                    Id = 1,
                    Author = "tac gia B",
                    BookName = "Sach B",
                    Publisher = "Kim dong"
                });
                _context.Books.Add(new Books
                {
                    Id = 1,
                    Author = "tac gia C",
                    BookName = "Sach C",
                    Publisher = "Kim dong"
                });
                _context.Books.Add(new Books
                {
                    Id = 1,
                    Author = "tac gia D",
                    BookName = "Sach D",
                    Publisher = "Kim dong"
                });
            }
        }

        public void Add(Books books)
        {
            _context.Add(books);
            _context.SaveChanges();
        }
        public IEnumerable<Books> Getlist()
        {
            return _context.Books.ToList();
        }
        public Books Detail(int id)
        {
            return _context.Books.FirstOrDefault(a => a.Id == id);
        }
    }
}
