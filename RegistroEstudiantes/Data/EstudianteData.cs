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

        public async Task<List<Estudiante>> Lista()
        {
            List<Estudiante> lista = new List<Estudiante>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from Estudiante", con);
                cmd.CommandType = CommandType.Text;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {

                        lista.Add(new Estudiante
                        {

                            IdEstudiante = Convert.ToInt32(reader["IdEstudiante"]),
                            NombreAlumno = reader["NombreAlumno"].ToString(),
                            Materia1 = reader["Materia1"].ToString(),
                            Materia2 = reader["Materia2"].ToString(),
                            Materia3 = reader["Materia3"].ToString()

                        });

                    }

                }
            }

            return lista;

        }

        public async Task<bool> RegistroAlumno(Estudiante1 objeto)
        {
            bool respuesta = true;

            using (var con = new SqlConnection(conexion))
            {
                
                string insertQuery = @"sp_crearAlumno";

                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@NombreAlumno", objeto.NombreAlumno);
                cmd.Parameters.AddWithValue("@creditos", 9 );
                cmd.Parameters.AddWithValue("@Materia1", objeto.Materia1);
                cmd.Parameters.AddWithValue("@Materia2", objeto.Materia2);
                cmd.Parameters.AddWithValue("@Materia3", objeto.Materia3);

                try
                {
                    await con.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true:false ;
                    
                }
                catch 
                {
                    respuesta = false;
                
                }
            }

            return respuesta;

        }

        public async Task<List<Materias>> Materias()
        {
            List<Materias> lista = new List<Materias>();

            using (var con = new SqlConnection(conexion))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from Materias", con);
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
                            idProfesor = reader["idProfesor"].ToString()

                        });

                    }

                }
            }

            return lista;

        }



    }
}
