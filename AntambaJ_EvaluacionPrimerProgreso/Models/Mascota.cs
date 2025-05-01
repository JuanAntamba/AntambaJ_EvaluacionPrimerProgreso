using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AntambaJ_EvaluacionPrimerProgreso.Models
{
    public class Mascota
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Raza { get; set; } = string.Empty;

        [Required]
        public int Edad { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public bool EstaVacunada { get; set; }

        public int PropietarioId { get; set; }

        [ForeignKey("PropietarioId")]
        public Propietario? Propietario { get; set; }

    }
}
