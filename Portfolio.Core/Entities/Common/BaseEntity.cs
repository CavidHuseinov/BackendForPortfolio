
using Portfolio.Core.ValueObjects;

namespace Portfolio.Core.Entities.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public CreatedAtVO CreatedAt { get; set; } = new CreatedAtVO(DateTime.UtcNow.AddHours(4));
    }
}
