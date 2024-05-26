using CollectionsManagementService.VievModels;
using DataORMLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CollectionsManagementService.Controllers;

[Authorize(Policy = "AdminsOnly")]
[Authorize(Policy = "UserNotBlocked")]
public class AdminController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AdminController(UserManager<ApplicationUser>  userManager, 
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IActionResult> Index()
    {
        var list = new List<UserViewModel>();
        var users = await _userManager.Users.ToListAsync();
        for (int i = 0; i < users.Count; i++)
        {
            var userClaims = await _userManager.GetClaimsAsync(users[i]);
            var adminClaim = userClaims.FirstOrDefault(x => x.Type == "role");
            var blockedClaim = userClaims.FirstOrDefault(x => x.Type == "blocked");
            var userName = userClaims.FirstOrDefault(x => x.Type == "username");

            var userVm = new UserViewModel
            {
                UserId = users[i].Id,
                UserName = userName?.Value ?? "Empty claim",
                UserEmail = users[i]?.Email ?? "Empty email",
                IsAdmin = adminClaim?.Value == "admin",
                IsBlocked = blockedClaim?.Value == "blocked",
            };
            list.Add(userVm);
        }

        return View(list);
    }

    [HttpPost]
    public async Task<IActionResult> ChangeRole(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roleClaim = userClaims.FirstOrDefault(c => c.Type == "role");
        if (roleClaim != null)
        {
            if (roleClaim.Value == "admin")
            {
                var newClaim = new Claim("role", "user");
                await _userManager.AddClaimAsync(user, newClaim);
            }
            else
            {
                var newClaim = new Claim("role", "admin");
                await _userManager.AddClaimAsync(user, newClaim);
            }

            await _userManager.RemoveClaimAsync(user, roleClaim);
        }
        else
        {
            var newClaim = new Claim("role", "user");
            await _userManager.AddClaimAsync(user, newClaim);
        }

        var currentUserId = _userManager.GetUserId(User);
        if (currentUserId == userId)
        {
            await _signInManager.SignOutAsync();
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> ChangeBlocking(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var blockClame = userClaims.FirstOrDefault(c => c.Type == "blocked" || c.Value == "blocked");
            if (blockClame != null)
            {
                await _userManager.RemoveClaimAsync(user, blockClame);
            }
            else
            {
                var newClaim = new Claim("blocked", "blocked");
                await _userManager.AddClaimAsync(user, newClaim);
            }
        }

        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            await _userManager.DeleteAsync(user);
        }

        var currentUserId = _userManager.GetUserId(User);
        if (currentUserId == userId)
        {
            await _signInManager.SignOutAsync();
        }

        return RedirectToAction("Index");
    }
}
