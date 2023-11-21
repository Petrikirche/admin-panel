using AdminPanel.Data;
using AdminPanel.Data.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AdminPanel.Web.Services
{
    public class AuthService
    {

        private readonly TicketsPetrekircheContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public AuthService(TicketsPetrekircheContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }


        public async Task<bool> Login(LoginModel model)
        {
            var user = await FindByUsername(model.Username);
            if (user != null)
            {
                return await CheckPassword(user.Passwords, model.Password);
            }
            return false;
        }

        private async Task<bool> CheckPassword(string userPassword, string modelPassword)
        {
            var md5 = MD5.Create();
            var modelPasswordHash = md5.ComputeHash(Encoding.UTF8.GetBytes(modelPassword));
            var test = Convert.ToBase64String(modelPasswordHash);
            return userPassword == Convert.ToBase64String(modelPasswordHash);
        }


        private async Task<User>? FindByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Login == username);
        }



        public async Task Logout()
        {
            await _httpContext.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task GenerateCookieAuthentication(string username)
        {
            var claims = await GetClaims(username);

            ClaimsIdentity identity =
                new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal pricipal = new ClaimsPrincipal(identity);
            await _httpContext.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, pricipal);
        }



        private async Task<List<Claim>> GetClaims(string username)
        {
            var user = await FindByUsername(username);

            
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.RoleId.ToString())
            };


            return claims;
        }




    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
