    using ChurchManagement.Application.ViewModels.MembrosVMs;
using ChurchManagement.Core.Interfaces;
using MediatR;

namespace ChurchManagement.Application.Queries.Membros.GetAll
{
    public class GetAllMembrosQueryHandler : IRequestHandler<GetAllMembrosQuery, List<MembrosViewModel>>
    {
        private readonly IMembroRepository _membroRepository;
        public GetAllMembrosQueryHandler(IMembroRepository membroRepository)
        {
            _membroRepository = membroRepository;
        }
        public async Task<List<MembrosViewModel>> Handle(GetAllMembrosQuery request, CancellationToken cancellationToken)
        {
            var membro = await _membroRepository.GetAllAsync();

            if (membro == null) return null;

            var membrosViewModel = membro.Select(m => new MembrosViewModel(
                m.IdMembro,
                m.NomeCompleto,
                m.Cargo)).ToList();

            return membrosViewModel;
        }
    }
}
