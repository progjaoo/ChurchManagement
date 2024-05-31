using ChurchManagement.Core.Entidades;

namespace ChurchManagement.Core.Interfaces
{
    public interface IPDFGenerator
    {
        Task<byte[]> GenerateMemberCardAsync(Membro membro);
    }
}
