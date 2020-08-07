using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SearchFill.Data;
using SearchFill.Models;

namespace SearchFill.Controllers
{
    public class SportItemsController : Controller
    {
        private readonly SearchFillContext _context;

        public SportItemsController(SearchFillContext context)
        {
            _context = context;
        }
        // GET: SportItemsController
        public async Task<IActionResult> Index()
        {
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
