using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WikiPiece.Data;
using WikiPiece.Data.DTOs;
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

        public async Task<IEnumerable<Arco>> GetArcoPersonagens()
        {
            return await _context.Arcos.Include(x => x.Personagens).ToListAsync();
        }

        public async Task<IEnumerable<Arco>> GetById(Expression<Func<Arco, bool>> predicate)
        {
            return await _context.Arcos.Where(predicate).Include(x => x.Personagens).ToListAsync();
        }

        public async Task<IEnumerable<Arco>> GetByNome(Expression<Func<Arco, bool>> predicate)
        {
            return await _context.Arcos.Where(predicate).Include(x => x.Personagens).ToListAsync();
        }
    }
}