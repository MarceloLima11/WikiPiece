using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WikiPiece.Data;
using WikiPiece.Repository.Interfaces;

namespace WikiPiece.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly WikiPieceContext _context;
        public Repository(WikiPieceContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }
    }
}