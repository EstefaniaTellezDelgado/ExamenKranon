using System.Web.Http;

namespace API.Controllers
{
    public class LibroController : ApiController
    {
        // GET: Libro
        [HttpGet]

        [Route("api/Libro/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();

            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();

            ML.Result result = BL.Libro.GetAll(libro);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]
        [Route("api/Libro/Add")]
        public IHttpActionResult Post([FromBody] ML.Libro libro)
        {
            ML.Result result = BL.Libro.Add(libro);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        [Route("api/Libro/GetById/{IdLibro}")]
        public IHttpActionResult GetById(int IdLibro)
        {
            ML.Libro libro = new ML.Libro();

            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Genero = new ML.Genero();

            ML.Result result = BL.Libro.GetById(IdLibro);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }


        [HttpGet]
        [Route("api/Libro/Delete/{IdLibro}")]
        public IHttpActionResult Delete(int IdLibro)
        {
            ML.Libro libro = new ML.Libro();

            ML.Result result = BL.Libro.Delete(IdLibro);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
    }

}