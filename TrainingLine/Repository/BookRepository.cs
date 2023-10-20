using Microsoft.EntityFrameworkCore;
using TrainingLine.Models;

namespace TrainingLine.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _dbcontext = null;
        public BookRepository(BookDbContext bookDbContext)
        {
            _dbcontext = bookDbContext;
        }
        
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public List<BookModel> GetAllDbBooks()
        {
            List<BookModel> bookList = _dbcontext.Book.ToList();
            return bookList;
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBooks(string Title, string Author)
        {
            return DataSource().Where(x => x.Title.Contains(Title) || x.Author.Contains(Author)).ToList();
        }

        public void AddBooks(BookModel books)
        {
            if (books != null)
            {
                _dbcontext.Book.Add(books);
                _dbcontext.SaveChanges();
            }
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>
            {
                new BookModel(){Id=1,Title="MVC",Author="Mallu",Description="Model View Controller is a type to develope .Net Application",Category="Education",Total_Pages=1001,Language="English"},
                new BookModel(){Id=2,Title=".Net",Author="Siddhu",Description=".Net is a framework used to develope fullstack application.",Category="Fixion",Total_Pages=2001,Language="Chinese"},
                new BookModel(){Id=3,Title="Python",Author="Gowthu",Description="Python is a fast growing technology used in AI etc...",Category="Romantic drama",Total_Pages=3001,Language="Malayalam"},
                new BookModel(){Id=4,Title="Mern",Author="Alfi",Description="MongoDB , ExpressJS , ReactJS , NodeJS it is a fullstack development !!!",Category="Modaling",Total_Pages=4001,Language="English"}
            };
        }
    }
}
