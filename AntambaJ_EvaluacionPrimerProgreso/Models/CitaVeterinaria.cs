using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AntambaJ_EvaluacionPrimerProgreso.Models
{
    public class CitaVeterinaria

    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaVisita { get; set; }

        [Required]
        [MaxLength(50)]
        //En esta parte se puede poner las tres cosas que s nos pido vacunacion, revision general y cirugia
        public string Motivo { get; set; }


        [Required]
        [Range(0, 1000)]
        public decimal Tarifa
        {
            get
            {
                return Motivo.ToLower() switch
                {
                    "vacunacion" => 50,
                    "revision general" => 20,
                    "cirugia" => 100,
                    _ => 0
                };
            }
        }

        [Required]
        public bool RequiereMedicacion { get; set; }


        public int MascotaId { get; set; }

        [ForeignKey("MascotaId")]
        public Mascota? Mascota { get; set; }
    }

}
