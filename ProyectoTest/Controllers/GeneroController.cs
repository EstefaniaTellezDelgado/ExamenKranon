using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoTest.Controllers
{
    public class GeneroController : Controller
    {
        // GET: Genero
        public ActionResult GetAll()
        {
            ML.Genero genero = new ML.Genero();
            ML.Result result = BL.Genero.GetAll();

            if (result.Correct)
            {
                genero.Generos = result.Objects;
            }
            return View(genero);
        }
        [HttpGet]
        public ActionResult Form(int? IdGenero)
        {
            ML.Result result = new ML.Result();
            ML.Genero genero = new ML.Genero();

            if (IdGenero == null)
            {
                return View();
            }
            else
            {
                result = BL.Genero.GetById(IdGenero.Value);
                if (result.Correct)
                {
                    ML.Genero genero1 = (ML.Genero)result.Object;

                    return View(genero1);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Genero genero)
        {
            ML.Result result = new ML.Result();

            if (genero.IdGenero == 0)
            {
                result = BL.Genero.Add(genero);
                if (result.Correct)
                {
                    ViewBag.Message = "El genero se ha agregado";
                }
                else
                {

                    ViewBag.Message = "El genero no se agrego";
                }
            }
            else
            {
                result = BL.Genero.Update(genero);
                if (result.Correct)
                {
                    ViewBag.Message = "El genero se ha actualizado";
                }
                else
                {
                    ViewBag.Message = "Hubo un error al actualizar el genero";
                }
            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(ML.Genero genero)
        {
            ML.Result result = BL.Genero.Delete(genero);

            if (result.Correct)
            {
                ViewBag.Message = "El genero se elimino correctamente";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al eliminar el genero" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }
    }
}