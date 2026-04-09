using BookTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookTracker.Pages.Genre
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.Genre Genre { get; set; }

        public IActionResult OnGet(int id)
        {
            Genre = _context.Genres.Find(id);

            if (Genre == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var genre = _context.Genres.Find(Genre.Id);

            if (genre != null)
            {
                _context.Genres.Remove(genre);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
