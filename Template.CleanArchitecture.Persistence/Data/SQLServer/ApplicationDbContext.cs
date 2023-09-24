using Microsoft.EntityFrameworkCore;
using Templat.Architecture.Domain.Entities;

namespace Templat.Architecture.Persistence.Data.DbSet
{
    public partial class ApplicationDbContext
    {
        public DbSet<Category> Categories { get; set; }
    }
}
