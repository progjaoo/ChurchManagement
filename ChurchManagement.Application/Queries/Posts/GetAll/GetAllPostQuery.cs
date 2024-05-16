using ChurchManagement.Application.ViewModels.PostsVMs;
using MediatR;

namespace ChurchManagement.Application.Queries.Posts.GetAll
{
    public class GetAllPostQuery : IRequest<List<PostViewModel>> { }
}
