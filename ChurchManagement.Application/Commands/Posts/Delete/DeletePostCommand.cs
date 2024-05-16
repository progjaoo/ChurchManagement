using MediatR;

namespace ChurchManagement.Application.Commands.Posts.Delete
{
    public class DeletePostCommand : IRequest<Unit>
    {
        public DeletePostCommand(int idPost)
        {
            IdPost = idPost;
        }
        public int IdPost { get; set; }
    }
}
