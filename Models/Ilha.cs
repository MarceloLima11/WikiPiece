using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WikiPiece.Models
{
    [Table("Ilhas")]
    public class Ilha 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Maximo de 10 minimo de 3")]
        public string Regiao { get; set; }
        [Required]
        public string Clima { get; set; }
        [Required]
        public string Descricao { get; set; }
        [StringLength(300, ErrorMessage = "Maximo de 300")]
        [Required]
        public string ImagemUrl { get; set; }
        public ICollection<Personagem> Personagens { get; set; }

    }
}
//Nome, Estação, Descrição, Imagem, Collection Personagens
