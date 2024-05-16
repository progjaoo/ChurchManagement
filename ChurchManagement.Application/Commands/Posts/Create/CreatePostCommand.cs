using MediatR;

namespace ChurchManagement.Application.Commands.Posts.Create
{
    public class CreatePostCommand : IRequest<int>
    {
        public string Titulo { get; set; }
        public string Assunto { get; set; }
    }
}
