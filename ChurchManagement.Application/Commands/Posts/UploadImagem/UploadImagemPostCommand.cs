using MediatR;
using Microsoft.AspNetCore.Http;

namespace ChurchManagement.Application.Commands.Posts.UploadImagem
{
    public class UploadImagemPostCommand : IRequest<bool>
    {
        public int IdPost { get; set; }
        public required IFormFile Imagem { get; set; }
    }
}
