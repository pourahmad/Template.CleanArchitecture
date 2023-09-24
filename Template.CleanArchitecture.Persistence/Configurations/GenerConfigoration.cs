using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Persistence.Configurations
{
    public class GenreConfigoration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {   
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            //Data seeding
            builder.HasData(new Genre { Id = 1, Name = "Action" });
            builder.HasData(new Genre { Id = 2, Name = "Adventure" });
            builder.HasData(new Genre { Id = 3, Name = "Comedy" });
            builder.HasData(new Genre { Id = 4, Name = "Crime" });
            builder.HasData(new Genre { Id = 5, Name = "Fantasy" });
            builder.HasData(new Genre { Id = 6, Name = "Historical" });
            builder.HasData(new Genre { Id = 7, Name = "Historical fiction" });
            builder.HasData(new Genre { Id = 8, Name = "Horror" });
            builder.HasData(new Genre { Id = 9, Name = "Romance" });

        }
    }
}
