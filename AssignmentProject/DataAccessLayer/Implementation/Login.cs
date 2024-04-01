using AssignmentProject.DataAccessLayer.Interface;
using AssignmentProject.Models.DTOs.Request;
using AssignmentProject.Models.DTOs.Response;
using AssignmentProject.Utilities;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AssignmentProject.DataAccessLayer.Implementation
{
    public class Login : ILogin
    {
        private readonly IConfiguration _configuration;
        public Login(IConfiguration configuration) {
            _configuration = configuration;
        }

       public GenericResponse UserLogin(LoginRequest model)
        {
            GenericResponse genericResponse = new GenericResponse();
            try
            {
                using (var connection = new SqlConnection(_configuration.GetSection("DatabaseSettings:ConnectionString").Value))
                {
                    connection.Open();
                    var parameters = new DynamicParameters();
                    parameters.Add("@Email", model.Email);
                    parameters.Add("@Password", model.Password);
                    UserLoginResponse loginResponse = new UserLoginResponse();
                    loginResponse = connection.Query<UserLoginResponse>("CheckUserLogin", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    
                    if(loginResponse != null)
                    {
                        genericResponse.IsSuccess = true;
                        genericResponse.Message = "Login Successfully";
                        loginResponse.ApiKey = AesEncryption.Encrypt(Convert.ToString(loginResponse.UserID)+","+ loginResponse.UserRole);
                        genericResponse.Data = loginResponse;
                    }
                    else
                    {
                        genericResponse.IsSuccess = false;
                        genericResponse.Message = "Login failed";
                        genericResponse.Data = loginResponse;
                    }
                   
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
