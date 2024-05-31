using Microsoft.AspNetCore.Authorization;

namespace CollectionsManagementService.Authorization;

public class MustBeCollectionOwnerOrAdminRequirement : IAuthorizationRequirement{}
