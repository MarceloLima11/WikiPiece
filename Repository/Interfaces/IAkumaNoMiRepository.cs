using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WikiPiece.Models;

namespace WikiPiece.Repository.Interfaces
{
    public interface IAkumaNoMiRepository : IRepository<AkumaNoMi>
    {
        Task<IEnumerable<AkumaNoMi>> GetByTipo(Expression<Func<AkumaNoMi, bool>> predicate);
        Task<IEnumerable<AkumaNoMi>> GetAkumasPersonagens();
        Task<IEnumerable<AkumaNoMi>> GetById(Expression<Func<AkumaNoMi, bool>> predicate);
        Task<IEnumerable<AkumaNoMi>> GetByNome(Expression<Func<AkumaNoMi, bool>> predicate);
    }
}