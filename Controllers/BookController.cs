using BooksApi.Models;
using BooksApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        // Add a new book
        [HttpPost]
        [Route("addBook")]
        public ActionResult AddBook(BookModel book)
        {
            this._bookService.AddBook(book);
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
        public ActionResult<BookModel> GetBooksById(int id)
        {
            var book = this._bookService.GetBookById(id);
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

    }
}
