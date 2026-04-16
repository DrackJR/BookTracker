using BookTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookTracker.Pages.Genre
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.Genre Genre { get; set; }

        public IActionResult OnGet(int id)
        {
            Genre = _context.Genres.FirstOrDefault(b => b.Id == id);

            if (Genre == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Genres.Update(Genre);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
