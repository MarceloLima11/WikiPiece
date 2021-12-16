using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<AkumaNoMi>> GetAkumasPersonagens()
        {
            return await _context.AkumaNoMis.Include(x => x.Personagens).ToListAsync();
        }

        public async Task<IEnumerable<AkumaNoMi>> GetById(Expression<Func<AkumaNoMi, bool>> predicate)
        {
            return await _context.AkumaNoMis.Where(predicate).Include(x => x.Personagens).ToListAsync();
        }

        public async Task<IEnumerable<AkumaNoMi>> GetByNome(Expression<Func<AkumaNoMi, bool>> predicate)
        {
            return await _context.AkumaNoMis.Where(predicate).Include(x => x.Personagens).ToListAsync();
        }

        public async Task<IEnumerable<AkumaNoMi>> GetByTipo(Expression<Func<AkumaNoMi, bool>> predicate)
        {
            return await _context.AkumaNoMis.Where(predicate).Include(x => x.Personagens).ToListAsync();
        }
    }
}