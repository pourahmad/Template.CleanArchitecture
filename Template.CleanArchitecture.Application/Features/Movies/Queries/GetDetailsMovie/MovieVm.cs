namespace Template.CleanArchitecture.Application.Features.Movies.Queries.GetDetailsMovie
{
    public class MovieVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public int Rating { get; set; }
        public bool IsDisable { get; set; }
        public string Description { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
