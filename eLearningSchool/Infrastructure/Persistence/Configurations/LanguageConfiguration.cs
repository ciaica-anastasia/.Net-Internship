using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(e => e.LanguageId);
            
            builder.ToTable("Languages");
            
            builder.Property(e => e.LanguageName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}