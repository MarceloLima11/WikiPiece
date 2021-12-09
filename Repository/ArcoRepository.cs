using WikiPiece.Data;
using WikiPiece.Models;
using WikiPiece.Repository.Interfaces;

namespace WikiPiece.Repository
{
    public class ArcoRepository : Repository<Arco>, IArcoRepository
    {
        private readonly WikiPieceContext _context;
        public ArcoRepository(WikiPieceContext context) : base(context)
        {
            _context = context;
        }
    }
}