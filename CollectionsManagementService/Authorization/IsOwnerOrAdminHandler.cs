using DataORMLayer.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CollectionsManagementService.Authorization;

public class IsOwnerOrAdminHandler : AuthorizationHandler<MustBeCollectionOwnerOrAdminRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MustBeCollectionOwnerOrAdminRequirement requirement)
    {
        ClaimsPrincipal user = context.User;
        var blockClame = user.Claims.FirstOrDefault(c => c.Type == "blocked" || c.Value == "blocked");
        if (blockClame != null)
        {
            return Task.CompletedTask;
        }

        var roleClaim = user.Claims.FirstOrDefault(c => c.Type == "role");
        if (roleClaim?.Value == "admin")
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        string? userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        IUserIdContained? entityWithUserId = GetEntity(context.Resource);
        if (!string.IsNullOrEmpty(userId) && entityWithUserId is not null)
        {
            if (entityWithUserId.UserId == userId)
            {
                context.Succeed(requirement);
            }
        }

        return Task.CompletedTask;
    }

    private IUserIdContained? GetEntity(object? resource)
    {
        if (resource is IUserIdContained resourse)
        {
            return resourse;
        }

        return null;
    }
}
