using Microsoft.AspNetCore.Mvc;
// Agregar el espacio de nombre Models para usar la clase Alumno
using JAGS20240912.Models;

namespace JAGS20240912.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnosController : ControllerBase
    {
        //Declaracion de una lista estatica de objetos
        // "Alumno" para almacenar alumnos
        static List<Alumno> alumnos = new List<Alumno>();

        // Definicion de los metodos HTTP 
        // que devuelve una coleccion de alumnos
        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return alumnos;
        }

        // recibe un ID como parametro y devuelve un alumno especifico
        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            var alumno = alumnos.FirstOrDefault(c => c.Id == id);
            return alumno;
        }

        // para agregar un nuevo Alumno a la lista
        [HttpPost]
        public IActionResult Post([FromBody] Alumno alumno)
        {
            alumnos.Add(alumno);
            return Ok();
        }

        //Para actualizar un alumno existente en la lista por su ID
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Alumno alumno)
        {
            var existingAlumno = alumnos.FirstOrDefault(c => c.Id == id);
            if (existingAlumno != null)
            {
                existingAlumno.Name = alumno.Name;
                existingAlumno.LastName = alumno.LastName;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // para eliminar un alumno por su ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingAlumno = alumnos.FirstOrDefault(c => c.Id == id);
            if (existingAlumno != null)
            {
                alumnos.Remove(existingAlumno);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
