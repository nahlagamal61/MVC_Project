namespace MVC_Project.Areas.Admin.Controllers
{
    using bulky_DataAccess.Repository;
    using Bulky_Models;
    using Bulky_Models.ViewModels;
    using Bulky_Utility;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.DotNet.Scaffolding.Shared.Messaging;

    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork db;
        private readonly IWebHostEnvironment webHost;

        public ProductController(IUnitOfWork _db , IWebHostEnvironment _webHost )
        {
            db = _db;
            webHost = _webHost;
        }
        public IActionResult Index()
        {
            var products = db.product.GetAll("Category");
            return View(products);
        }

        //public IActionResult Create()
        //{
        //    IEnumerable<SelectListItem> CategoriesLists = db.category.GetAll().Select(x => new SelectListItem
        //    {
        //        Value = x.Id.ToString(),
        //        Text = x.Name
        //    });
        //    ProductVM productVM = new ProductVM()
        //    {
        //        Product = new Product(),
        //        Categories = CategoriesLists.ToList(),
        //    };
        //    return View(productVM);
        //}

        //[HttpPost]
        //public IActionResult Create(ProductVM productvm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.product.Add(productvm.Product);
        //        db.save();
        //        TempData["Seccess"] = "product Added Seccessfully";
        //        return RedirectToAction("Index");

        //    }
        //    else
        //    {
        //        productvm.Categories = db.category.GetAll().Select(x => new SelectListItem
        //        {
        //            Value = x.Id.ToString(),
        //            Text = x.Name
        //        }).ToList();

        //        return View(productvm);
        //    }
        //}

        public IActionResult Upsert(int? id )
        {
            IEnumerable<SelectListItem> CategoriesLists = db.category.GetAll().Select(x => new SelectListItem { 
                Value = x.Id.ToString(),
                Text = x.Name
            } );
            ProductVM productVM = new ProductVM() 
            { 
                Product = new Product(),
                Categories = CategoriesLists.ToList(),
            };
            if(id == null || id == 0)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = db.product.Get(p => p.Id == id);
                return View(productVM );
            }
        }

        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = webHost.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if (!string.IsNullOrEmpty(productVM.Product.ImageURL))
                    {
                        //delete the old image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, productVM.Product.ImageURL.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    productVM.Product.ImageURL = @"\images\product\" + fileName;
                }

                if (productVM.Product.Id == 0)
                {
                    db.product.Add(productVM.Product);
                    db.save();
                    TempData["Success"] = "product Added Successfully";

                }
                else
                {
                    db.product.Update(productVM.Product);
                    db.save();
                    TempData["Success"] = "product Updated Successfully";

                }

                return RedirectToAction("Index");
            }
            else
            {
                productVM.Categories = db.category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVM);
            }
          
        }

        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //        return NotFound();

        //    Product product = db.product.Get(c => c.Id == id);
        //    if (product == null)
        //        return NotFound();

        //    return View(product);
        //}

        //[HttpPost]
        //public IActionResult Edit(Product product)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        db.product.Update(product);
        //        db.save();
        //        TempData["Seccess"] = "Product Updated Seccessfully";

        //        return RedirectToAction("Index");

        //    }
        //    return View();
        //}

        public IActionResult Deletem(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            Product product = db.product.Get(c => c.Id == id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = SD.Role_Admin)]

        public IActionResult DeletePost(Product product)
        {

            db.product.Delete(product);
            db.save();
            TempData["Seccess"] = "Product Deleted Seccessfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = db.product.GetAll("Category").ToList();

            return Json(new {data= productList});
        }

        [HttpDelete]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Delete(int id)
        {
            Product productToDelete = db.product.Get(p => p.Id == id , "Category");
            if(productToDelete == null)
                return Json (new {success =false , Message ="Error, This Product Not error"});

            if (!string.IsNullOrEmpty(productToDelete.ImageURL))
            { 
                //delete the old image
                var oldImagePath =
                    Path.Combine(webHost.WebRootPath, productToDelete.ImageURL.TrimStart('\\'));

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }
            
            db.product.Delete(productToDelete);
            db.save();
            return Json(new { success = true, Message = "This Product remove" });
        }

    }

}
