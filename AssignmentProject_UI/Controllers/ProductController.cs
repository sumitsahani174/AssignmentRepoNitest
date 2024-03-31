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
        private readonly IConfiguration _configuration;
        private readonly IProduct _product;

        public ProductController(IConfiguration configuration, IProduct product)
        {
            _configuration = configuration;
            _product = product;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductInventoryRequest model)
        {
            GenericResponse genericResponse = new GenericResponse();
            genericResponse = _product.ProductInventoryManagement(model);
            return Ok(genericResponse);
        }
    }
}
