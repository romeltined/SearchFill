using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SearchFill.Data;

namespace SearchFill.Controllers
{
    public class FreeController : Controller
    {

        private readonly SearchFillContext _context;

        public FreeController(SearchFillContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CountryPartial(string search)
        {
  
            var result = await _context.Country.Where(c => c.Name.Contains(search)).ToListAsync();

            return PartialView("_CountryPartial", result);
        }

        // GET: FreeController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rows()
        {
            return View();
        }

        // GET: FreeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FreeController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult ModelBind()
        {
            return View();
        }

        // POST: FreeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: FreeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FreeController/Edit/5
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

        // GET: FreeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FreeController/Delete/5
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
