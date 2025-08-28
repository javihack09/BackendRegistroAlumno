using Microsoft.AspNetCore.Mvc.Routing;
using RegistroEstudiantes.Models;
using System.Data;
using System.Data.SqlClient;

namespace RegistroEstudiantes.Data
{
    public class EstudianteData
    {
        private readonly string conexion;

        public EstudianteData(IConfiguration configuration)
        {
            conexion = configuration.GetConnectionString("StringSQL")!;
        }

        public async Task<int> IniciarSesion(string correo,string clave)
        {
            int IdGenerado = 0;

            using (var con = new SqlConnection(conexion))
            {
                string insertQuery = @"select IdRegistro from RegistroLogin where Correo = @Correo AND Clave = @Clave;";

                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@Clave", clave);
                try
                {
                    await con.OpenAsync();
                    IdGenerado = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }
                catch
                {
                    IdGenerado = 0;
                }
            }

            return IdGenerado;
        }

        public async Task<int> Duplicidad(string correo)
        {
            int conteo = 0;

            using (var con = new SqlConnection(conexion))
            {
                string insertQuery = @"select COUNT(Correo) from RegistroLogin where Correo = @Correo;";

                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Correo", correo);
                try
                {
                    await con.OpenAsync();
                    conteo = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }
                catch
                {
                    conteo = 0;
                }
            }

            return conteo;
        }

        public async Task<int> RegistrarUsuario(RegistroLogin objeto)
        {
            int idGenerado = 0;

            using (var con = new SqlConnection(conexion))
            {
                string insertQuery = @"
            INSERT INTO RegistroLogin (NombreCompleto, Correo, Rol, Clave) 
            VALUES (@NombreCompleto, @Correo, @Rol, @Clave);
            SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@NombreCompleto", objeto.nombrecompleto); 
                cmd.Parameters.AddWithValue("@Correo", objeto.correo);
                cmd.Parameters.AddWithValue("@Rol", objeto.rol);
                cmd.Parameters.AddWithValue("@Clave", objeto.clave); 
                try
                {
                    await con.OpenAsync();
                    idGenerado = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                }
                catch
                {
                    idGenerado = 0;
                }
            }

            return idGenerado;
        }


        public async Task<List<Estudiante>> Lista()
        {
            List<Estudiante> lista = new List<Estudiante>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("select NombreAlumno as nombreAlumno ,C.NombreMateria as nombreMateria,D.NombreProfesor as nombreProfesor from MateriasEstudiante as A inner join Estudiante as B ON A.IdEstudiante = B.IdEstudiante inner join Materias as C ON C.IdMaterias = A.IdMateria inner join Profesor as D ON C.idProfesor = D.IdProfesor", con);
                cmd.CommandType = CommandType.Text;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {

                        lista.Add(new Estudiante
                        {

                            nombreAlumno = reader["nombreAlumno"].ToString(),
                            nombreMateria = reader["nombreMateria"].ToString(),
                            nombreProfesor = reader["nombreProfesor"].ToString()

                        });

                    }

                }
            }

            return lista;

        }

        public async Task<int> RegistroAlumno(Estudiante1 objeto)
        {

            int idGenerado = 0; 

            using (var con = new SqlConnection(conexion))
            {
                
                string insertQuery = @"sp_crearAlumno";

                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@IdEstudiante", objeto.IdEstudiante);
                cmd.Parameters.AddWithValue("@creditos", 9 );
                cmd.Parameters.AddWithValue("@Materia1", objeto.Materia1);
                cmd.Parameters.AddWithValue("@Materia2", objeto.Materia2);
                cmd.Parameters.AddWithValue("@Materia3", objeto.Materia3);

                try
                {
                    await con.OpenAsync();
                    idGenerado = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                }
                catch 
                {
                    idGenerado = 0;
                
                }
            }

            return idGenerado;

        }

        public async Task<List<Materias>> Materias()
        {
            List<Materias> lista = new List<Materias>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("select IdMaterias,NombreMateria,Creditos,A.idProfesor,NombreProfesor,selected from Materias as A inner join [dbo].[Profesor] as B ON A.idProfesor = B.IdProfesor", con);
                cmd.CommandType = CommandType.Text;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {

                        lista.Add(new Materias
                        {

                            IdMaterias = Convert.ToInt32(reader["IdMaterias"]),
                            NombreMateria = reader["NombreMateria"].ToString(),
                            Creditos = reader["Creditos"].ToString(),
                            idProfesor = reader["idProfesor"].ToString(),
                            NombreProfesor = reader["NombreProfesor"].ToString()

                        });

                    }

                }
            }

            return lista;

        }

        public async Task<List<Estudiante>> Obtener(int Id)
        {
            List<Estudiante> lista = new List<Estudiante>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_obtener", con);
                cmd.Parameters.AddWithValue("@idAlumno",Id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {

                        lista.Add(new Estudiante
                        {

                            nombreAlumno = reader["nombreAlumno"].ToString(),
                            nombreMateria = reader["nombreMateria"].ToString(),
                            nombreProfesor = reader["nombreProfesor"].ToString()

                        });

                    }

                }
            }

            return lista;

        }

        public async Task<List<Estudiante>> verClase(string clase)
        {
            List<Estudiante> lista = new List<Estudiante>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();

                SqlCommand cmd = new SqlCommand("select NombreAlumno as nombreAlumno, C.NombreMateria as nombreMateria, D.NombreProfesor as nombreProfesor from MateriasEstudiante as A inner join Estudiante as B ON A.IdEstudiante = B.IdEstudiante inner join Materias as C ON C.IdMaterias = A.IdMateria inner join Profesor as D ON C.idProfesor = D.IdProfesor where C.NombreMateria = '"+clase+"'", con);
                cmd.CommandType = CommandType.Text;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {

                        lista.Add(new Estudiante
                        {

                            nombreAlumno = reader["nombreAlumno"].ToString(),
                            nombreMateria = reader["nombreMateria"].ToString(),
                            nombreProfesor = reader["nombreProfesor"].ToString()

                        });

                    }

                }
            }

            return lista;

        }



    }
}
