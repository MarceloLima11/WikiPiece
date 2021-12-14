using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WikiPiece.Models;

namespace WikiPiece.Repository.Interfaces
{
    public interface IAkumaNoMiRepository : IRepository<AkumaNoMi>
    {
        IEnumerable<AkumaNoMi> GetByTipo(Expression<Func<AkumaNoMi, bool>> predicate);
        IEnumerable<AkumaNoMi> GetAkumasPersonagens();
        IEnumerable<AkumaNoMi> GetById(Expression<Func<AkumaNoMi, bool>> predicate);
        IEnumerable<AkumaNoMi> GetByNome(Expression<Func<AkumaNoMi, bool>> predicate);
    }
}