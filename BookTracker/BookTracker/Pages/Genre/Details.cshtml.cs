using BookTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookTracker.Pages.Genre
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Model.Genre Genre { get; set; }

        public IActionResult OnGet(int id)
        {
            Genre = _context.Genres.FirstOrDefault(b => b.Id == id);

            if (Genre == null)
                return NotFound();

            return Page();
        }
    }
}
