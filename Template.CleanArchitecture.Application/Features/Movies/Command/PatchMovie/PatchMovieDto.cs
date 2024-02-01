namespace Template.CleanArchitecture.Application.Features.Movies.Command.PatchMovie
{
    public class PatchMovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public int Rating { get; set; }
        public bool IsDisable { get; set; }
        public string Description { get; set; }
    }
}
