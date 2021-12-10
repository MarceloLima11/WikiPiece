using System.Collections.Generic;
using WikiPiece.Models;

namespace WikiPiece.Data.DTOs
{
    public class IlhaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Regiao { get; set; }
        public string Clima { get; set; }
        public string Descricao { get; set; }
        public string ImagemUrl { get; set; }
    }
}