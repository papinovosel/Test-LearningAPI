using DataProject.Data;
using DataProject.Interfaces;
using ModelsProject.Models;
using System;

namespace DataProject.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }


        public bool BookExists(int bookId)
        {
            return _context.Books.Any(b => b.Id == bookId);
        }

        public Book GetBookById(int bookId)
        {
            return _context.Books.FirstOrDefault(b => b.Id == bookId);
        }

        public Book GetBookByTitle(string bookTitle)
        {
            return _context.Books.FirstOrDefault(b => b.Title == bookTitle);
        }

        public ICollection<Book> GetBooks()
        {
            return _context.Books.ToList();
        }

        public ICollection<Book> GetBooksByPublisherId(int publisherId)
        {
            return _context.Books.Where(b => b.PublisherId == publisherId).ToList();
        }
    }
}
