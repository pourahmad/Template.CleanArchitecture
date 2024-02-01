using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.CleanArchitecture.Domain.Entities;

namespace Template.CleanArchitecture.Application.Features.Comment.Command.CreateComment
{

    public class CreateCommentCommand:IRequest<CreateCommentCommandResponse>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int MovieId { get; set; }
    }
}
