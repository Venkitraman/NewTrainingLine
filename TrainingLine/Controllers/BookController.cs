using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingLine.Models;
using TrainingLine.Repository;

namespace TrainingLine.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult GetAllBooks()
        {
            var data =  _bookRepository.GetAllBooks();
            return View(data);
        }

        public ViewResult GetBook(int Id)
        {
            var data = _bookRepository.GetBookById(Id);
            return View(data);
        }

        public List<BookModel> SearchBook(string name, string author) {
        
            return _bookRepository.SearchBooks(name, author);
        }
        [Authorize]
        public ViewResult AddNewBook()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNewBook(BookModel bookModel)
        {
            if(ModelState.IsValid)
            {
                if (bookModel != null)
                {
                    _bookRepository.AddBooks(bookModel);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return Content("Error occured");
            }
            return View();
        }
    }
}
