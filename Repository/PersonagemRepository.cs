using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WikiPiece.Data;
using WikiPiece.Models;
using WikiPiece.Repository.Interfaces;

namespace WikiPiece.Repository
{
    public class PersonagemRepository : Repository<Personagem>, IPersonagemRepository
    {
        private readonly WikiPieceContext _context;
        public PersonagemRepository(WikiPieceContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Personagem> GetTop5(Expression<Func<Personagem, bool>> predicate)
        {
            return _context.Personagens.Where(predicate);
        }
    }
}