using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WikiPiece.Repository.Interfaces
{
    public interface IRepository<T> 
    {
        IQueryable<T> Get();
        void Add(T entity);
        void Update(T entity);
    } 
}