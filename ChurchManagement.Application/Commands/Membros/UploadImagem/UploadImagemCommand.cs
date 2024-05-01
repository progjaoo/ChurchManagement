using MediatR;
using Microsoft.AspNetCore.Http;

namespace ChurchManagement.Application.Commands.Membros.UploadImagem
{
    public class UploadImagemCommand : IRequest<bool>
    {
        public int IdMembro { get; set; }
        public required IFormFile ImagemMembro { get; set; }
    }
}
