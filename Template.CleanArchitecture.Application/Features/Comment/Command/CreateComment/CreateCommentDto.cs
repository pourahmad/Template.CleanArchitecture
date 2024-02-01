namespace Template.CleanArchitecture.Application.Features.Comment.Command.CreateComment
{
    public class CreateCommentDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int MovieId { get; set; }
    }
}
