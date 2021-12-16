using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WikiPiece.Models;

namespace WikiPiece.Repository.Interfaces
{
    public interface IPersonagemRepository : IRepository<Personagem>
    {
        Task<IEnumerable<Personagem>> GetPersonagensAkumas();
        Task<IEnumerable<Personagem>> GetTop5(Expression<Func<Personagem, bool>> predicate);
        Task<IEnumerable<Personagem>> GetById(Expression<Func<Personagem, bool>> predicate);
        Task<IEnumerable<Personagem>> GetByNome(Expression<Func<Personagem, bool>> predicate);
    }
}