using FirstShop.Core.Contracts;
using FirstShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstShop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> productRepository;
        IRepository<ProductCategory> productCategories;

        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext)
        {
            productRepository = productContext;
            productCategories = productCategoryContext;
        }

        public ActionResult Index()
        {
            List<Product> products = productRepository.Collection().ToList();
            return View(products);
        }

        public ActionResult Details(string Id)
        {
            Product product = productRepository.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}