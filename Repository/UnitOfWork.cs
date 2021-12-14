using System.Threading.Tasks;
using WikiPiece.Data;
using WikiPiece.Repository.Interfaces;

namespace WikiPiece.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IAkumaNoMiRepository _akumaRepository;
        private IPersonagemRepository _personagemRepository;
        public IIlhaRepository _ilhaRepository;
        public IArcoRepository _arcoRepository;
        public WikiPieceContext _context;

        public IAkumaNoMiRepository AkumaNoMiRepository
        {
            get
            {
                return _akumaRepository = _akumaRepository ?? new AkumaNoMiRepository(_context);
            }
        }

        public IPersonagemRepository PersonagemRepository
        {
            get
            {
                return _personagemRepository = _personagemRepository ?? new PersonagemRepository(_context);
            }
        }

        public IIlhaRepository IlhaRepository
        {
            get
            {
                return _ilhaRepository = _ilhaRepository ?? new IlhaRepository(_context);
            }
        }

        public IArcoRepository ArcoRepository
        {
            get
            {
                return _arcoRepository = _arcoRepository ?? new ArcoRepository(_context);
            }
        }

        public UnitOfWork(WikiPieceContext context)
        {
            _context = context;
        }
        public async Task CommitAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}