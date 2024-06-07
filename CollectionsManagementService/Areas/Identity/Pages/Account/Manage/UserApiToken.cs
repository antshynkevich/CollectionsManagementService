using DataORMLayer.Models;
using DotNetEnv;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CollectionsManagementService.Areas.Identity.Pages.Account.Manage
{
    public class TwoFactorAuthenticationModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public TwoFactorAuthenticationModel(
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public string ApiToken { get; set; } = "Please generate a new one.";

        public async Task<IActionResult> OnGetNewTokenAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userId = user.Id;
            var userEmail = user.Email;
            var userName = User.FindFirstValue("username");

            List<Claim> claims =
            [
                new Claim("userName", userName),
                new Claim("emailAddress", userEmail),
                new Claim("userId", userId)
            ];

            byte[] keyFromFile = Encoding.UTF8.GetBytes(Env.GetString("tokensecretkey"));
            var key = new SymmetricSecurityKey(keyFromFile);
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(10),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            ApiToken = jwt.ToString();
            return Page();
        }
    }
}
