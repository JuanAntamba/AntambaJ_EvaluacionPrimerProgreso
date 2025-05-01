using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AntambaJ_EvaluacionPrimerProgreso.Models
{
    public class Propietario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Nombre { get; set; }

        [Range(18, 100)]
        public int Edad { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        public bool EsDueñoActivo { get; set; }

        public string AntambaJ { get; set; } = "Antamba J";

        [Required]
        [DataType(DataType.Currency)]
        [Range(0, 10000)]
        public decimal DeudaPendiente { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
    }
}



