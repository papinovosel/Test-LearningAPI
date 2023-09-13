using DataProject.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsProject.Dto;
using ModelsProject.Models;

namespace LearningAPI
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            ICollection<Book> books = _repository.GetBooks();

            List<BookDto> booksDto = new List<BookDto>();

            foreach (Book book in books)
            {
                booksDto.Add(new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    PublisherId = book.PublisherId
                });
            }

            return Ok(booksDto);
        }

        [HttpGet("/id")]
        public IActionResult GetBookById(int bookId)
        {
            if (!_repository.BookExists(bookId))
            {
                return NotFound("Book with that id not found");
            }

            Book book = _repository.GetBookById(bookId);

            BookDto bookDto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                PublisherId = book.PublisherId
            };

            return Ok(book);
        }

        [HttpGet("/publisher/id")]
        public IActionResult GetBooksByPublisherId(int publisherId)
        {
            if (_repository.GetBooksByPublisherId(publisherId) == null)
            {
                return NotFound("Publisher with that id not found");
            }

            ICollection<Book> books = _repository.GetBooksByPublisherId(publisherId);

            List<BookDto> booksDto = new List<BookDto>();

            foreach (Book book in books)
            {
                booksDto.Add(new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    PublisherId = book.PublisherId
                });
            }

            return Ok(books);
        }

        [HttpGet("/title")]
        public IActionResult GetBookByTitle(string title)
        {
            Book book = _repository.GetBookByTitle(title);

            if (book == null)
            {
                return NotFound("Book with that name not found");
            }

            BookDto bookDto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                PublisherId = book.PublisherId
            };

            return Ok(book);
        }
    }
}
