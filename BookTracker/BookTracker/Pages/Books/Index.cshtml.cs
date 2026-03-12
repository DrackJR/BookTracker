using BookTracker.Data;
using BookTracker.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Book> Books { get; set; }

        public void OnGet()
        {
            Books = _context.Books
                .Include(s => s.Author)
                .Include(s => s.Genre)
                .ToList();
        }
    }
}
