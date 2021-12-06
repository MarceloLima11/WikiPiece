using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WikiPiece.Models;

namespace WikiPiece.Repository.Interfaces
{
    public interface IPersonagemRepository : IRepository<Personagem>
    {
        IEnumerable<Personagem> GetTop5(bool top5);
    }
}