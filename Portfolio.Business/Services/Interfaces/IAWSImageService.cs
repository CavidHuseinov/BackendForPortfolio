
using Portfolio.Business.Helpers.DTOs.FileUpload;

namespace Portfolio.Business.Services.Interfaces
{
    public interface IAWSImageService
    {
        Task<ImageUrlDrto> UploadFileAsync(CreateImageUploadDto fileUploadDto);
    }
}
