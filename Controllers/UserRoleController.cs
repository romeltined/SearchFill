using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authorization;
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
            var users = await _userManager.Users.Select(s => new UserRoleDTO { Guid=s.Id , Email = s.Email }).ToListAsync();
            return View(users);
        }


        [HttpGet]
        public async Task<ActionResult> Edit(string guid)
        {
            IdentityUser user = await _userManager.FindByIdAsync(guid);
            var allRoles = await _roleManager.Roles.ToListAsync();
            var roles = await _userManager.GetRolesAsync(user);
            UserRoleDTO userRoleDTO = new UserRoleDTO { Guid = user.Id, Email = user.Email };
            Dictionary<string, bool> dicRole = new Dictionary<string, bool>();
            foreach (var role in allRoles)
            {
                dicRole.Add(role.ToString(), roles.Contains(role.Name));
            }
            userRoleDTO.Roles = dicRole;

            return View(userRoleDTO);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator, Manager")]
        public async Task<ActionResult> Edit([Bind("guid,Role")] string guid, List<string> role)
        {
            IdentityUser user = await _userManager.FindByIdAsync(guid);
            var allRoles = await _roleManager.Roles.ToListAsync();

            foreach (var _role in allRoles)
            {
                if (role.Contains(_role.Name))
                {
                    await _userManager.AddToRoleAsync(user, _role.Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, _role.Name);
                };
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> CreateRole()
        {

            var roles = await _roleManager.Roles.ToListAsync();

            //var roleCheck = await _roleManager.RoleExistsAsync("Manager");
            //if (!roleCheck)
            //{
            //    //create the roles and seed them to the database
            //    await _roleManager.CreateAsync(new IdentityRole("Administrator"));
            //    await _roleManager.CreateAsync(new IdentityRole("Supervisor"));
            //    await _roleManager.CreateAsync(new IdentityRole("Manager"));
            //    await _roleManager.CreateAsync(new IdentityRole("User"));

            //}
          

            return View();
        }







    }
}
