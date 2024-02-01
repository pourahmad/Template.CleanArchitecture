using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Persistence.Configurations
{
    public class MoveConfigoration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasQueryFilter(f => !f.IsDisable);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.Language)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
