using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.Membros.UploadImagem
{
    public class UploadImagemCommandHandler : IRequestHandler<UploadImagemCommand, bool>
    {
        private readonly IMembroRepository _membroRepository;
        public UploadImagemCommandHandler(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }
        public async Task<bool> Handle(UploadImagemCommand request, CancellationToken cancellationToken)
        {
            var membro = await _membroRepository.GetByIdAsync(request.IdMembro);

            if (membro == null) return false;

            byte[] file;

            using (var stream = new MemoryStream())
            {
                await request.ImagemMembro.CopyToAsync(stream);
                file = stream.ToArray();

                membro.ImagemMembro = file;
            }
            await _membroRepository.SaveChangesAsync();

            return true;
        }
    }
}
