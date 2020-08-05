using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SearchFill.Controllers
{
    public class FreeController : Controller
    {
        // GET: FreeController
        public ActionResult Index()
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
