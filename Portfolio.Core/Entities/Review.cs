
using Portfolio.Core.Entities.Common;

namespace Portfolio.Core.Entities
{
    public class Review:BaseEntity
    {
        public string Content { get; set; } = default!;
        public string Name { get; set; } = default!;
        public Guid BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}
