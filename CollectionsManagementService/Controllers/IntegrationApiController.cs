using CollectionsManagementService.VievModels.Collection;
using DataORMLayer.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace CollectionsManagementService.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class IntegrationApiController : ControllerBase
{
    private readonly ICollectionRepository _collectionRepository;

    public IntegrationApiController(ICollectionRepository collectionRepository)
    {
        _collectionRepository = collectionRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserCollections()
    {
        var token = HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;
        if (userId != null && userId.Length > 0)
        {
            var collections = await _collectionRepository.GetCollectionsToExportByUserIdAsync(userId);
            var viewModels = collections.Select(c => new CollectionJsonExportViewModel
            {
                CollectionName = c.Name,
                CategoryName = c.Category.Name,
                Description = c.Description,
                ItemsNumber = c.Items.Count,
                OwnerEmailAddress = c.ApplicationUser.Email
            });

            return Ok(viewModels);
        }

        return BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> GetCollectionsByUserId(string userId)
    {
        var collections = await _collectionRepository.GetCollectionsToExportByUserIdAsync(userId);
        var viewModels = collections.Select(c => new CollectionJsonExportViewModel
        {
            CollectionName = c.Name,
            CategoryName = c.Category.Name,
            Description = c.Description,
            ItemsNumber = c.Items.Count,
            OwnerEmailAddress = c.ApplicationUser.Email
        });

        return Ok(viewModels);
    }
}
