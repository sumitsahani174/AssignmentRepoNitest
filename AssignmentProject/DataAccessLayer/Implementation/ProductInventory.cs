using AssignmentProject.DataAccessLayer.Interface;
using AssignmentProject.Models.DTOs.Request;
using AssignmentProject.Models.DTOs.Response;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace AssignmentProject.DataAccessLayer.Implementation
{
    public class ProductInventory : IProductInventory
    {
        private readonly IConfiguration _configuration;
        public ProductInventory(IConfiguration configuration) {
            _configuration = configuration;
        }
        public GenericResponse AddProduct(ProductInventoryRequest productInventory) 
        {
            GenericResponse genericResponse = new GenericResponse();
            try
            {
                using (var connection = new SqlConnection(_configuration.GetSection("DatabaseSettings:ConnectionString").Value))
                {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@InventoryType", productInventory.InventoryType);
                    parameters.Add("@Name", productInventory.Name);
                    parameters.Add("@Amount", productInventory.Amount);
                    parameters.Add("@Brand", productInventory.Brand);
                    parameters.Add("@Quantity", productInventory.Quantity);
                    ProductInventoryResponse productInventory1 = new ProductInventoryResponse();
                    productInventory1 = connection.Query<ProductInventoryResponse>("InsertProductInventory", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    for (int i = 0; i < productInventory.Images.Count; i++)
                    {
                        var Imageparameters = new DynamicParameters();
                        Imageparameters.Add("@InventoryType", productInventory.InventoryType);
                        Imageparameters.Add("@ProductID", productInventory1.ProductID);
                        Imageparameters.Add("@ImageData", productInventory.Images[i].ImageBase64);
                        connection.ExecuteScalar<int>("InsertProductImage", Imageparameters, commandType: CommandType.StoredProcedure);
                    }
                    genericResponse.IsSuccess = true;
                    genericResponse.Message = "ProductAdded Successfully";
                    // Execute the stored procedure using Dapper with multiple input parameters
                    //return connection.Query<Product>("InsertProductInventory", new { InventoryType = productInventory.InventoryType, ProductId = 0, @Name = productInventory.Name, }, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex) {
                genericResponse.IsSuccess = false;
                genericResponse.Message = "Something went wrong";
                genericResponse.Errors.Add(new Error
                {
                    ErrorID = 500,
                    ErrorMessage = "Something went wrong",
                });
            }
          

            return genericResponse;
        }
        public GenericResponse GetProducts(ProductInventoryRequest productInventory)
        {
            GenericResponse genericResponse = new GenericResponse();
            try
            {
                using (var connection = new SqlConnection(_configuration.GetSection("DatabaseSettings:ConnectionString").Value))
                {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@InventoryType", productInventory.InventoryType);
                    parameters.Add("@Name", productInventory.Name);
                    parameters.Add("@Amount", productInventory.Amount);
                    parameters.Add("@Brand", productInventory.Brand);
                    parameters.Add("@Quantity", productInventory.Quantity);
                    List<ProductListResponse> productInventory1 = new List<ProductListResponse>();
                    productInventory1 = connection.Query<ProductListResponse>("InsertProductInventory", parameters, commandType: CommandType.StoredProcedure).ToList();
                    for (int i = 0; i < productInventory1.Count; i++)
                    {
                        var Imageparameters = new DynamicParameters();
                        Imageparameters.Add("@InventoryType", productInventory.InventoryType);
                        Imageparameters.Add("@ProductID", productInventory1[i].ProductID);
                        Imageparameters.Add("@ImageData", null);
                        productInventory1[i].imageLists = connection.Query<ImageList>("InsertProductImage", Imageparameters, commandType: CommandType.StoredProcedure).ToList();
                    }
                    genericResponse.IsSuccess = true;
                    genericResponse.Message = "ProductAdded Successfully";
                    genericResponse.Data = productInventory1;
                    // Execute the stored procedure using Dapper with multiple input parameters
                    //return connection.Query<Product>("InsertProductInventory", new { InventoryType = productInventory.InventoryType, ProductId = 0, @Name = productInventory.Name, }, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                genericResponse.IsSuccess = false;
                genericResponse.Message = "Something went wrong";
                genericResponse.Errors.Add(new Error
                {
                    ErrorID = 500,
                    ErrorMessage = "Something went wrong",
                });
            }

            return genericResponse;
        }
    }
}
