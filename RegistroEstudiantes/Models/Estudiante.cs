namespace RegistroEstudiantes.Models
{
    public class Estudiante
    {
        public int IdEstudiante { get; set; }

        public string? NombreAlumno { get; set; }

        public string? Materia1 { get; set; }
        public string? Materia2 { get; set; }
        public string? Materia3 { get; set; }

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

    }
}
