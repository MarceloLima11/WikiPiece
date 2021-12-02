using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WikiPiece.Models
{
    [Table("AkumaNoMis")]
    public class AkumaNoMi
    {
        
        [Key]
        public int Id  { get; set; }
        [Required]
        [StringLength(17, MinimumLength = 13, ErrorMessage = "Maximo de 17, minimo de 13")]
        public string Nome { get; set; }
        [Required]
        [StringLength(9, MinimumLength = 4, ErrorMessage = "Maximo de 9, minimo de 4")]
        public string Tipo { get; set; }
        public string PrimeiraAparicao { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "Maximo de 300")]
        public string ImagemUrl { get; set; }
        [Required]
        [StringLength(20000, MinimumLength = 1000, ErrorMessage = "Maximo de 20000, minimo de 1000")]
        public string Descricao { get; set; }
        public ICollection<Personagem> Personagens { get; set; }   
    }
}