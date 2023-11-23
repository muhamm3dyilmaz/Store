using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.EFCore;
using Repositories.Contracts;

namespace StoreApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepositoryManager _manager;

        public ProductController(IRepositoryManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _manager.ProductRepo.GetAllProducts(false);
            return View(model);
        }


        public IActionResult Get(int productId)
        {
            var product = _manager.ProductRepo.GetProductById(productId, false);
            return View(product);
        }
    }
}