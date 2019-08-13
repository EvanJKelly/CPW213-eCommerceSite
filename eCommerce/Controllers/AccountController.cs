using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
   
   
    public class AccountController : Controller
    {
        private readonly GameContext _context;
        public AccountController(GameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Member m)
        {
            if (ModelState.IsValid)
            {
                await MemberDb.Add(_context, m);

                TempData["Message"] = "You registered sucessfully";
                return RedirectToAction("Index", "Home");
            }

            return View(m);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
               bool isMember = await MemberDb.IsLoginValid(model, _context);
                if (isMember){
                    TempData["Message"] = "Logged in successfully";
                    return RedirectToAction("Index", "Home");
                }
                else//Credentials invalid
                {
                    //Adding model error with no key, will display error
                    //message in the validation summary
                    ModelState.AddModelError("BadCredentials", "i'm sorry, your credential did not match any record in our database");
                }

            }
            return View(model);
        }
        
    }
}