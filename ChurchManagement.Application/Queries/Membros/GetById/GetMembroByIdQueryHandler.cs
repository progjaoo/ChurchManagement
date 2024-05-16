using ChurchManagement.Application.ViewModels.MembrosVMs;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Queries.Membros.GetById
{
    public class GetMembroByIdQueryHandler : IRequestHandler<GetMembroByIdQuery, MembroDetalheViewModel>
    {
        private readonly IMembroRepository _membroRepository;
        public GetMembroByIdQueryHandler(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }
        public async Task<MembroDetalheViewModel> Handle(GetMembroByIdQuery request, CancellationToken cancellationToken)
        {
            var membro = await _membroRepository.GetByIdAsync(request.IdMembro);

            if (membro == null) return null;

            var membroViewModel = new MembroDetalheViewModel(
                membro.IdMembro,
                membro.IdCargo,
                membro.NomeCompleto,
                membro.DataNasc,
                membro.Cargo,
                membro.EstadoCivil,
                membro.Endereco,
                membro.Telefone,
                membro.Email,
                membro.DataCadastro,
                membro.DataBatismo);

            return membroViewModel;
        }
    }
}
