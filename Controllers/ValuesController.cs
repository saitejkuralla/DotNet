using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Utility;
using Services.Validations;

namespace Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IConfiguration _config;
        public ValuesController(IConfiguration config)
        {
            _config = config;
        }
        // GET api/values
        [HttpGet]
        //[Route("api/values1")]
        public ActionResult<IEnumerable<string>> Get()
        {
            var login = new UserModel()
            {
                Username = "Jignesh",
                password = "password"
            };

            // var test = typeof(UserModelValidator);
            login.SetValidator();

         
            if (!login.Validate().IsValid)
            {
                var result = login;
            }

            IActionResult response = Unauthorized();

            string tokenString = string.Empty;
            var user = AuthenticateUser(login);

            if (user != null)
            {
                tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return new string[] { tokenString };
        }



        [AllowAnonymous]
        [HttpPost]
        public ActionResult<IEnumerable<string>> Post(UserModel model)
        {
           

            return new string[] { "Test"};
        }
        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;

            //Validate the User Credentials  
            //Demo Purpose, I have Passed HardCoded User Information  
            if (login.Username == "Jignesh")
            {
                user = new UserModel { Username = "Jignesh Trivedi", EmailAddress = "test.btest@gmail.com" };
            }
            return user;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        // [Authorize(AuthenticationSchemes = "Bearer")]
        [CustomAuthorization]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
