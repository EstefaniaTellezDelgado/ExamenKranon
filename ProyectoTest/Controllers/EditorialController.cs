using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class EditorialController : Controller
    {
        // GET: Editorial
        public ActionResult GetAll()
        {
            ML.Editorial editorial = new ML.Editorial();
            ML.Result result = BL.Editorial.GetAll();

            if (result.Correct)
            {
                editorial.Editoriales = result.Objects;
            }
            return View(editorial);
        }
        [HttpGet]
        public ActionResult Form(int? IdEditorial)
        {
            ML.Result result = new ML.Result();
            ML.Editorial editorial = new ML.Editorial();

            if (IdEditorial == null)
            {
                return View();
            }
            else
            {
                result = BL.Editorial.GetById(IdEditorial.Value);
                if (result.Correct)
                {
                    ML.Editorial editorial1 = (ML.Editorial)result.Object;

                    return View(editorial1);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Editorial editorial)
        {
            ML.Result result = new ML.Result();

            if (editorial.IdEditorial == 0)
            {
                result = BL.Editorial.Add(editorial);
                if (result.Correct)
                {
                    ViewBag.Message = "La editorial se ha agregado";
                }
                else
                {

                    ViewBag.Message = "La editorial no se agrego";
                }
            }
            else
            {
                result = BL.Editorial.Update(editorial);
                if (result.Correct)
                {
                    ViewBag.Message = "La editorial se ha actualizado";
                }
                else
                {
                    ViewBag.Message = "Hubo un error al actualizar la editorial";
                }
            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(ML.Editorial editorial)
        {
            ML.Result result = BL.Editorial.Delete(editorial);

            if (result.Correct)
            {
                ViewBag.Message = "La editorial se elimino correctamente";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al eliminar la editorial" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }
        [HttpPost]
        // BUSQUEDA ABIERTA
        public ActionResult GetAll(ML.Editorial editorial)
        {

            ML.Result result = BL.Libro.LibroGetByEditorial(editorial);
            if (result.Correct)
            {
                editorial.Nombre = editorial.Nombre == null ? "" : editorial.Nombre;
            }
            else
            {

                ViewBag.Message = "No se encuentran registros";
            }
            editorial.Editoriales = result.Objects;
            return View(editorial);
        }
    }
}