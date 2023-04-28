namespace MVC_Project.Areas.Customer.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Bulky_Models;
    using System.Diagnostics;
    using bulky_DataAccess.Repository;

    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork unitOfWork;

        public HomeController(ILogger<HomeController> logger , IUnitOfWork _unitOfWork )
        {
            _logger = logger;
            unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {
            var productList = unitOfWork.product.GetAll("Category").ToList();
            return View(productList);
        }

        public IActionResult Details(int id)
        {
            Product product = unitOfWork.product.Get(p => p.Id ==  id , "Category");
            if(product != null)
                return View(product);
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}