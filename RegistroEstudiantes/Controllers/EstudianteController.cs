﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using RegistroEstudiantes.Data;
using RegistroEstudiantes.Models;

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

        [HttpGet("materias")]
        public async Task<IActionResult> Materias()
        {
            List<Materias> Lista = await _estudiantedata.Materias();

            return StatusCode(StatusCodes.Status200OK, Lista);
        }

        [HttpPost]
        public async Task<IActionResult> RegistroAlumno([FromBody] Estudiante1 objeto)
        {
            bool respuesta = await _estudiantedata.RegistroAlumno(objeto);

            return StatusCode(StatusCodes.Status200OK, new {isSuccess = respuesta});
        }
    }
}