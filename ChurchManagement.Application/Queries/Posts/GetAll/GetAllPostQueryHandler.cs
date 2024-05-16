using ChurchManagement.Application.ViewModels.PostsVMs;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Queries.Posts.GetAll
{
    public class GetAllPostQueryHandler : IRequestHandler<GetAllPostQuery, List<PostViewModel>>
    {
        private readonly IPostRepository _postRepository;
        public GetAllPostQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<List<PostViewModel>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetAllAsync();

            if (post == null) return null;

            var postsViewlModel = post.Select(p => new PostViewModel(
                p.IdPost,
                p.Titulo,
                p.Assunto)).ToList();

            return postsViewlModel;
        }
    }
}
