using FirstShop.Core.Contracts;
using FirstShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstShop.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService basketService;

        // GET: Basket
        public BasketController(IBasketService BasketService)
        {
            this.basketService = BasketService;
        }

        public ActionResult Index() {
            var model = basketService.GetBasketItems(this.HttpContext);

            return View(model);
        }

        public ActionResult AddToBasket(string Id)
        {
            basketService.AddToBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromBasket(string Id)
        {
            basketService.RemoveFromBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public PartialViewResult BasketSummary(string Id)
        {
            var basketSummary = basketService.GetBasketSummary(this.HttpContext);

            return PartialView(basketSummary);
        }
    }
}