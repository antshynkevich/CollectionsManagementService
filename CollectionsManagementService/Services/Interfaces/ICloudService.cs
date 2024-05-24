using CloudinaryDotNet.Actions;

namespace CollectionsManagementService.Services.Interfaces;

public interface ICloudService
{
    Task<ImageUploadResult> AddImageAsync(IFormFile file);
    Task DeleteImageAsync(string publicUrl);
}
