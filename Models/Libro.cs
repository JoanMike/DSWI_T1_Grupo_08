using System;
using System.Collections.Generic;

namespace DSWI_T1_Grupo_08.Models;

public partial class Libro
{
    public int LibroId { get; set; }

    public string? Titulo { get; set; }

    public string? Genero { get; set; }

    public int? AñoPublicacion { get; set; }

    public string? Isbn { get; set; }

    public int? AutorId { get; set; }

    public virtual Autore? Autor { get; set; }
}
