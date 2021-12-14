using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IEnumerable<Arco> GetArcoPersonagens()
        {
            return _context.Arcos.Include(x => x.Personagens).ToList();
        }

        public IEnumerable<Arco> GetByInclude(Expression<Func<Arco, bool>> predicate)
        {
            return _context.Arcos.Where(predicate).Include(x => x.Personagens).ToList();
        }
    }
}