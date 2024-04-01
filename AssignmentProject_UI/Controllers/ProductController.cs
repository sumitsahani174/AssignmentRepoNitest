using AssignmentProject_UI.DataAccessLayer.Interface;
using AssignmentProject_UI.Models.DTOs.Request;
using AssignmentProject_UI.Models.DTOs.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Text;
using System.Text.Json;

namespace AssignmentProject_UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _product;

        public ProductController(IProduct product)
        {
            _product = product;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Get()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductInventoryRequest model)
        {
            GenericResponse genericResponse = new GenericResponse();
            string Apikey = HttpContext.Session.GetString("ApiKey");

            genericResponse = _product.ProductInventoryManagement(model, Apikey);
            return Ok(genericResponse);
        }
        [HttpPost]
        public IActionResult GetProductLists([FromBody] ProductInventoryRequest model)
        {
            GenericResponse genericResponse = new GenericResponse();
            string Apikey = HttpContext.Session.GetString("ApiKey");
            genericResponse = _product.ProductInventoryManagement(model, Apikey);
            return Ok(genericResponse);
        }
    }
}
