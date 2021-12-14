using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WikiPiece.Data.DTOs;
using WikiPiece.Models;

namespace WikiPiece.Repository.Interfaces
{
    public interface IArcoRepository : IRepository<Arco>
    {
        IEnumerable<Arco> GetArcoPersonagens();
        IEnumerable<Arco> GetByInclude(Expression<Func<Arco, bool>> predicate);
    }
}