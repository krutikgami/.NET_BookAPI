using BookApi.Entites.Entites;
using BooksApi.Models;

namespace BooksApi.Services.Interfaces
{
    public interface IBookService
    {
        void AddBook(BookModel book);
        List<BookModel> GetAllBooks();
        BookModel GetBookById(int id);
        void UpdateBook(int id, BookModel updatedBook);
        void DeleteBook(int id);
        void DeleteAllBooks();
        Task InsertBook(BookDetails bookDetails);
        BookDetails GetBookDetailsById(int id);

    }
}
