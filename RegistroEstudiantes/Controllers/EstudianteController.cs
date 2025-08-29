using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using RegistroEstudiantes.Data;
using RegistroEstudiantes.Models;
using RegistroEstudiantes.Utilidades;

namespace RegistroEstudiantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly EstudianteData _estudiantedata;

        public EstudianteController(EstudianteData estudiantedata)
        {
            _estudiantedata = estudiantedata;
        }

        [HttpGet("lista")]
        public async Task<IActionResult> Lista()
        {
            List<Estudiante> Lista = await _estudiantedata.Lista();

            return StatusCode(StatusCodes.Status200OK, Lista);
        }
        [HttpGet("clase")]
        public async Task<IActionResult> verClase(string clase)
        {
            List<Estudiante> Lista = await _estudiantedata.verClase(clase);

            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [HttpGet("materias")]
        public async Task<IActionResult> Materias()
        {
            List<Materias> Lista = await _estudiantedata.Materias();

            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener(int id)
        {
            List<Estudiante> Lista = await _estudiantedata.Obtener(id);

            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [HttpPost]
        public async Task<IActionResult> RegistroAlumno([FromBody] Estudiante1 objeto)
        {
            string respuesta = await _estudiantedata.RegistroAlumno(objeto);

            return StatusCode(StatusCodes.Status200OK, new {id = respuesta});
        }
        [HttpPost("RegistroLogin")]
        public async Task<IActionResult> RegistroLogin([FromBody] RegistroLogin objeto)
        {
            if (!string.IsNullOrWhiteSpace(objeto.clave))
            {
                objeto.clave = EncripcionAES.Encrypt(objeto.clave);
            }

            int respuesta = await _estudiantedata.RegistrarUsuario(objeto);

            return StatusCode(StatusCodes.Status200OK, new { id = respuesta });
        }

        [HttpGet("Duplicidad")]
        public async Task<IActionResult> Duplicidad(string correo)
        {
            int conteo = await _estudiantedata.Duplicidad(correo);

            return StatusCode(StatusCodes.Status200OK, new { duplicidad = (conteo >= 1) });
        }

        [HttpGet("DobleRegistro")]
        public async Task<IActionResult> DobleRegistro(string idregistro)
        {
            int conteo = await _estudiantedata.DobleRegistro(idregistro);

            return StatusCode(StatusCodes.Status200OK, new { duplicidad = (conteo >= 1) });
        }

        [HttpGet("InicioSesion")]
        public async Task<IActionResult> InicioSesion(string correo,string clave)
        {
            string clavedecrypt = ""; 

            if (!string.IsNullOrWhiteSpace(clave))
            {
                clavedecrypt = EncripcionAES.Encrypt(clave);
            }

            int idregistro =  await _estudiantedata.IniciarSesion(correo, clavedecrypt); 

            return StatusCode(StatusCodes.Status200OK, new { id = idregistro });
        }

    }
}
