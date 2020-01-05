using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIED.Models.ViewModels
{
    public class listPreguntasViewModel
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public int IdCategoria { get; set; }

    }
}