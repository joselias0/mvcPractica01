using System.ComponentModel.DataAnnotations;

namespace mvcPractica01.Models
{
    public class carreras
    {
        [Key]
        [Display(Name = "ID")]
        public int carrera_id { get; set; }
        [Display(Name = "Nombre carrera")]
        public string? nombre_carrera { get; set; }
        [Display(Name = "ID Facultad")]
        public int? facultad_id { get; set; }

    }
}
