using ModelsProject.Models;
using System;

namespace DataProject.Interfaces
{
    public interface IBookRepository
    {
        public ICollection<Book> GetBooks();

        public Book GetBookById(int bookId);

        public Book GetBookByTitle(string bookTitle);

        public ICollection<Book> GetBooksByPublisherId(int publisherId);

        public bool BookExists(int bookId);
    }
}
