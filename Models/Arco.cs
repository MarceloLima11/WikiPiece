using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WikiPiece.Models
{
    [Table("Arcos")]
    public class Arco
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string ImagemUrl { get; set; }
        [Required]
        public string Volumes { get; set; }
        [Required]
        public string CapitulosManga { get; set; }
        [Required]
        public string EpisodiosAnime { get; set; }
        [Required]
        public string AnoLancamento { get; set; }
        [Required]
        public string Descricao { get; set; }
        public ICollection<Personagem> Personagens { get; set; }
    }
}