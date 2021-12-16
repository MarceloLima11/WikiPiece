using WikiPiece.Data.DTOs.LowDtos;
using WikiPiece.Models;

namespace WikiPiece.Data.DTOs
{
    public class PersonagemDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Linhagem { get; set;}
        public string Altura { get; set; }
        public string Status { get; set; }
        public string Recompensa { get; set; }
        public string FraseMarcante { get; set; }
        public string PrimeiraAparicao { get; set; }
        public string Descricao { get; set; }
        public string ImagemUrl { get; set;}
        public int AkumaNoMiId { get; set;}
        public AkumaNoMiLowDTO AkumaNoMi { get; set; }
    }
}