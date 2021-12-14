using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WikiPiece.Data;
using WikiPiece.Models;
using WikiPiece.Repository.Interfaces;

namespace WikiPiece.Repository
{
    public class IlhaRepository : Repository<Ilha>, IIlhaRepository
    {
        private readonly WikiPieceContext _context;

        public IlhaRepository(WikiPieceContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Ilha> GetByClima(Expression<Func<Ilha, bool>> predicate)
        {
            return _context.Ilhas.Where(predicate);
        }

        public Ilha GetById(Expression<Func<Ilha, bool>> predicate)
        {
            return _context.Ilhas.FirstOrDefault(predicate);
        }

        public IEnumerable<Ilha> GetByRegiao(Expression<Func<Ilha, bool>> predicate)
        {
            return _context.Ilhas.Where(predicate);
        }
    }
}