using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using CollectionsManagementService.Services.Interfaces;

namespace CollectionsManagementService.Services;

public class CloudService : ICloudService
{
    private readonly Cloudinary _cloudinary;

    public CloudService(Cloudinary cloudinary)
    {
        _cloudinary = cloudinary;
    }

    public async Task<ImageUploadResult> AddImageAsync(IFormFile file)
    {
        await using var stream = file.OpenReadStream();
        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(file.FileName, stream)
        };

        var uploadResult = await _cloudinary.UploadAsync(uploadParams);
        return uploadResult;
    }

    public async Task DeleteImageAsync(string publicUrl)
    {
        var deleteParams = new DeletionParams(publicUrl);
        await _cloudinary.DestroyAsync(deleteParams);
    }
}
