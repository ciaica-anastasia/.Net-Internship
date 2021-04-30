using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class AgeRangeConfiguration : IEntityTypeConfiguration<AgeRange>
    {
        public void Configure(EntityTypeBuilder<AgeRange> builder)
        {
            builder.ToTable("Age Ranges");

            builder.HasKey(e => e.AgeId);
            
            builder.Property(e => e.AgeRangeName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}