namespace MVC_Project.Areas.Admin.Controllers
{
    using bulky_DataAccess;
    using bulky_DataAccess.Repository;
    using Bulky_Models;
    using Bulky_Utility;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork db;

        public CategoryController(IUnitOfWork _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var categories = db.category.GetAll();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.CategoryOrder.ToString())
                ModelState.AddModelError("", "Category name and oreder must not equal ");
            if (ModelState.IsValid)
            {
                db.category.Add(category);
                db.save();
                TempData["Seccess"] = "Category Added Seccessfully";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Category category = db.category.Get(c => c.Id == id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {

            if (ModelState.IsValid)
            {
                db.category.Update(category);
                db.save();
                TempData["Seccess"] = "Category Updated Seccessfully";

                return RedirectToAction("Index");

            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Category category = db.category.Get(c => c.Id == id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(Category category)
        {

            db.category.Delete(category);
            db.save();
            TempData["Seccess"] = "Category Deleted Seccessfully";
            return RedirectToAction("Index");
        }

    }


}
