
using Portfolio.Core.Entities.Common;

namespace Portfolio.Core.Entities
{
    public class Blog:BaseEntity
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string? ImgUrl { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
