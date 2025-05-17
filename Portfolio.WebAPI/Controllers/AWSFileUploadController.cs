using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Helpers.DTOs.FileUpload;
using Portfolio.Business.Services.Interfaces;

namespace Portfolio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AWSFileUploadController : ControllerBase
    {
        private readonly IAWSImageService _imgService;

        public AWSFileUploadController(IAWSImageService imgService)
        {
            _imgService = imgService;
        }
        [HttpPost("create-img")]
        public async Task<IActionResult> CreateImageFile(CreateImageUploadDto dto)
        {
            var img = await _imgService.UploadFileAsync(dto);
            return Ok(img);
        }
    }
}
