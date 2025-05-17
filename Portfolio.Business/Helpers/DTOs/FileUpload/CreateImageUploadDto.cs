
using Microsoft.AspNetCore.Http;

namespace Portfolio.Business.Helpers.DTOs.FileUpload
{
    public record CreateImageUploadDto
    {
        public IFormFile File { get; set; }
        public string FolderName { get; set; }
    }
}
