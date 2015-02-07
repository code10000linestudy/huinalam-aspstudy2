using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.WebUI.Models;
using SportStore.WebUI.Modules;

namespace SportStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController()
        {
            //this.repository = productRepository;
            BindManager.SetProduct(ref repository);
        }

        // GET: Product
        public ActionResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(q => category == null || q.Category == category)
                    .OrderBy(q => q.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Products.Count():
                    repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (product.IsValid == false)
                return View("Add");

            repository.Add(product);
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Remove()
        {
            return View("Remove");
        }

        [HttpPost]
        public ActionResult Remove(Product product)
        {
            if (product.Name == null)
            {
                ViewBag.Msg = "이름이 입력되지 않았습니다.";
                return View("Remove");
            }

            bool result = repository.Remove(product);
            if (result == false)
            {
                ViewBag.Msg = "존재하지 않는 아이템입니다.";
                return View("Remove");
            }
            return RedirectToAction("List");
        }
    }
}