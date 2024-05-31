using ChurchManagement.Application.ViewModels.MembrosVMs;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Queries.Membros.GetByName
{
    public class GetMembroByNameQueryHandler : IRequestHandler<GetMembroByNameQuery, MembroDetalheViewModel>
    {
        private readonly IMembroRepository _membroRepository;
        public GetMembroByNameQueryHandler(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }
        public async Task<MembroDetalheViewModel> Handle(GetMembroByNameQuery request, CancellationToken cancellationToken)
        {
            var membro = await _membroRepository.GetByNameAsync(request.NomeCompleto);

            if (membro == null) return null;

            var membrosViewModel = new MembroDetalheViewModel(
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

            return membrosViewModel;
        }
    }
}
