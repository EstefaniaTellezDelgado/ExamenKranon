using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult GetAll()
        {
            ML.Libro resultLibro = new ML.Libro();
            resultLibro.Libros = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5971"); //LOCALHOST API

                var responseTask = client.GetAsync("/api/Libro/GetAll");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Libro resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(resultItem.ToString());
                        resultLibro.Libros.Add(resultItemList);
                    }
                }
            }
            return View(resultLibro);
        }
        [HttpPost]
        // BUSQUEDA ABIERTA
        public ActionResult GetAll(ML.Libro libro)
        {
            libro.Titulo = libro.Titulo == null ? "" : libro.Titulo;
            libro.Autor.Nombre = libro.Autor.Nombre == null ? "" : libro.Autor.Nombre;

            ML.Result result = BL.Libro.LibroGetByTituloyAutor(libro);
            if (result.Correct)
            {
                libro.Libros = result.Objects;
                return View(libro);
            }
            else
            {

                ViewBag.Message = "No se encuentran registros";
            }
            libro.Libros = result.Objects;
            return View(libro);
        }

        [HttpGet]
        public ActionResult Form(int? IdLibro)
        {
            ML.Libro libro = new ML.Libro();

            ML.Result resultEditorial = BL.Editorial.GetAll();
            ML.Result resultAutor = BL.Autor.GetAll();
            ML.Result resultGenero = BL.Genero.GetAll();

            if (resultEditorial.Correct && resultAutor.Correct && resultGenero.Correct)
            {

                if (IdLibro == null)
                {
                    libro.Editorial = new ML.Editorial();
                    libro.Editorial.Editoriales = resultEditorial.Objects;

                    libro.Autor = new ML.Autor();
                    libro.Autor.Autores = resultAutor.Objects;

                    libro.Genero = new ML.Genero();
                    libro.Genero.Generos = resultGenero.Objects;
                    return View(libro);

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:5971");
                        var postTask = client.PostAsJsonAsync<ML.Libro>("/api/Libro/Add", libro);
                        postTask.Wait();

                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            ViewBag.Message = "Se agrego el Libro";
                        }
                        else
                        {
                            ViewBag.Message = "No se agrego el Libro";
                        }
                    }
                }
                else
                {
                    libro.Editorial = new ML.Editorial();
                    libro.Editorial.Editoriales = resultEditorial.Objects;

                    libro.Autor = new ML.Autor();
                    libro.Autor.Autores = resultAutor.Objects;

                    libro.Genero = new ML.Genero();
                    libro.Genero.Generos = resultGenero.Objects;

                    ML.Result result = new ML.Result();

                    using (var client = new HttpClient())
                    {
                        try
                        {
                            client.BaseAddress = new Uri("http://localhost:5971");

                            var responseTask = client.GetAsync("/api/Libro/GetById/" + IdLibro);
                            responseTask.Wait();

                            var resultAPI = responseTask.Result;

                            if (resultAPI.IsSuccessStatusCode)
                            {
                                var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                                readTask.Wait();

                                ML.Libro resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Libro>(readTask.Result.Object.ToString());

                                result.Object = resultItemList;

                                libro = ((ML.Libro)result.Object);
                                libro.Libros = result.Objects;

                                //libro = ((ML.Editorial)result.Object);
                                libro.Editorial.Editoriales = resultEditorial.Objects;

                                libro.Autor.Autores = resultAutor.Objects;

                                libro.Genero.Generos = resultGenero.Objects;

                                return View(libro);

                            }
                            else
                            {
                                result.Correct = false;
                                ViewBag.Mensaje = "Ocurrio un error ";
                            }
                        }
                        catch (Exception ex)
                        {
                            result.Correct = false;
                            result.ErrorMessage = ex.Message;
                        }
                    }
                }
            }

            return View();
        }
        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            HttpPostedFileBase file = Request.Files["fuImage"];

            if (file != null)
            {
                libro.Imagen = ConvertToBytes(file);
            }


            if (ModelState.IsValid)
            {

                if (libro.IdLibro == null)
                {
                    result = BL.Libro.Add(libro);
                    if (result.Correct)
                    {
                        ViewBag.Message = "El libro se ha agregado";
                    }
                    else
                    {

                        ViewBag.Message = "El libro no se agrego";
                    }
                }
            }
            else
            {
                ML.Result resultAutor = BL.Autor.GetAll();
                ML.Result resultEditorial = BL.Editorial.GetAll();
                ML.Result resultGenero = BL.Genero.GetAll();

                libro.Autor = new ML.Autor();
                libro.Editorial = new ML.Editorial();
                libro.Genero = new ML.Genero();

                libro.Autor.Autores = resultAutor.Objects;
                libro.Editorial.Editoriales = resultEditorial.Objects;
                libro.Genero.Generos = resultGenero.Objects;

                return View(libro);
            }
            return PartialView("Modal");
        }
        public static byte[] ConvertToBytes(HttpPostedFileBase imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(imagen.InputStream);
            data = reader.ReadBytes((int)imagen.ContentLength);

            return data;
        }
        [HttpGet]
        public ActionResult Delete(int? IdLibro)
        {
            ML.Libro resultListProduct = new ML.Libro();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5971");
                var postTask = client.GetAsync("api/Libro/Delete/" + IdLibro);
                postTask.Wait();

                var resultLibro = postTask.Result;

                if (resultLibro.IsSuccessStatusCode)
                {
                    ViewBag.Message = "El libro se elimino correctamente";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al eliminar el libro" + resultLibro;
                }
            }
            return PartialView("Modal");
        }
    }
}