using ChurchManagement.Application.ViewModels.PostsVMs;
using MediatR;

namespace ChurchManagement.Application.Queries.Posts.GetById
{
    public class GetPostByIdQuery : IRequest<PostViewModel>
    {
        public GetPostByIdQuery(int idPost)
        {
            IdPost = idPost;
        }
        public int IdPost { get; set; }
    }
}
