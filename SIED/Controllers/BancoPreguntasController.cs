using SIED.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services;

namespace SIED.Controllers
{
    public class BancoPreguntasController : Controller
    {
        siedEntities context;
        alertas sweet;
        private string respuesta;
        private string[] alerta;
        CategoriaPregunta categoria;
        public BancoPreguntasController() {
            context = new siedEntities();
            sweet = new alertas();
            categoria = new CategoriaPregunta();
            respuesta = "";
        }
        [WebMethod]
        public ActionResult AgregarCategoria(CategoriaPregunta model) {
            if (ModelState.IsValid){
                categoria.nombre = model.nombre.Trim();
                categoria.comentario = model.comentario.Trim();
                var verificar = context.CategoriaPreguntas.Where(x => x.nombre == categoria.nombre).ToList();
                if (verificar.Count > 0){
                    alerta = new string[] { "simple", "info", "Atención", "Ya existe esta categoría" };
                }else{
                    context.CategoriaPreguntas.Add(categoria);
                    if (context.SaveChanges() > 0){
                        alerta = new string[] { "clean", "success", "Exito", "Se ha añadido exitosamente la categoría" };
                       
                    }else{
                        alerta = new string[] { "simple", "error", "Lo sentimos", "Se ha generado un error intentelo de nuevo" };
                    }
                    
                }
                return JavaScript(sweet.SweetAlert(alerta));
            }
            return Content(respuesta);
        }
        [WebMethod]


        public ActionResult GetCategorias(DataTablesParam param)
        {
            var listCategoria = context.CategoriaPreguntas.OrderBy(x => x.id).Distinct().ToList();
            return Json(new
            {
                aaData = listCategoria,
                sEcho = param.sEcho,
                iDisplayTotalRecords = listCategoria.Count,
                iTotalRecords = listCategoria.Count
            }, JsonRequestBehavior.AllowGet);
        }
   




        [WebMethod]
        public ActionResult ModificarCategoria() {
            categoria = context.CategoriaPreguntas.Find(Convert.ToInt32(Request.Form["id"]));
            categoria.nombre = Request.Form["nombre"].Trim();
            categoria.comentario = Request.Form["comentario"].Trim();
            if (context.SaveChanges() > 0){
                alerta = new string[] { "simple", "success", "Exito", "Se ha actualizado exitosamente la información" };
                return JavaScript(sweet.SweetAlert(alerta));
            }else{
                respuesta = "nop";
            }
            return Content(respuesta);
        }


        [WebMethod]
        public ActionResult EliminarCategoria()
        {
            categoria = new CategoriaPregunta { id = Convert.ToInt32(Request.Form["id"].Trim())};
            context.CategoriaPreguntas.Attach(categoria);
            context.CategoriaPreguntas.Remove(categoria);
            if (context.SaveChanges() > 0){
                alerta = new string[] { "simple", "success", "  Exito", "Se ha eliminado exitosamente" };
                return JavaScript(sweet.SweetAlert(alerta));
            }else{
                respuesta = "nop";
            }
            return Content(respuesta);
        }
        [WebMethod]
        public ActionResult EliminarVariasCategorias() {
            int succes =0;
            string [] response = Request.Form["id"].ToString().Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries);
            foreach (string id in response) {
                var categorias = context.CategoriaPreguntas.Find(int.Parse(id));
                context.CategoriaPreguntas.Remove(categorias);
                succes = context.SaveChanges();
            }
            if (succes > 0){
                alerta = new string[] { "simple", "success", "Exito", "Se ha eliminado exitosamente" };
                return JavaScript(sweet.SweetAlert(alerta));
            }else{
                respuesta = "nop";
            }
            return Content(respuesta);
        }
    }
}
