using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Product_ManagementAPI.Models;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Product_ManagementAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly QueryFactory _db;
        private readonly ILogger<AuthController> _logger;

        public AuthController(QueryFactory db)
        {
            _db = db;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel user)
        {
            //var username = _db.Query("LoginDetails").Select("LoginDetails.username").Get().ToList();
            //var password = _db.Query("LoginDetails").Select("LoginDetails.password").Get().ToList();

            //string usname = username.FirstOrDefault().values;

            //var jasonusername = JsonConvert.SerializeObject(username);
            //var jasonpassword = JsonConvert.SerializeObject(password);



            if (user == null)
            {
                return BadRequest("Invalid Client Request");
            }

           
                if (user.UserName == "nitinshinde" && user.Password == "Nitu@1206")
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@123"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokenOptions = new JwtSecurityToken(
                            issuer: "https://localhost:44353",
                            audience: "https://localhost:44353",
                            claims: new List<Claim>(),
                            expires: DateTime.Now.AddMinutes(5),
                            signingCredentials: signinCredentials
                        );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new { Token = tokenString });

                }
                else
                {
                    return Unauthorized();
                }

        }

        private static readonly string subscriptionKey = "f37cb1ebbc964a86b14e90199ef13bea";
        private static readonly string endpoint = "https://api.cognitive.microsofttranslator.com/";

        // Add your location, also known as region. The default is global.
        // This is required if using a Cognitive Services resource.
        private static readonly string location = "eastasia";

        [HttpPost("languageTranslator")]
        public void langTranslator(LanguageTranslator language)
        {
            //Console.WriteLine(language.data);
            //static async Task Main(string[] args)
            //{
            //    // Input and output languages are defined as parameters.
            //    string route = "/translate?api-version=3.0&from=en&to=de&to=it";
            //    string textToTranslate = "Hello, world!";
            //    object[] body = new object[] { new { Text = textToTranslate } };
            //    var requestBody = JsonConvert.SerializeObject(body);

            //    using (var client = new HttpClient())
            //    using (var request = new HttpRequestMessage())
            //    {
            //        // Build the request.
            //        request.Method = HttpMethod.Post;
            //        request.RequestUri = new Uri(endpoint + route);
            //        request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            //        request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            //        request.Headers.Add("Ocp-Apim-Subscription-Region", location);

            //        // Send the request and get response.
            //        HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
            //        // Read response as a string.
            //        string result = await response.Content.ReadAsStringAsync();
            //        Console.WriteLine(result);
            //    }
            //}

        }


    }
}
