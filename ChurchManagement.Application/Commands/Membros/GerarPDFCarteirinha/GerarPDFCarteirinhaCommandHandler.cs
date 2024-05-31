using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Commands.Membros.GerarPDFCarteirinha
{
    public class GerarPDFCarteirinhaCommandHandler : IRequestHandler<GerarPDFCarteirinhaCommand, byte[]>
    {
        private readonly IMembroRepository _membroRepository;
        private readonly IPDFGenerator _pdfGenerator;

        public GerarPDFCarteirinhaCommandHandler(IMembroRepository membroRepository, IPDFGenerator pdfGenerator)
        {
            _membroRepository = membroRepository;
            _pdfGenerator = pdfGenerator;
        }

        public async Task<byte[]> Handle(GerarPDFCarteirinhaCommand request, CancellationToken cancellationToken)
        {
            var membro = await _membroRepository.GetByIdAsync(request.IdMembro);

            if (membro == null)
            {
                throw new Exception("Membro não encontrado.");
            }

            return await _pdfGenerator.GenerateMemberCardAsync(membro);
        }
    }
}
