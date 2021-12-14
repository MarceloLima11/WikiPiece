using System.Collections.Generic;
using WikiPiece.Data.DTOs.LowDtos;

namespace WikiPiece.Data.DTOs
{
    public class ArcoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Volumes { get; set; }
        public string ImagemUrl { get; set; }
        public string CapitulosManga { get; set; }
        public string EpisodiosAnime { get; set; }
        public string AnoLancamento { get; set; }
        public string Descricao { get; set; }
        public ICollection<PersonagemLowDTO> Personagens { get; set; }
    }
}