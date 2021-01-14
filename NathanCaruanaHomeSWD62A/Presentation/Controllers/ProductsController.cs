using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Application.ViewModels;

namespace Presentation.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsService _productsService;
        private ICartsService _cartsService;
        private ICategoriesService _categoriesService;
        private IWebHostEnvironment _env;
        public ProductsController(IProductsService productsService, 
               ICategoriesService categoriesService,ICartsService cartsService, IWebHostEnvironment env)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _cartsService = cartsService;
            _env = env;
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
        [HttpGet] //the get method will load the page with blank fields
        [Authorize(Roles ="Admin")] //Authorize vs Authorize(Roles="Admin")
                                    //Authorize Authorizes anyone who is logged in, Authorize(Roles="Admin") authorizes only admin
        public IActionResult Create()
        {
            var catList = _categoriesService.GetCategories();

            ViewBag.Categories = catList;

            return View(); //model => ProductViewModel
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ProductViewModel data, IFormFile file) //the post method is called when the user clicks on the submit button
        {
            //validation
            try
            {
                if(file != null)
                {
                    if(file.Length > 0)
                    {
                        string newFilename = Guid.NewGuid() + System.IO.Path.GetExtension(file.FileName);
                        string absolutePath = _env.WebRootPath + @"\Images\";

                        using(var stream = System.IO.File.Create(absolutePath + newFilename))
                        {
                            file.CopyTo(stream);
                        }

                        data.ImageUrl = @"\Images\" + newFilename; // relative Path
                    }
                }
                _productsService.AddProduct(data);
                ViewData["feedback"] = "Product was added successfully";
                ModelState.Clear();

            }
            catch (Exception ex)
            {
                //log errors
                ViewData["warning"] = "Product was not added Check your details";
            }

            var catList = _categoriesService.GetCategories();

            ViewBag.Categories = catList;

            return View();
        }

        public IActionResult Delete(Guid id)
        {
            _productsService.DeleteProduct(id);
            TempData["feedback"] = "Product was delete successfully"; //change wherever we are using viewdata to use tempdata
            return RedirectToAction("Index");
        }

        public IActionResult AddToCart(CartViewModel data, string email)
        {
            email = User.Identity.Name;

            _cartsService.AddCart(data,email);
            TempData["feedback"] = "MY CART"; //change wherever we are using viewdata to use tempdata
            return RedirectToAction("Index");
        }

        public IActionResult myCart(CartViewModel data, string email)
        {
            email = User.Identity.Name;

            var list = _cartsService.GetCart(data,email);

            return View(list);
        }
    }
}
