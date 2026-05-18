using BookTracker.Data;
using BookTracker.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookTracker.Pages.Readers
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reader Reader { get; set; }

        public IActionResult OnGet(int id)
        {
            Reader = _context.Readers.Find(id);

            if (Reader == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Readers.Update(Reader);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
