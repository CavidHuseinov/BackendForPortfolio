using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Helpers.DTOs.Review;
using Portfolio.Business.Services.Interfaces;

namespace Portfolio.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _services;

        public ReviewController(IReviewService services)
        {
            _services = services;
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var blogAll = await _services.GetAllAsync();
            return Ok(blogAll);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var blogId = await _services.GetByIdAsync(id);
            return Ok(blogId);
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CreateReviewDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createBlog = await _services.CreateAsync(dto);
            return Ok(createBlog);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            await _services.DeleteAsync(id);
            return NoContent();
        }
    }
}
