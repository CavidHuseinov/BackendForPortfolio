
using Portfolio.Business.Helpers.DTOs.Common;
using System.Text.Json.Serialization;

namespace Portfolio.Business.Helpers.DTOs.Review
{
    public record ReviewDto:BaseDto
    {
        public string Content { get; set; } = default!;
        public string Name { get; set; } = default!;
    }
}
