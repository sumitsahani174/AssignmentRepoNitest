using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AssignmentProject.Utilities
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = false)]
    public class ApiKeyAttribute : Attribute, IAuthorizationFilter
    {

        public ApiKeyAttribute()
        {
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue("ApiKey", out var apiKeyValue))
            {
                string apiKey = apiKeyValue;
                if(string.IsNullOrEmpty(apiKey))
                {
                    context.Result = new UnauthorizedResult();
                }

            }
            else
            {
                string APikey = context.HttpContext.Request.Headers["ApiKey"];
                if (string.IsNullOrEmpty(APikey))
                {
                    context.Result = new UnauthorizedResult();
                }
                else
                {
                    try {

                      string[] APiKeyData =  AesEncryption.Decrypt(APikey).Split(",");
                        if(APiKeyData.Length < 2)
                        {
                            context.Result = new UnauthorizedResult();
                        }
                    }
                    catch(Exception ex)
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
        }
    }
}
