using AdminPanel.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminPanel.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        
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
    }
}
