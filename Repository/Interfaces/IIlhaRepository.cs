using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WikiPiece.Models;

namespace WikiPiece.Repository.Interfaces
{
    public interface IIlhaRepository : IRepository<Ilha>
    {
        IEnumerable<Ilha> GetByRegiao(Expression<Func<Ilha, bool>> predicate);

        IEnumerable<Ilha> GetByClima(Expression<Func<Ilha, bool>> predicate);
    }
}