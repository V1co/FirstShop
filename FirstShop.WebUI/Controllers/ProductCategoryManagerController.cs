﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstShop.Core.Models;
using FirstShop.DataAccess.InMemory;

namespace FirstShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        InMemoryRepository<ProductCategory> productCategoryRepository;

        public ProductCategoryManagerController()
        {
            productCategoryRepository = new InMemoryRepository<ProductCategory>();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCategory> products = productCategoryRepository.Collection().ToList();

            return View(products);
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
                productCategoryRepository.Insert(productCategory);
                productCategoryRepository.Commit();

                return RedirectToAction("Index");
            }

        }

        public ActionResult Edit(string Id)
        {

            ProductCategory productCategory = productCategoryRepository.Find(Id);
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
            ProductCategory productCategoryToEdit = productCategoryRepository.Find(Id);

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

                productCategoryRepository.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ProductCategory productCategoryToDelete = productCategoryRepository.Find(Id);

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
            ProductCategory productCategoryToDelete = productCategoryRepository.Find(Id);

            if (productCategoryToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                productCategoryRepository.Delete(Id);
                productCategoryRepository.Commit();
                return RedirectToAction("Index");
            }
        }

    }
}