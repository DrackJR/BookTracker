using BookTracker.Model;
using Microsoft.AspNetCore.SignalR;

namespace BookTracker.Hubs
{
    public class BookHub : Hub
    {
        public async Task SendBookUpdate(Book book)
        {
            await Clients.All.SendAsync("BookUpdated", book);
        }
    }
}
