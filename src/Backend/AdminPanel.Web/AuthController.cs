using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Xml.Linq;
using AdminPanel.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using AdminPanel.Web.Services;
using System.Net;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminPanel.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private readonly AuthService _authService;

        public AuthController(TicketsPetrekircheContext context, AuthService authService)
        {
            _authService = authService;
        }


        // GET: api/<AuthController>
        [Authorize]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthController>
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> Post(LoginModel user)
        {
            if (user == null)
            {
               return BadRequest("user null");
            }
            if (await _authService.Login(user))
            {
                await _authService.GenerateCookieAuthentication(user.Username);
                return Ok();

            }
            return BadRequest("user not found");
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
