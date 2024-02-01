using Template.CleanArchitecture.Domain.Common;

namespace Template.CleanArchitecture.Domain.Entities
{
    public class Genre:AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Movie>? Movies { get; set; }
    }
}
