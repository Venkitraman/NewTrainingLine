using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrainingLine.Models;
using TrainingLine.Repository;

namespace TrainingLine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookRepository _bookRepository;
        public HomeController(IBookRepository bookRepository, ILogger<HomeController> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var bookList = _bookRepository.GetAllDbBooks();
            return View(bookList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}