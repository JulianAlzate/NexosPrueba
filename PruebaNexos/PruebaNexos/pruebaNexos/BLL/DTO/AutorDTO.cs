using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BLL.DTO
{
    public class AutorDTO
    {
        [Key]
        public int IdAutor { get; set; }

     
        [Display(Name = "Nombre  autor*")]
        [Required(ErrorMessage = "El {0} es Requerido")]
        [MaxLength(200)]
        [DataType(DataType.Text)]
        [RegularExpression(@"[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "Caracteres no Validos para {0}")]
        public string NombreAutor { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Fecha de nacimiento*")]
        public DateTime FechaNacimiento { get; set; }


        [Display(Name = "Ciudad de procedencia*")]
        [Required(ErrorMessage = "El {0} es Requerido")]
        [MaxLength(100)]
        [DataType(DataType.Text)]
        [RegularExpression(@"[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "Caracteres no Validos para {0}")]
        public string CiudadProcedencia { get; set; }

       
        [Display(Name = "Correo electronico*")]
        [Required(ErrorMessage = "El {0} es Requerido")]
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        public string Correo { get; set; }

        public virtual ICollection<LibroDTO> Libros { get; set; }


       
    }
}
