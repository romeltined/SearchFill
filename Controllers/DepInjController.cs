using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SearchFill.Models;

namespace SearchFill.Controllers
{
    public class DepInjController : Controller
    {
        private readonly IOperationTransient operationTransient;
        private readonly IOperationScoped operationScoped;
        private readonly IOperationSingleton operationSingleton;
        public DepInjController (IOperationTransient operationTransient, IOperationScoped operationScoped, IOperationSingleton operationSingleton)
        {
            this.operationTransient = operationTransient;
            this.operationScoped = operationScoped;
            this.operationSingleton = operationSingleton;

        }
        // GET: DepInjController
        public ActionResult Index()
        {
            var depInj = new  Dictionary<string, string>();
            depInj.Add("Singleton",  operationSingleton.OperationId.ToString());
            depInj.Add("Transient", operationTransient.OperationId.ToString());
            depInj.Add("Scoped", operationScoped.OperationId.ToString());

            return View(depInj);
        }

        // GET: DepInjController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepInjController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepInjController/Create
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

        // GET: DepInjController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepInjController/Edit/5
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

        // GET: DepInjController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepInjController/Delete/5
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
