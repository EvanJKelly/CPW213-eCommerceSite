using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.data;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class LibraryController : Controller
    {
        private GameContext _context;

        public LibraryController(GameContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<VideoGame> allGames = 
                 await VideoGameDB.GetAllGames(_context);
            return View(allGames);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(VideoGame game)
        {
            if (ModelState.IsValid)
            {
                //Add to database
                await VideoGameDB.AddAsync(game, _context);
                return RedirectToAction("Index");
            }
            //Return view with model including error messages
            return View(game);
        }

        public async Task<IActionResult> Update(int id)
        {
            VideoGame game =
                await VideoGameDB.GetGameById(id, _context);

            return View(game);
        }
    }
}