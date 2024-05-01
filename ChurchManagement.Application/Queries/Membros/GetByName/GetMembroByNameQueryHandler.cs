using ChurchManagement.Application.ViewModels;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Queries.Membros.GetByName
{
    public class GetMembroByNameQueryHandler : IRequestHandler<GetMembroByNameQuery, MembrosViewModel>
    {
        private readonly IMembroRepository _membroRepository;
        public GetMembroByNameQueryHandler(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }
        public async Task<MembrosViewModel> Handle(GetMembroByNameQuery request, CancellationToken cancellationToken)
        {
            var membro = await _membroRepository.GetByNameAsync(request.NomeCompleto);

            if (membro == null) return null;

            var membrosViewModel = new MembrosViewModel(
                membro.Cargo,
                membro.IdCargo,
                membro.NomeCompleto);

            return membrosViewModel;
        }
    }
}
