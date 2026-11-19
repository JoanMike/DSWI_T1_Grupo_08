using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSWI_T1_Grupo_08.Models;

public partial class Libro
{
    public int LibroId { get; set; }

    [Required(ErrorMessage = "Ingrese el título del libro.")]
    [StringLength(100, ErrorMessage = "El título admite hasta 100 caracteres.")]
    public string? Titulo { get; set; }

    [StringLength(50, ErrorMessage = "El género admite hasta 50 caracteres.")]
    public string? Genero { get; set; }

    [Range(0, 2100, ErrorMessage = "El año de publicación debe estar entre 0 y 2100.")]
    public int? AñoPublicacion { get; set; }

    [StringLength(20, ErrorMessage = "El ISBN admite hasta 20 caracteres.")]
    public string? Isbn { get; set; }

    public int? AutorId { get; set; }

    public virtual Autore? Autor { get; set; }
}
