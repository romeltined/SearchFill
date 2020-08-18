using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SearchFill.Data;
using SearchFill.Models;

namespace SearchFill.Controllers
{
    public class UserRoleController : Controller
    {
        
        private readonly SearchFillContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleController(SearchFillContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        // GET: UserRoleController
        public async Task<ActionResult> Index()
        {
            var users = await _userManager.Users.Select(s => new UserRoleDTO { Email = s.Email }).ToListAsync();
            return View(users);
        }

        // GET: UserRoleController/Details/5
        [HttpGet]
        public async Task<ActionResult> UserRoles(string email)
        {
            var qry = Request.QueryString; // ("email").ToString();
            IdentityUser user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);
            UserRoleDTO userRoleDTO = new UserRoleDTO();
            Dictionary<string, string> dicRole = new Dictionary<string, string>();
            userRoleDTO.Email = user.Email;
            foreach(var role in roles)
            {
                dicRole.Add(role.ToString(), "1");
            }
            userRoleDTO.Roles = dicRole;
            return View(userRoleDTO);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string email)
        {
            var qry = Request.QueryString; // ("email").ToString();
            IdentityUser user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);
            UserRoleDTO userRoleDTO = new UserRoleDTO();
            Dictionary<string, string> dicRole = new Dictionary<string, string>();
            userRoleDTO.Email = user.Email;
            foreach (var role in roles)
            {
                dicRole.Add(role.ToString(), "1");
            }
            userRoleDTO.Roles = dicRole;
            return View(userRoleDTO);
        }

        [HttpPost]
        public async Task<ActionResult> EditRole(string email, IFormCollection form)
        {
            var qry = Request.QueryString; // ("email").ToString();
            var formlist = Request.Form.ToList();
            IdentityUser user = await _userManager.FindByEmailAsync(email);
            var roles = await _userManager.GetRolesAsync(user);
            UserRoleDTO userRoleDTO = new UserRoleDTO();
            Dictionary<string, string> dicRole = new Dictionary<string, string>();
            userRoleDTO.Email = user.Email;
            foreach (var role in roles)
            {
                dicRole.Add(role.ToString(), "1");
            }
            userRoleDTO.Roles = dicRole;
            return View(userRoleDTO);
        }

        [HttpGet]
        public async Task<ActionResult> CreateRole()
        {

            //var roles = await _roleManager.Roles.ToListAsync();

            //var roleCheck = await _roleManager.RoleExistsAsync("Manager");
            //if (!roleCheck)
            //{
            //    //create the roles and seed them to the database
            //    await _roleManager.CreateAsync(new IdentityRole("Administrator"));
            //    await _roleManager.CreateAsync(new IdentityRole("Supervisor"));
            //    await _roleManager.CreateAsync(new IdentityRole("Manager"));
            //    await _roleManager.CreateAsync(new IdentityRole("User"));

            //}

            IdentityUser user = await _userManager.FindByEmailAsync("rstined@gmail.com");
            await _userManager.AddToRoleAsync(user, "Manager");
            var userRoles = await _userManager.GetRolesAsync(user);
            

            return View();
        }

        // POST: UserRoleController/Create
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

        // GET: UserRoleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserRoleController/Edit/5
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

        // GET: UserRoleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserRoleController/Delete/5
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
