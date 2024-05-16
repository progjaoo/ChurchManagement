using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.Posts.UploadImagem
{
    public class UploadImagemPostCommandHandler : IRequestHandler<UploadImagemPostCommand, bool>
    {
        private readonly IPostRepository _postRepository;
        public UploadImagemPostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<bool> Handle(UploadImagemPostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.IdPost);

            //verifica se é false ou n
            if (post == null) return false;

            //define um arquivo byte
            byte[] file;
            //separa um espaço na memória 
            using(var stream = new MemoryStream())
            {
                await request.Imagem.CopyToAsync(stream);
                file = stream.ToArray();

                post.Imagem = file;
            }
            await _postRepository.SaveChangesAsync();

            return true;
        }
    }
}
