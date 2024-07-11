using Microsoft.AspNetCore.SignalR;
using QuestionnaireBack.Models;
using System;
using System.Threading.Tasks;

namespace QuestionnaireBack.Service
{
    public class QuestionmaireHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            string username = Context.User.Identity.Name;
            Console.WriteLine($"User connected: {username}");

            await base.OnConnectedAsync();
        }
        public  async Task AddToGroup(string groupName) {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
        public async Task SendMessage(QuestionRequest request, string groupName)
        {
            await Clients.Groups(groupName).SendAsync("ReceiveMessage",request.Name, request.Message, request.Rate);
            Console.WriteLine($"Cotnex: {request.Name} {request.Message} \n  ConnectionId : {Context.ConnectionId} \n  User: {Context.User.Identity.Name}  UserIdentifier: {Context.UserIdentifier}");
        }
    }
}
