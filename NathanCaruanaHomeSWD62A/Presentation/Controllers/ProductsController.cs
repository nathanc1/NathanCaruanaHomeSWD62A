﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;

namespace Presentation.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsService _productsService;
        public ProductsController(IProductsService productsService)


        {
            _productsService = productsService;
        }
        /// <summary>
        /// Products catalogue
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //IQUERYABLE
            //IENUMERABLE

            var list = _productsService.GetProducts();

            return View(list);
        }
        public IActionResult Details(Guid id)
        {
           var myProduct = _productsService.GetProduct(id);
            return View(myProduct);

        }
    }
}
