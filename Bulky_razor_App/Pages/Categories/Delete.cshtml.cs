using Bulky_razor_App.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bulky_razor_App.Pages.Categories
{ 
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = context.Categories.Find(id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            var category = context.Categories.Find(Category.Id);

            if (category == null)
            {
                return NotFound();
            }
            Category = category;
            context.Categories.Remove(Category);
            context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}
