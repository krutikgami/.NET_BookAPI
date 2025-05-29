using BookApi.Entites.Entites;
using BooksApi.Models;
using BooksApi.Services;
using BooksApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // Add a new book
        [HttpPost]
        [Route("addBook")]
        public async Task<ActionResult> AddBook(List<BookDetails> bookDetails)
        {
            foreach (var book in bookDetails)
            {
               await _bookService.InsertBook(book);
            }
            return Ok("Book added successfully");
        }

        // Get all books
        [HttpGet]
        [Route("getAllBooks")]
        public ActionResult<List<BookModel>> GetAllBooks()
        {
            var books = this._bookService.GetAllBooks();
            return Ok(books);
        }

        // Get a book by its Id
        [HttpGet]
        [Route("getBookById")]
        public ActionResult<BookDetails> GetBooksById(int id)
        {
            var book = _bookService.GetBookDetailsById(id);
            return Ok(book);
        }

        // Update a book by its Id
        [HttpPut]
        [Route("updateBook")]
        public ActionResult UpdateBook(int id, BookModel updatedBook)
        {
            this._bookService.UpdateBook(id, updatedBook);
            return Ok("Book updated successfully");
        }

        // Delete a book by its Id
        [HttpDelete]
        [Route("deleteBook")]
        public ActionResult DeleteBook(int id)
        {
            this._bookService.DeleteBook(id);
            return Ok("Book deleted successfully");
        }

        // Delete All book at a time
        [HttpDelete]
        [Route("deleteAllBooks")]
        public ActionResult DeleteAllBooks()
        {
            this._bookService.DeleteAllBooks();
            return Ok("All Books Deleted Successfully");
        }

    }
}
