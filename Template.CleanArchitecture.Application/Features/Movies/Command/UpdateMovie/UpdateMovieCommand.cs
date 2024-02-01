using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.CleanArchitecture.Application.Features.Movies.Command.UpdateMovie
{
    public class UpdateMovieCommand:IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }
    }
}
