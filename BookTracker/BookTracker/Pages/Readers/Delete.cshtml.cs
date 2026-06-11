using BookTracker.Data;
using BookTracker.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookTracker.Pages.Readers
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
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
            var student = _context.Readers.Find(Reader.Id);

            if (student != null)
            {
                _context.Readers.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
