using BookTracker.Data;
using BookTracker.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookTracker.Pages.Author
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Model.Author Author { get; set; }

        public IActionResult OnGet(int id)
        {
            Author = _context.Authors.FirstOrDefault(b => b.Id == id);

            if (Author == null)
                return NotFound();

            return Page();
        }
    }
}
