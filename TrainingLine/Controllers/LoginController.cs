using Microsoft.AspNetCore.Mvc;
using TrainingLine.Models;
using TrainingLine.Repository;

namespace TrainingLine.Controllers
{
    public class ILoginController : Controller
    {
        public readonly ILoginRepository _LoginRepository;
        public ILoginController()
        {
                _LoginRepository = new LoginRepository();
        }
        public IActionResult Index()
        { 
            return View();
        }
        
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginDetails login)
        {
            var res = _LoginRepository.Validate(login.username,login.password);
            if (res == true)
            {
                return RedirectToAction("GetAllBooks","Book");
            }
            else
            {
                return Content("UserNotFound");
            }
        }
    }
}
