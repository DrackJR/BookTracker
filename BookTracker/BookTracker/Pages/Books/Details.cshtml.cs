using BookTracker.Data;
using BookTracker.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookTracker.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public IActionResult OnGet(int id)
        {
            Book = _context.Books
                .Where(c => c.Id == id)
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .FirstOrDefault();

            if (Book == null)
                return NotFound();

            return Page();
        }
    }
}
