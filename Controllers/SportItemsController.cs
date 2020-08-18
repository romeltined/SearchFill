using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SearchFill.Data;
using SearchFill.Models;


namespace SearchFill.Controllers
{
    [Authorize(Roles ="Administrator,User")]
    public class SportItemsController : Controller
    {
        private readonly SearchFillContext _context;
        //private readonly UserManager<IdentityUser> _userManager;
        public SportItemsController(SearchFillContext context)
        {
            _context = context;
            
        }
        // GET: SportItemsController
        public async Task<IActionResult> Index()
        {

            //var user = _context.Users.Where(u => u.Email == "rstined@yahoo.com").FirstOrDefault();
            var currUser = User.IsInRole("User");

            var userRole = await (from user in _context.Users
                                 join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                                 join role in _context.Roles on userRoles.RoleId equals role.Id
                                 where user.Email == "rstined@yahoo.com"
                                 select new { UserId = user.Id, UserName = user.UserName, RoleId = role.Id, RoleName = role.Name })
                        .ToListAsync();

            return View(await _context.SportItems.ToListAsync());
        }

        // GET: SportItemsController/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sport = await _context.SportItems.Include(s=>s.Items)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (sport == null)
            {
                return NotFound();
            }

            return View(sport);
        }

        // GET: SportItemsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SportItemsController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] SportItemsDTO input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var sportItems = new List<Item>();
                    foreach(string x in input.Items)
                    {
                        var valueItem = new Item { ItemName = x};
                        sportItems.Add(valueItem);
                    }

                    var item = new SportItems { Sport = input.Sport, Items = sportItems };
                    _context.Add(item);
                    await _context.SaveChangesAsync();
                }
                return Ok("/SportItems/Index");
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: SportItemsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SportItemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SportItemsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SportItemsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
