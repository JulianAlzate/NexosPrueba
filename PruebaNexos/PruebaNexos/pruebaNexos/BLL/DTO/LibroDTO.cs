using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTO
{
    public class LibroDTO
    {
        [Key]
        public int IdLibro { get; set; }

        [Required(ErrorMessage = "El {0} es Requerido")]
        [MaxLength(200)]
        [DataType(DataType.Text)]
        [Display(Name = "Titulo*")]

        [RegularExpression(@"[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "Caracteres no Validos para {0}")]
        public string Titulo { get; set; }


        [Display(Name = "Genero*")]
        [Required(ErrorMessage = "El {0} es Requerido")]
        [MaxLength(200)]
        [DataType(DataType.Text)]
        [RegularExpression(@"[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]*$", ErrorMessage = "Caracteres no Validos para {0}")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "El {0} es Requerido")]
        [Display(Name = "Numero de paginas*")]
        [DataType(DataType.Text)]
        [RegularExpression("^[0-9][0-9]*$", ErrorMessage = "Solo se permiten numeros.")]

        public int? NumeroPaginas { get; set; }

        [Display(Name = "Año*")]
        [Required(ErrorMessage = "El {0} es Requerido")]
        [DataType(DataType.Text)]
        [RegularExpression("^[0-9][0-9]*$", ErrorMessage = "Solo se permiten numeros.")]
        public int Anio { get; set; }
       
        [Required(ErrorMessage = "El {0} es Requerido")]
        [Display(Name = "Autor*")]


        public int IdAutor { get; set; }
        public virtual AutorDTO Autor { get; set; }


        
    }
}
