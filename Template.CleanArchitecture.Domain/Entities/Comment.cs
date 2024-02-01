using Template.CleanArchitecture.Domain.Common;

namespace Template.CleanArchitecture.Domain.Entities
{
    public class Comment : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public Movie Movie { get; set; }
        public bool? IsPublish{get;set;}
    }
}
