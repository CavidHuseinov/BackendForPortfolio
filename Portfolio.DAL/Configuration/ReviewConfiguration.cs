
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Core.Entities;

namespace Portfolio.DAL.Configuration
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.CreatedAt, createdAtBuilder =>
            {
                createdAtBuilder.Property(x => x.Date)
                    .HasColumnName("CreatedAt")
                    .IsRequired();
            });
            builder.HasOne(x=>x.Blog)
                .WithMany(x=>x.Reviews)
                .HasForeignKey(x=>x.BlogId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x=>x.Content).IsRequired();
        }
    }
}
