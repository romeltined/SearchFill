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

namespace SearchFill.Hubs
{
    public class ChatHub : Hub
    {
   
        public async Task SendMessage(string sender, string user, string message)
        {
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            //await Clients.Client(user).SendAsync("ReceiveMessage", sender, user, message);
            await Clients.User(user).SendAsync("ReceiveMessage", sender, user, message);
        }

        public override async Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            var user = Context.User.Identity.Name; // Context.User is NULL
            var claimsprin = Context.User.Claims.ToList();

            await base.OnConnectedAsync();
        }

        public string GetConnectionId()
        {
            //return Context.ConnectionId;
            return Context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
