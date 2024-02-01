using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.CleanArchitecture.Application.Features.Movies.Queries.GetMovieWithComment
{
    public class MovieWithComment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public bool IsDisable { get; set; }

        public List<CommentInMovie> comments { get; set; } = new List<CommentInMovie>();
    }
}
