using AssignmentProject_UI.Models.DTOs.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace AssignmentProject_UI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductInventoryRequest model)
        {
            string json = JsonSerializer.Serialize(model);

            return Ok();
        }
    }
}
