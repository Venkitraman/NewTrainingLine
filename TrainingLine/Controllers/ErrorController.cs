using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace TrainingLine.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var error = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.exceptionPath = error.Path;
            ViewBag.exceptionmessage = error.Error.Message;

            return View("Error");

        }
    }
}
