using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopApp.Business.Abstract;
using ShopApp.Entities.Concrete;
using ShopApp.WebUI.Models;

namespace ShopApp.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        public AdminController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View(new ProductListModel() { 
                Products = _productService.GetAll()
            });
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductModel model)
        {
            var entity = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                ImageURL = model.ImageURL
            };

            _productService.Create(entity);

            return Redirect("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var entity = _productService.GetById((int)id);
            if (entity == null)
            {
                return NotFound();
            }
            var model = new ProductModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                ImageURL = entity.ImageURL
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(ProductModel model)
        {
            var entity = _productService.GetById(model.Id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Name = model.Name;
            entity.Description = model.Description;
            entity.ImageURL = model.ImageURL;
            entity.Price = model.Price;

            _productService.Update(entity);

            return Redirect("Index");
        }
    }
}