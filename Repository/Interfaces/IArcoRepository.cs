using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WikiPiece.Data.DTOs;
using WikiPiece.Models;

namespace WikiPiece.Repository.Interfaces
{
    public interface IArcoRepository : IRepository<Arco>
    {
        Task<IEnumerable<Arco>> GetArcoPersonagens();
        Task<IEnumerable<Arco>> GetById(Expression<Func<Arco, bool>> predicate);
        Task<IEnumerable<Arco>> GetByNome(Expression<Func<Arco, bool>> predicate);
    }
}