using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DSWI_T1_Grupo_08.Models;

public partial class Autore
{
    public int AutorId { get; set; }

    [Required(ErrorMessage = "Ingrese el nombre del autor.")]
    [StringLength(100, ErrorMessage = "El nombre admite hasta 100 caracteres.")]
    public string? Nombre { get; set; }

    [StringLength(50, ErrorMessage = "La nacionalidad admite hasta 50 caracteres.")]
    public string? Nacionalidad { get; set; }

    public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
