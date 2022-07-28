using System;
using System.Collections.Generic;

#nullable disable

namespace DataBase.Model
{
    public partial class Libro
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int? NumeroPaginas { get; set; }
        public int IdAutor { get; set; }
        public int Anio { get; set; }

        public virtual Autor Autor { get; set; }
    }
}
