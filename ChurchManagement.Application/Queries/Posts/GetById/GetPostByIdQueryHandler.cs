using ChurchManagement.Application.ViewModels.PostsVMs;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Queries.Posts.GetById
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostViewModel>
    {
        private readonly IPostRepository _postRepository;
        public GetPostByIdQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<PostViewModel> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.IdPost);

            if (post == null) return null;

            var postsViewModel = new PostViewModel(
                post.IdPost,
                post.Titulo,
                post.Assunto,
                post.Imagem);

            return postsViewModel;
        }
    }
}
