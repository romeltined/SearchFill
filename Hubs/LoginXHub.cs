using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
using SearchFill.Data;
using Microsoft.EntityFrameworkCore;
using SearchFill.Models;
using Microsoft.AspNetCore.Identity;

namespace SearchFill.Hubs
{
    public class LoginXHub : Hub
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public LoginXHub(UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task SendMessage(string email)
        {
            try
            {
                var val = email;
                IdentityUser user = await _userManager.FindByEmailAsync(email);
                await _signInManager.SignInAsync(user, true, null);
            }
            finally
            {

            }
        }
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
