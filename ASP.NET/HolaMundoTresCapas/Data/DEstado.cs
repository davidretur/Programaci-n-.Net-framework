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
    public class DEstado : IDEstado
    {
        List<Estado> _estadoList = new List<Estado>();
        string _cnnString = ConfigurationManager.ConnectionStrings["IstitutoConnection"].ConnectionString;
        private SqlCommand comando;
        public List<Estado> ConsultarTodos()
        {
            string query = "ConsultarEstadoWeb";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                _estadoList = new List<Estado>();
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    _estadoList.Add(
                       new Estado()
                       {
                           id = Convert.ToInt32(reader["id"]),
                           nombre = reader["nombre"].ToString(),
                       });
                }
                con.Close();
            }
            return _estadoList;
        }
        public Estado ConsultarSoloUno(int idEstado)
        {
            Estado consultarEstado = new Estado();

            string query = "ConsultarEstadoWebId";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idEstado", idEstado);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();

                consultarEstado = (
                        new Estado()
                        {
                            id = Convert.ToInt16(reader["id"]),
                            nombre = reader["nombre"].ToString(),
                        });

                con.Close();
            }
            return consultarEstado;
        }
        public bool Actualizar(Estado dEstado)
        {
            throw new NotImplementedException();
        }

        public bool Agregar(Estado dEstado)
        {
            throw new NotImplementedException();
        }





        public bool Eliminar(int idAlumno)
        {
            throw new NotImplementedException();
        }
    }
}
