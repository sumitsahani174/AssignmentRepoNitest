using AssignmentProject.DataAccessLayer.Interface;
using AssignmentProject.Models.DTOs.Request;
using AssignmentProject.Models.DTOs.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductInventory _productInventory;
        public ProductController(IProductInventory productInventory) {
            _productInventory= productInventory;
        }

        [HttpPost]
        [Route("ProductInventoryManagement")]
        public GenericResponse ProductInventoryManagement(ProductInventoryRequest productInventory)
        {
            GenericResponse genericResponse = new GenericResponse();
            if (productInventory.InventoryType == "Add")
            {
                genericResponse = _productInventory.AddProduct(productInventory);
            }
            else if(productInventory.InventoryType == "Get")
            {
                genericResponse = _productInventory.GetProducts(productInventory);
            }
            return genericResponse;
        }
    }
}
