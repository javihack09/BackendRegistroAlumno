namespace RegistroEstudiantes.Models
{
    public class RegistroLogin
    {
        public string? nombrecompleto { get; set; }
        public string? correo { get; set; }
        public string? rol { get; set; }
        public string? clave { get; set; }

    }
    public class Estudiante
    {
        public string? nombreAlumno { get; set; }

        public string? nombreMateria { get; set; }
        public string? nombreProfesor { get; set; }

    }
    public class Estudiante1
    {
        public int IdEstudiante { get; set; }

        public string? NombreAlumno { get; set; }

        public string? creditos { get; set; }

        public int Materia1 { get; set; }

        public int Materia2 { get; set; }

        public int Materia3 { get; set; }

    }
    public class Materias
    {
        public int IdMaterias { get; set; }

        public string? NombreMateria { get; set; }

        public string? Creditos { get; set; }
        public string? idProfesor { get; set; }
        public string? NombreProfesor { get; set; }

    }
}
