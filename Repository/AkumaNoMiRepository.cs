using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WikiPiece.Data;
using WikiPiece.Models;
using WikiPiece.Repository.Interfaces;

namespace WikiPiece.Repository
{
    public class AkumaNoMiRepository : Repository<AkumaNoMi>, IAkumaNoMiRepository
    {
        private readonly WikiPieceContext _context;
        public AkumaNoMiRepository(WikiPieceContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<AkumaNoMi> GetAkumasPersonagens()
        {
            return _context.AkumaNoMis.Include(x => x.Personagens);
        }

        public IEnumerable<AkumaNoMi> GetByTipo(string tipo)
        {
            return _context.AkumaNoMis.Where(x => x.Tipo == tipo);
        }
    }
}