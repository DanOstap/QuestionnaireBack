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
            string username = Context.ConnectionId;
            Console.WriteLine($"User connected: {username}");

            await base.OnConnectedAsync();
        }
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            Console.WriteLine($"User: {Context.ConnectionId} connected to room: {groupName}");
        }
        public async Task SendMessage(QuestionRequest request, string groupName,string role)
        {
            if (role == "hr") {
                await Clients.Groups(groupName).SendAsync("ReceiveMessage",request.Message, request.Rate);

            }
            await Clients.Groups(groupName).SendAsync("ReceiveMessage", request.Name, request.Message, request.Rate);

        }
    }
}
