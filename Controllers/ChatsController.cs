using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SearchFill.Data;
using SearchFill.Hubs;

namespace SearchFill.Controllers
{
    public class ChatsController : Controller
    {

        private readonly IHubContext<ChatHub> _hubContext;
        private readonly SearchFillContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public ChatsController(IHubContext<ChatHub> hubContext, 
                                SearchFillContext context, 
                                UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager)
        {
            _context = context;   
            _hubContext = hubContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: ChatsController
        public ActionResult Index()
        {
            //var connectedUser = _context.UserRs
            //    .Where(u => u.Connections.Any())
            //    .Select(u => new
            //    {
            //        UserName = u.UserName,
            //        Connections = u.Connections.Where(c => c.Connected == true)
            //    })
            //    .Select(u => new { Username = u.UserName })
            //    .Distinct()
            //    .ToList();

            return View();
        }

        public ActionResult Send()
        {
            return View();
        }

        // POST: SportItemsController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Send([FromBody] string who, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {


                }
                return RedirectToAction(nameof(Send));
            }
            catch
            {
                return RedirectToAction(nameof(Send));
            }
        }

        // GET: ChatsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChatsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChatsController/Create
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

        // GET: ChatsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChatsController/Edit/5
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

        // GET: ChatsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChatsController/Delete/5
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
