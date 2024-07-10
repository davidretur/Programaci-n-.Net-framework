using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOEstatusAlumnos
{
    public class CrudADO: ICRUDEstatus
    {
        List<EstatusAlumnos> _estatusAlumnoList = new List<EstatusAlumnos>();
        string _cnnString = ConfigurationManager.ConnectionStrings["IstitutoConnection"].ConnectionString;
        private SqlCommand comando;

        public List<EstatusAlumnos> ConsultarTodos()
        {
            // where id=@id or @id<0
            _estatusAlumnoList = new List<EstatusAlumnos>();
            string query = $"select id, Clave, nombre from EstatusAlumnos";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    _estatusAlumnoList.Add(
                        new EstatusAlumnos()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            clave = reader["clave"].ToString(),
                            nombre = reader["nombre"].ToString(),
                        });
                }
                con.Close();
            }
            return _estatusAlumnoList;
        }

        public EstatusAlumnos ConsultarSoloUno(int idEstatus)
        {
            EstatusAlumnos estatusAlumnos = new EstatusAlumnos(); 

            string query = $"select id, clave, nombre from EstatusAlumnos where id = {idEstatus}";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();

                estatusAlumnos = (
                        new EstatusAlumnos()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            clave = reader["clave"].ToString(),
                            nombre = reader["nombre"].ToString(),
                        });

                con.Close();
            }
            return estatusAlumnos;
    


        }

        public int Agregar(EstatusAlumnos aEstatusAlumno)
        {
            string query = "InsertarEstatusAlumno";
            
            int rowsAffected;
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@clave", aEstatusAlumno.clave);
                comando.Parameters.AddWithValue("@nombre", aEstatusAlumno.nombre);
                comando.Parameters.AddWithValue("@idNuevo", aEstatusAlumno.id);
                con.Open();
                // Ejecuta el comando
                rowsAffected = (Int32)comando.ExecuteScalar();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Registro insertado correctamente.");
                }
                else
                {
                    Console.WriteLine("No se pudo insertar el registro.");
                }
               con.Close();
            }
            return aEstatusAlumno.id;


        }



        public void Actualizar(EstatusAlumnos aEstatusAlumno)
        {
         string query = $"UPDATE EstatusAlumnos SET clave = '{aEstatusAlumno.clave}', nombre = '{aEstatusAlumno.nombre}' WHERE id={aEstatusAlumno.id}";
         using (SqlConnection con = new SqlConnection(_cnnString))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                int rowsAffected = comando.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Registro Actualizado correctamente.");
                }
                else
                {
                    Console.WriteLine("No se pudo actualizar el registro.");
                }
                con.Close();
            }
        }

        public void Eliminar(int idEstatus)
        {
            string query = $"DELETE EstatusAlumnos where id={idEstatus}";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.Text;
                con.Open();
                int rowsAffected = comando.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Registro Eliminado correctamente.");
                }
                else
                {
                    Console.WriteLine("No se pudo Eliminado el registro.");
                }
                con.Close();

            }
        }


    }
}
