using Bulky_razor_App.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bulky_razor_App.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext context;

        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDbContext _context)
        {
            context = _context;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
