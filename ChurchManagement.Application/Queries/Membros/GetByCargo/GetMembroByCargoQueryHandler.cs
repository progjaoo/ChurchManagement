using ChurchManagement.Application.ViewModels;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Queries.Membros.GetByCargo
{
    public class GetMembroByCargoQueryHandler : IRequestHandler<GetMembroByCargoQuery, MembrosViewModel>
    {
        private readonly IMembroRepository _membroRepository;
        public GetMembroByCargoQueryHandler(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }
        public async Task<MembrosViewModel> Handle(GetMembroByCargoQuery request, CancellationToken cancellationToken)
        {
            var membro = await _membroRepository.GetByCargo(request.IdCargo);

            if (membro == null) return null;

            var membroCargoViewModel = new MembrosViewModel(
                membro.Cargo,
                membro.IdCargo,
                membro.NomeCompleto);

            return membroCargoViewModel;
        }
    }
}
