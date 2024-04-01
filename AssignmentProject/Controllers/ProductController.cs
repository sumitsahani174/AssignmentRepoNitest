using AssignmentProject.DataAccessLayer.Interface;
using AssignmentProject.Models.DTOs.Request;
using AssignmentProject.Models.DTOs.Response;
using AssignmentProject.Utilities;
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
        [ApiKey]
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
            else if (productInventory.InventoryType == "Update")
            {
                if (HttpContext.Request.Headers.TryGetValue("ApiKey", out var headerValue))
                {
                    string apikey = headerValue.ToString();
                    string[] apikeyData = AesEncryption.Decrypt(apikey).Split(",");
                    if (apikeyData[1] == "Admin")
                    {
                        genericResponse = _productInventory.Update(productInventory);
                    }
                    else
                    {
                        genericResponse.IsSuccess = false;
                        genericResponse.Errors.Add(new Error
                        {
                            ErrorID = 500,
                            ErrorMessage = "You are not allowed to update",
                        });
                        genericResponse.Message = "You are not allowed to update";
                    }

                    // Use the header value
                }
               
            }
            return genericResponse;
        }
    }
}
