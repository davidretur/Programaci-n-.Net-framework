using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DEstatusAlumno : IDEstatusAlumno
    {
        List<EstatusAlumno> _estatusAlumnoList = new List<EstatusAlumno>();
        string _cnnString = ConfigurationManager.ConnectionStrings["IstitutoConnection"].ConnectionString;
        private SqlCommand comando;
        public List<EstatusAlumno> ConsultarTodos()
        {
            string query = "ConsultarEstatusAlumnoWeb";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                _estatusAlumnoList = new List<EstatusAlumno>();
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    _estatusAlumnoList.Add(
                       new EstatusAlumno()
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
        public EstatusAlumno ConsultarSoloUno(int idEstatus)
        {
            EstatusAlumno consultarEstatus = new EstatusAlumno();

            string query = "ConsultarEstatusWebId";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idEstatus", idEstatus);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();

                consultarEstatus = (
                        new EstatusAlumno()
                        {
                            id = Convert.ToInt16(reader["id"]),
                            clave = reader["clave"].ToString(),
                            nombre = reader["nombre"].ToString(),
                        });

                con.Close();
            }
            return consultarEstatus;
        }

        public bool Actualizar(EstatusAlumno aEstatusAlumno)
        {
            throw new NotImplementedException();
        }

        public bool Agregar(EstatusAlumno aEstatusAlumno)
        {
            throw new NotImplementedException();
        }


        public bool Eliminar(int idEstatus)
        {
            throw new NotImplementedException();
        }
    }
}
