using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstShop.Core.Contracts;
using FirstShop.Core.Models;
using FirstShop.DataAccess.InMemory;

namespace FirstShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        IRepository<ProductCategory> productCategories;

        public ProductCategoryManagerController(IRepository<ProductCategory> productCategoryRepository)
        {
            productCategories = productCategoryRepository;
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCategory> productCategoryRepository = productCategories.Collection().ToList();

            return View(productCategoryRepository);
        }

        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();
            return View(productCategory);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                productCategories.Insert(productCategory);
                productCategories.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(string Id)
        {

            ProductCategory productCategory = productCategories.Find(Id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }

        }

        [HttpPost]
        public ActionResult Edit(ProductCategory productCategory, string Id)
        {
            ProductCategory productCategoryToEdit = productCategories.Find(Id);

            if (productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategoryToEdit);
                }

                productCategoryToEdit.Category = productCategory.Category;

                productCategories.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ProductCategory productCategoryToDelete = productCategories.Find(Id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategoryToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCategory productCategoryToDelete = productCategories.Find(Id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                productCategories.Delete(Id);
                productCategories.Commit();
                return RedirectToAction("Index");
            }
        }

    }
}