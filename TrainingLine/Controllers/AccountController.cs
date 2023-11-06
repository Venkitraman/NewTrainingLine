using Microsoft.AspNetCore.Mvc;
using TrainingLine.Models;
using TrainingLine.Repository;

namespace TrainingLine.Controllers
{
    public class AccountController : Controller
    {
        public readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        //Signup Action Method 
        [Route("signup")]
        public IActionResult signup()
        {
            return View();
        }
        //Signup Post Action Method
        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> signup(SighUpUserModel sighUpUser)
        {
            if(ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(sighUpUser);
                if (!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(sighUpUser); 
                }
                ModelState.Clear();
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        //Login Action Method
        [Route("login")]
        public IActionResult login()
        {
            return View();
        }
        //Login Post Action Method
        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> login(signIn signIn)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(signIn);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                //else
                //{
                //    ModelState.AddModelError("", "Invalid Credentials");
                //}
                
            }
            return View(signIn);
        }
        //Logout Action Method ,if logout it will redirect to HOME .
        [Route("logout")]
        public async Task<IActionResult> logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
