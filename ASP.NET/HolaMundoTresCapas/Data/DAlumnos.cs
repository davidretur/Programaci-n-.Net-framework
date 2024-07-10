using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DAlumnos : IDAlumno
    {
        List<Alumno> _AlumnoList = new List<Alumno>();
        List<ItemTablaISR> _ItemTablaISRList = new List<ItemTablaISR>();
        string _cnnString = ConfigurationManager.ConnectionStrings["pruebasConnection"].ConnectionString;
        private SqlCommand comando;

        public List<Alumno> ConsultarTodos()
        {
            string query = "consultarEAlumnosId";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                _AlumnoList = new List<Alumno>();
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idAlumno", -1);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    _AlumnoList.Add(
                        new Alumno()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            nombre = reader["nombre"].ToString(),
                            primerApellido = reader["primerApellido"].ToString(),
                            segundoApellido = reader["segundoApellido"].ToString(),
                            fechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"].ToString()),
                            correo = reader["correo"].ToString(),
                            telefono = reader["telefono"].ToString(),
                            curp = reader["curp"].ToString(),
                            sueldo = reader["sueldo"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["sueldo"].ToString()),
                            estado = Convert.ToInt32(reader["estado"].ToString()),
                            estatus = Convert.ToInt32(reader["estatus"].ToString()),
                        });
                }
                con.Close();
            }
            return _AlumnoList;
        }
        public Alumno ConsultarSoloUno(int idAlumno)
        {
            Alumno consultarAlumno = new Alumno();

            string query = "ConsultarAlumnoWebId";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@idAlumno", idAlumno);
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                reader.Read();

                consultarAlumno = (
                        new Alumno()
                        {
                            id = Convert.ToInt16(reader["id"]),
                            nombre = reader["nombre"].ToString(),
                            primerApellido = reader["primerApellido"].ToString(),
                            segundoApellido = reader["segundoApellido"].ToString(),
                            fechaNacimiento = Convert.ToDateTime(reader["fechaNacimiento"].ToString()),
                            correo = reader["correo"].ToString(),
                            telefono = reader["telefono"].ToString(),
                            curp = reader["curp"].ToString(),
                            sueldo = reader["sueldo"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["sueldo"].ToString()),
                            estado = Convert.ToInt16(reader["estado"].ToString()),
                            estatus = Convert.ToInt16(reader["estatus"].ToString()),
                        });

                con.Close();
            }
            return consultarAlumno;
        }
        public bool Agregar(Alumno aEstatusAlumno)
        {
            bool respuesta = false;
            string query = "AgregarAlumnosWeb";
            using (SqlConnection oConexion = new SqlConnection(_cnnString))
            {

                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.Parameters.AddWithValue("@Nombre", aEstatusAlumno.nombre);
                cmd.Parameters.AddWithValue("@primerApellido", aEstatusAlumno.primerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", aEstatusAlumno.segundoApellido);
                cmd.Parameters.AddWithValue("@Correo", aEstatusAlumno.correo);
                cmd.Parameters.AddWithValue("@telefono", aEstatusAlumno.telefono);
                cmd.Parameters.AddWithValue("@fechaNacimiento", aEstatusAlumno.fechaNacimiento);
                cmd.Parameters.AddWithValue("@curp", aEstatusAlumno.curp);
                cmd.Parameters.AddWithValue("@sueldo", aEstatusAlumno.sueldo);
                cmd.Parameters.AddWithValue("@idEstadoOrigen", aEstatusAlumno.estado);
                cmd.Parameters.AddWithValue("@idEstatus", aEstatusAlumno.estatus);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0) respuesta = true;

                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public bool Actualizar(Alumno aEstatusAlumno)
        {
            bool respuesta = false;
            string query = "ActualizarAlumnosWebId";
            using (SqlConnection oConexion = new SqlConnection(_cnnString))
            {

                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.Parameters.AddWithValue("@id", aEstatusAlumno.id);
                cmd.Parameters.AddWithValue("@Nombre", aEstatusAlumno.nombre);
                cmd.Parameters.AddWithValue("@primerApellido", aEstatusAlumno.primerApellido);
                cmd.Parameters.AddWithValue("@segundoApellido", aEstatusAlumno.segundoApellido);
                cmd.Parameters.AddWithValue("@Correo", aEstatusAlumno.correo);
                cmd.Parameters.AddWithValue("@telefono", aEstatusAlumno.telefono);
                cmd.Parameters.AddWithValue("@fechaNacimiento", aEstatusAlumno.fechaNacimiento);
                cmd.Parameters.AddWithValue("@curp", aEstatusAlumno.curp);
                cmd.Parameters.AddWithValue("@sueldo", aEstatusAlumno.sueldo);
                cmd.Parameters.AddWithValue("@idEstadoOrigen", aEstatusAlumno.estado);
                cmd.Parameters.AddWithValue("@idEstatus", aEstatusAlumno.estatus);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0) respuesta = true;

                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public bool Eliminar(int idAlumno)
        {
            bool respuesta = false;
            string query = "EliminarAlumnosWeb";
            using (SqlConnection oConexion = new SqlConnection(_cnnString))
            {

                SqlCommand cmd = new SqlCommand(query, oConexion);
                cmd.Parameters.AddWithValue("@idEliminar", idAlumno);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0) respuesta = true;

                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<ItemTablaISR> ConsultarTablaISR()
        {
            string query = "ConsultarTablaISRWeb";
            using (SqlConnection con = new SqlConnection(_cnnString))
            {
                _AlumnoList = new List<Alumno>();
                comando = new SqlCommand(query, con);
                comando.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    _ItemTablaISRList.Add(
                        new ItemTablaISR()
                        {
                            limiteInferior = Convert.ToDecimal(reader["limInf"]),
                            limiteSuperior = Convert.ToDecimal(reader["limSup"]),
                            cuotaFija = Convert.ToDecimal(reader["cuotaFija"]),
                            excedente = Convert.ToDecimal(reader["exedLimInf"]),
                            subsidio = Convert.ToDecimal(reader["subsidio"]),
                            isr = 0
                        });
                }
                con.Close();
            }
            return _ItemTablaISRList;
        }
    }
}
