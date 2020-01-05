using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SIED.Models;
using SIED.Models.ViewModels;

namespace SIED.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categorias() {
            return View();
        }
        
        public ActionResult Preguntas()
        {
            List<listPreguntasViewModel> lst = new List<listPreguntasViewModel>();
            List<listCategoriaViewModel> lstCategorias = new List<listCategoriaViewModel>();
            dynamic mymodel = new ExpandoObject();

            using (siedEntities db = new siedEntities())
            {
                mymodel.Categorias = (from d in db.CategoriaPreguntas
                                select new listCategoriaViewModel
                                {
                                    Id = d.id,
                                    Nombre = d.nombre,
                                    Comentario = d.comentario
                                }).ToList();
                mymodel.Preguntas = (from d in db.Preguntas
                       select new listPreguntasViewModel
                       {
                           Id = d.id,
                           Pregunta = d.pregunta1,
                           IdCategoria = d.idCategoria
                       }).ToList();
            }
            return View(mymodel);
        }

        
    }
}