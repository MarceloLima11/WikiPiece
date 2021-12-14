using System.Threading.Tasks;

namespace WikiPiece.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IAkumaNoMiRepository AkumaNoMiRepository { get; }
        IPersonagemRepository PersonagemRepository { get; }
        IIlhaRepository IlhaRepository { get; }
        IArcoRepository ArcoRepository { get; }
        Task CommitAsync();
    }
}