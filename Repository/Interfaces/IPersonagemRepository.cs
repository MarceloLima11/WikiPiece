using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WikiPiece.Models;

namespace WikiPiece.Repository.Interfaces
{
    public interface IPersonagemRepository : IRepository<Personagem>
    {
        IEnumerable<Personagem> GetPersonagensAkumas();
        IEnumerable<Personagem> GetTop5(Expression<Func<Personagem, bool>> predicate);
        IEnumerable<Personagem> GetById(Expression<Func<Personagem, bool>> predicate);
        IEnumerable<Personagem> GetByNome(Expression<Func<Personagem, bool>> predicate);
    }
}