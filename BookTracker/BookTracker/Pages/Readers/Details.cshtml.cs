using BookTracker.Data;
using BookTracker.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookTracker.Pages.Readers
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Reader Reader { get; set; }

        public IActionResult OnGet(int id)
        {
            Reader = _context.Readers.FirstOrDefault(s => s.Id == id);

            if (Reader == null)
                return NotFound();

            return Page();
        }
    }
}
