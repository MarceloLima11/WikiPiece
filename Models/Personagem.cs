using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WikiPiece.Models
{
    [Table("Personagens")]
    public class Personagem
    {
        [Key]
        public int Id { get; set; }
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Maximo de 25, minimo de 2.")]
        public string Nome { get; set; }
        [Range(1, 1000)]
        public int Idade { get; set; }
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Maximo de 100, minimo de 5")]
        public string Linhagem { get; set;}
        public string Altura { get; set; }
        [Required]
        public string Status { get; set; }
        [StringLength(13, ErrorMessage = "Maximo de 13.")]
        public string Recompensa { get; set; }
        [StringLength(300, MinimumLength = 10, ErrorMessage = "Maximo de 300, minimo de 10")]
        public string FraseMarcante { get; set; }
        [StringLength(200, MinimumLength = 10, ErrorMessage = "Maximo de 100, minimo de 10")]
        public string PrimeiraAparicao { get; set; }
        [Required]
        public int ArcoId { get; set; }
        [StringLength(20000, MinimumLength = 1000, ErrorMessage = "Maximo de 20000, minimo de 1000")]
        public string Descricao { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "Maximo de 300")]
        public string ImagemUrl { get; set;}
        public bool? Top5 { get; set; }
        public virtual AkumaNoMi AkumaNoMi { get; set; }
        public int? AkumaNoMiId { get; set;}
    }
}