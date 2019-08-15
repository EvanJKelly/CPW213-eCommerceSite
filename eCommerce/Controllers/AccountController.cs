using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.data;
using eCommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
   
   
    public class AccountController : Controller
    {
        /// <summary>
        /// provides access to session data for
        /// the current user
        /// </summary>
        private readonly GameContext _context;
        private readonly IHttpContextAccessor _httpContext;
        public AccountController(GameContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _httpContext = accessor;
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
               Member member =  await MemberDb.Add(_context, m);

                TempData["Message"] = "You registered sucessfully";
                //Create session for user
                HttpContext.Session.SetInt32("MemberId", 1);
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
               Member member = await MemberDb.IsLoginValid(model, _context);
                if (member != null){
                    TempData["Message"] = "Logged in successfully";
                    //Create session for user
                    _httpContext.HttpContext.Session.SetInt32("MemberId", member.MemberId);
                    _httpContext.HttpContext.Session.SetString("Username", member.UserName);
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