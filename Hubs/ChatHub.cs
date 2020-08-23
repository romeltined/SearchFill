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
    public class ChatHub : Hub
    {
        private readonly SearchFillContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ChatHub(SearchFillContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SendMessage(string sender, string user, string message)
        {
            IdentityUser who = _userManager.FindByNameAsync(user).Result;

            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            //await Clients.Client(user).SendAsync("ReceiveMessage", sender, user, message);
            await Clients.User(who.Id).SendAsync("ReceiveMessage", sender, user, message);
        }

        //public async Task SendNotification(string who, string message)
        //{
        //    var user = _context.UserRs.Find(who);
        //    if (user == null)
        //    {
        //        await Clients.Caller.SendAsync("ReceiveMessage", "Admin", who, "Could not find that user.");
        //    }
        //    else
        //    {
        //        _context.Entry(user)
        //            .Collection(u => u.Connections)
        //            .Query()
        //            .Where(c => c.Connected == true)
        //            .Load();

        //        if (user.Connections == null)
        //        {
        //            await Clients.Caller.SendAsync("ReceiveMessage", "Admin", who, "The user is no longer connected.");
        //        }
        //        else
        //        {
        //            foreach (var connection in user.Connections)
        //            {
        //                await Clients.Client(connection.ConnectionID).SendAsync("ReceiveMessage", "Admin", who, message);
        //            }
        //        }
        //    }

            
        //}

        public override async Task OnConnectedAsync()
        {
            //var name = Context.User.Identity.Name;
 
            //var user = _context.UserRs.Include(u => u.Connections)
            //    .SingleOrDefault(u => u.UserName == name);

            //if (user == null)
            //{
            //    user = new UserR
            //    {
            //        UserName = name,
            //        Connections = new List<Connection>()
            //    };
            //    _context.UserRs.Add(user);
            //}

            //user.Connections.Add(new Connection
            //{
            //    ConnectionID = Context.ConnectionId,
            //    UserAgent = Context.GetHttpContext().Request.Headers["User-Agent"],
            //    Connected = true
            //});
            //_context.SaveChanges();
 
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            //await Groups.RemoveFromGroupAsync(Context.ConnectionId, "SignalR Users");

            //var connection = _context.Connections.Find(Context.ConnectionId);
            //connection.Connected = false;
            //await _context.SaveChangesAsync();

            await base.OnDisconnectedAsync(exception);
        }
        public string GetConnectionId()
        {
            //return Context.ConnectionId;
            //return Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return Context.User.Identity.Name;
        }
    }
}
