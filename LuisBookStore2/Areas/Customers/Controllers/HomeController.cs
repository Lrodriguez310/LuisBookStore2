using LuisBooks.DataAccess.Repository.IRepository;

using Microsoft.AspNetCore.Mvc;

using LuisBooks.Models;

using Microsoft.Extensions.Logging;

using LuisBookStore.Models;

using LuisBookStore.Models.ViewModels;

using System;

using System.Collections.Generic;

using System.Diagnostics;

using System.Linq;

using System.Threading.Tasks;



namespace LuisBookStore.Areas.Customers.Controllers

{

    [Area("Customers")]

    public class HomeController : Controller

    {

        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _unitOfWork;



        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)

        {

            _logger = logger;

            _unitOfWork = unitOfWork;

        }



        public IActionResult Index()

        {

            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,CoverType");

            return View(productList);

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