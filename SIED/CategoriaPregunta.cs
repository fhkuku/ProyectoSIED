//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIED
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CategoriaPregunta
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El campo {0}  es requerido")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        public string comentario { get; set; }
    }
}
