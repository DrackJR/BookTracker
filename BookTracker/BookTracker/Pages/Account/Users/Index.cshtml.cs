using BookTracker.Data;
using BookTracker.Model.AuthApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Pages.Account.Users
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AuthUser> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _context.AuthUsers.ToListAsync();
        }
    }
}
