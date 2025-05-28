using BooksApi.Models;
namespace BooksApi.Services
{
    public class BookService
    {

        private List<BookModel> _books;

        public BookService()
        {
            _books = new List<BookModel>();

        }

        // Adds a new book
        public void AddBook(BookModel book)
        {
            _books.Add(book);
        }

        // Gets all books
        public List<BookModel> GetAllBooks()
        {
            return _books;
        }

        // Gets a book by its ID
        public BookModel GetBookById(int id)
        {
            if(id <= 0)
            {
                throw new Exception("Invalid book ID provided");
            }

            return _books.Find(b => b.Id == id);
        }

        // Updates a book by its ID
        public void UpdateBook(int id ,BookModel updatedBook)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Description = updatedBook.Description;
                book.Price = updatedBook.Price;
            }
        }

        // Deletes a book by its ID
        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }

    }
}
