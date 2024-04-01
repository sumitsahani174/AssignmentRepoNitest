using AssignmentProject_UI.DataAccessLayer.Interface;
using AssignmentProject_UI.Models.DTOs.Request;
using AssignmentProject_UI.Models.DTOs.Response;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace AssignmentProject_UI.DataAccessLayer.Implementation
{
    public class Product : IProduct
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public Product(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }
        public  GenericResponse ProductInventoryManagement(ProductInventoryRequest productInventory, string Apikey)
        {
            GenericResponse genericResponse = new GenericResponse();
            try
            {
                string apiUrl = _configuration.GetSection("ProductInventoryManagementURL").Value;
                string jsonContent = JsonSerializer.Serialize(productInventory);
                var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
                {
                    Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
                };
                request.Headers.Add("ApiKey", Apikey);
                HttpResponseMessage response =  _httpClient.Send(request);
                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    genericResponse = JsonSerializer.Deserialize<GenericResponse>(responseData);
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            return genericResponse;
        }
    }
}
