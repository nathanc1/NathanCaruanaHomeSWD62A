using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Application.ViewModels;

namespace Presentation.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsService _productsService;
        private ICartsService _cartsService;
        private IOrdersService _ordersService;
        private IOrderDetailsService _orderDetailsService;
        private ICategoriesService _categoriesService;
        private IWebHostEnvironment _env;

        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductsService productsService, 
               ICategoriesService categoriesService,ICartsService cartsService,
               IOrdersService ordersService, IOrderDetailsService orderDetailsService ,
               IWebHostEnvironment env, ILogger<ProductsController> logger)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _cartsService = cartsService;
            _ordersService = ordersService;
            _orderDetailsService = orderDetailsService;
            _env = env;
            _logger = logger;
        }
        /// <summary>
        /// Products catalogue
        /// </summary>
        /// <returns></returns>  
        public IActionResult Index()
        {
            //IQUERYABLE
            //IENUMERABLE
            try
            {
                var list = _productsService.GetProducts();

                _logger.LogInformation("Products list worked");

                return View(list); 
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Products list not working" + ex);
                return RedirectToAction("Error", "home");
            }
        }
        public IActionResult Details(Guid id)
        {
            try
            {
                var myProduct = _productsService.GetProduct(id);
                return View(myProduct);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "home");
            }

        }
        [HttpGet] //the get method will load the page with blank fields
        [Authorize(Roles ="Admin")] //Authorize vs Authorize(Roles="Admin")
                                    //Authorize Authorizes anyone who is logged in, Authorize(Roles="Admin") authorizes only admin
        public IActionResult Create()
        {
            try
            {

                var catList = _categoriesService.GetCategories();

                 ViewBag.Categories = catList;

                return View(); //model => ProductViewModel
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "home");
            }
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
            catch (Exception)
            {
                //log errors
                ViewData["warning"] = "Product was not added Check your details";
                return RedirectToAction("Error", "home");
            }

            var catList = _categoriesService.GetCategories();

            ViewBag.Categories = catList;

            return View();
        }

        public IActionResult Delete(Guid id)
        {
            try
            {


                _productsService.DeleteProduct(id);
                TempData["feedback"] = "Product was delete successfully"; //change wherever we are using viewdata to use tempdata
                return RedirectToAction("Index");
            }catch(Exception)
            {
                return RedirectToAction("Error", "home");
            }
        }

        [Authorize(Roles = "User")]
        public IActionResult AddToCart(Guid id,string email,int qty)
        {
            try
            {

                email = User.Identity.Name;

                _cartsService.AddCart(id, email,qty);
                TempData["feedback"] = "MY CART"; //change wherever we are using viewdata to use tempdata
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "home");
            }
        }
        [Authorize(Roles = "User")]
        public IActionResult myCart(CartViewModel data, string email)
        {
            try
            {

                email = User.Identity.Name;

                var list = _cartsService.GetCart(data, email);

                return View(list);
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "home");
            }
        }

        public IActionResult checkout(OrderViewModel data, Guid ordid, Guid prodId ,string email)
        {
            try
            {
                email = User.Identity.Name;

                _ordersService.AddOrder(data, email);
                _orderDetailsService.AddOrderDetails(ordid, prodId, email);
                TempData["feedback"] = "MY CART"; //change wherever we are using viewdata to use tempdata
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "home");
            }
        }
    }
}
