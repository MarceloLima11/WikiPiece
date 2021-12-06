using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WikiPiece.Models;

namespace WikiPiece.Repository.Interfaces
{
    public interface IAkumaNoMiRepository : IRepository<AkumaNoMi>
    {
        IEnumerable<AkumaNoMi> GetByTipo(string tipo);

        IEnumerable<AkumaNoMi> GetAkumasPersonagens();
    }
}