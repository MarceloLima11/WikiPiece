using System.Collections.Generic;

namespace WikiPiece.Data.DTOs
{
    public class AkumaNoMiDTO
    {
        public int Id  { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string PrimeiraAparicao { get; set; }
        public string ImagemUrl { get; set; }
        public string Descricao { get; set; }
        public ICollection<PersonagemDTO> Personagens { get; set; }  
    }
}