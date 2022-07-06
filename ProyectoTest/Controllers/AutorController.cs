using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AutorController : Controller
    {
        //GET: Autor

        public ActionResult GetAll()
        {
            ML.Result result = BL.Autor.GetAll();
            ML.Autor autor = new ML.Autor();

            if (result.Correct)
            {
                autor.Autores = result.Objects;
            }
            return View(autor);
        }
        [HttpGet]
        public ActionResult Form(int? IdAutor)
        {
            ML.Result result = new ML.Result();
            ML.Autor autor = new ML.Autor();

            if (IdAutor == null)
            {
                return View();
            }
            else
            {
                result = BL.Autor.GetById(IdAutor.Value);
                if (result.Correct)
                {
                    ML.Autor autor1 = (ML.Autor)result.Object;

                    return View(autor1);
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Autor autor)
        {
            ML.Result result = new ML.Result();

            if (autor.IdAutor == 0)
            {
                result = BL.Autor.Add(autor);
                if (result.Correct)
                {
                    ViewBag.Message = "El autor se ha agregado";
                }
                else
                {

                    ViewBag.Message = "El autor no se agrego";
                }
            }
            else
            {
                result = BL.Autor.Update(autor);
                if (result.Correct)
                {
                    ViewBag.Message = "El autor se ha actualizado";
                }
                else
                {
                    ViewBag.Message = "Hubo un error al actualizar el autor";
                }
            }
            return PartialView("Modal");
        }
        [HttpGet]
        public ActionResult Delete(ML.Autor autor)
        {
            ML.Result result = BL.Autor.Delete(autor);

            if (result.Correct)
            {
                ViewBag.Message = "El autor se elimino correctamente";
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al eliminar el autor" + result.ErrorMessage;
            }
            return PartialView("Modal");
        }
    }
}