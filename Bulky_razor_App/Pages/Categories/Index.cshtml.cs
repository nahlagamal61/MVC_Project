using Bulky_razor_App.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bulky_razor_App.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext db;
        public List<Category> Categories { get; set; }
        public IndexModel(ApplicationDbContext _db)
        {
            db = _db;
        }
        public void OnGet()
        {
            Categories = db.Categories.ToList();
        }
    }
}
