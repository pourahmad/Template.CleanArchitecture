using Template.CleanArchitecture.Domain.Common;

namespace Template.CleanArchitecture.Domain.Entities
{
    public class Movie:AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public string Language { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public bool IsDisable { get; set; }
    }
}
