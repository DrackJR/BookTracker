using BookTracker.Data;
using BookTracker.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookTracker.Pages.Author
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Model.Author Author { get; set; }

        public IActionResult OnGet(int id)
        {
            Author = _context.Authors.FirstOrDefault(b => b.Id ==id);

            if (Author == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Authors.Update(Author);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
