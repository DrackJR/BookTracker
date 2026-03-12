using BookTracker.Data;
using BookTracker.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
            Book = _context.Books.FirstOrDefault(b => b.Id == id);

            if (Book == null)
                return NotFound();

            return Page();
        }
    }
}
