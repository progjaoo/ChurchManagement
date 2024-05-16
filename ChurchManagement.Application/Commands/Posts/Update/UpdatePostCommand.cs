using MediatR;

namespace ChurchManagement.Application.Commands.Posts.Update
{
    public class UpdatePostCommand : IRequest<Unit>
    {
        public int IdPost { get; set; }
        public string Titulo { get; set; }
        public string Assunto { get; set; }
    }
}
