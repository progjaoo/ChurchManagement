using ChurchManagement.Application.ViewModels;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Queries.Membros.GetByCargo
{
    public class GetMembroByCargoQueryHandler : IRequestHandler<GetMembroByCargoQuery, MembroCargoViewModel>
    {
        private readonly IMembroRepository _membroRepository;
        public GetMembroByCargoQueryHandler(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }
        public async Task<MembroCargoViewModel> Handle(GetMembroByCargoQuery request, CancellationToken cancellationToken)
        {
            var membro = await _membroRepository.GetByCargo(request.IdCargo);

            if (membro == null) return null;

            var membroCargoViewModel = new MembroCargoViewModel(
                membro.IdCargo,
                membro.NomeCompleto);

            return membroCargoViewModel;
        }
    }
}
