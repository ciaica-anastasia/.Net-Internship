using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.HasKey(e => e.LevelId);
            
            builder.ToTable("Levels");
            
            builder.Property(e => e.LevelName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}