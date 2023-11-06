using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrainingLine.Models;
using TrainingLine.Repository;

namespace TrainingLine.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IBookRepository bookRepository,IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _webHostEnvironment = webHostEnvironment;
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
        [Route("AddNewBook")]
        [Authorize] //This is the data Annotation to Authorize user 
        public ViewResult AddNewBook()
        {
            return View();

        }
        [Route("AddNewBook")]
        [HttpPost]
        public async Task<IActionResult> AddNewBook(coverPhoto coverPhoto)
        {
            
            if(ModelState.IsValid)
            {
                if (coverPhoto != null)
                {
                    string folder = "books/cover/";
                    folder += Guid.NewGuid().ToString()+coverPhoto.CoverPhoto.FileName;
                    string server = Path.Combine(_webHostEnvironment.WebRootPath,folder);
                    await coverPhoto.CoverPhoto.CopyToAsync(new FileStream(server,FileMode.Create));

                    _bookRepository.AddBooks(coverPhoto);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(coverPhoto);
        }

        //Edit
        public IActionResult Edit(int id)
        {
            BookModel book = _bookRepository.GetDbBookId(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                if (bookModel != null)
                {
                    _bookRepository.EditBooks(bookModel);
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return Content("Error occured");
            }
            return View();
        }

        //Delete
        public IActionResult Delete(int id)
        {
            BookModel book = _bookRepository.GetDbDeleteBookId(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Delete(BookModel bookModel)
        {         
                if(bookModel != null)
                {
                    _bookRepository.DeleteBooks(bookModel);
                    return RedirectToAction("Index", "Home");
                }
            else
            {
                return Content("Error Occured");
            }
        }
    }
}
