using TrainingLine.Models;

namespace TrainingLine.Repository
{
    public interface IBookRepository
    {
        List<BookModel> GetAllBooks();
        BookModel GetBookById(int id);
        List<BookModel> SearchBooks(string Title, string Author);
        void AddBooks(BookModel book);
        List<BookModel> GetAllDbBooks();
    }
}