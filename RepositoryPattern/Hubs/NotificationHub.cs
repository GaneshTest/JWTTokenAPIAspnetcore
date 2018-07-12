using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Hubs
{
    public class NotificationHub : Hub
    {
        public Task SendMessageToGroups()
        {
            List<string> groups = new List<string>() { "Ganesh" };
            var message = new Notification
            {
                Id = 1,
                NotificationText = "Notification text",
                NotificationTitle = "Hi",
                CreatedDateTime = DateTime.Now
            };
            return Clients.Groups(groups).SendAsync("ReceiveMessage", "Ganesh", message);
        }
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Ganesh");
            await base.OnConnectedAsync();
        }

    }
    public class Notification
    {
        public int Id { get; set; }
        public string NotificationText { get; set; }

        public string NotificationTitle { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
