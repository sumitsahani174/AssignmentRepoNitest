using AssignmentProject_UI.DataAccessLayer.Interface;
using AssignmentProject_UI.Models.DTOs.Request;
using AssignmentProject_UI.Models.DTOs.Response;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace AssignmentProject_UI.DataAccessLayer.Implementation
{
    public class Login : ILogin
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public Login(IConfiguration configuration, HttpClient httpClient = null)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public UserLoginResponse CheckUserLogin(LoginRequest loginRequest)
        {
            UserLoginResponse userLoginResponse = new UserLoginResponse();
            GenericResponse genericResponse = new GenericResponse();
            string apiUrl = _configuration.GetSection("Login").Value;
            string jsonContent = JsonSerializer.Serialize(loginRequest);
            var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
            {
                Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = _httpClient.Send(request);
            if (response.IsSuccessStatusCode)
            {
                string responseData = response.Content.ReadAsStringAsync().Result;
                genericResponse = JsonSerializer.Deserialize<GenericResponse>(responseData);
                if (genericResponse.isSuccess)
                {
                     userLoginResponse = JsonSerializer.Deserialize<UserLoginResponse>(genericResponse.data.ToString());
                    //HttpContext.Session.SetString("ApiKey", userLoginResponse.ApiKey);
                }
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
            }
            return userLoginResponse;
        }
    }
}
