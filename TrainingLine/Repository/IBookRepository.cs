using TrainingLine.Models;

namespace TrainingLine.Repository
{
    public interface IBookRepository
    {
        List<BookModel> GetAllBooks();
        BookModel GetBookById(int id);
        List<BookModel> SearchBooks(string Title, string Author);
        void AddBooks(coverPhoto coverPhoto);
        List<BookModel> GetAllDbBooks();
        void EditBooks(BookModel book);
        BookModel GetDbBookId(int id);
        BookModel GetDbDeleteBookId(int id);
        void DeleteBooks(BookModel book);

    }
}