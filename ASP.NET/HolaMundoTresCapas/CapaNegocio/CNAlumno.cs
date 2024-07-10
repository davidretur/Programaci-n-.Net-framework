using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using Data;
using Newtonsoft.Json;
namespace CapaNegocio
{
    public class CNAlumno
    {
        DAlumnos _dAlumnos = new DAlumnos();  

        public List<Alumno> ConsultarTodos()
        {
            try
            {
                return _dAlumnos.ConsultarTodos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Alumno ConsultarSoloUno(int idAlumno)
        {
            try
            {
                return _dAlumnos.ConsultarSoloUno(idAlumno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Agregar(Alumno alumnoAgregar)
        {
            try
            {
                /*if (alumnoAgregar.nombre == "")
                    throw new OperationCanceledException("Ingresa un nombre");*/

                return _dAlumnos.Agregar(alumnoAgregar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Editar(Alumno alumnoEditar)
        {
            try
            {

              /*  var encontrado = _aDOCRUDAlumno.ConsultarSoloUno(alumnoEditar.id);
                if (encontrado.id == 0)
                    throw new OperationCanceledException("No existe el alumno");*/
                return _dAlumnos.Actualizar(alumnoEditar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Eliminar(int idAlumno)
        {
            try
            {
         /*       var encontrado = _aDOCRUDAlumno.ConsultarSoloUno(idAlumno);
                if (encontrado.id == 0)
                    throw new OperationCanceledException("No existe el Alumno");*/

                return _dAlumnos.Eliminar(idAlumno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ItemTablaISR CalcularISR(int id)
        {
            ItemTablaISR itemTablaISR = new ItemTablaISR();
            try
            {
                refWsAlumno.WSAlumnosSoapClient wSAlumnosSoap = new refWsAlumno.WSAlumnosSoapClient();
                refWsAlumno.ItemTablaISR refsImss = wSAlumnosSoap.CalcularISR(id);
                string json = JsonConvert.SerializeObject(refsImss);
                itemTablaISR = JsonConvert.DeserializeObject<ItemTablaISR>(json);
            }
            catch (Exception)
            {
                Alumno alumno = ConsultarSoloUno(id);
                decimal sueldo = Convert.ToDecimal(alumno.sueldo);
                decimal sueldoQuincenal = sueldo / 2;

                List<ItemTablaISR> listaTablaISRs = _dAlumnos.ConsultarTablaISR();

                decimal isrCalculado = 0;

                // Encontrar el rango en la tabla ISR que corresponde al sueldo mensual
                var rangoISR = listaTablaISRs.Find(r => sueldoQuincenal >= r.limiteInferior && sueldoQuincenal <= r.limiteSuperior);

                if (rangoISR != null)
                {
                    // Calcular ISR utilizando la fórmula
                    isrCalculado = rangoISR.cuotaFija + (rangoISR.excedente / 100) * (sueldoQuincenal - rangoISR.limiteInferior);
                }

                itemTablaISR.limiteInferior = rangoISR.limiteInferior;
                itemTablaISR.limiteSuperior = rangoISR.limiteSuperior;
                itemTablaISR.cuotaFija = rangoISR.cuotaFija;
                itemTablaISR.excedente = rangoISR.excedente;
                itemTablaISR.subsidio = rangoISR.subsidio;
                itemTablaISR.isr = isrCalculado;
            }



                return itemTablaISR;

        }
        public AportacionesIMSS CalcularIMSS(int id)
        {
            AportacionesIMSS aportacionesIMSS = new AportacionesIMSS();
            try
            {
                refWsAlumno.WSAlumnosSoapClient wSAlumnosSoap = new refWsAlumno.WSAlumnosSoapClient();
                refWsAlumno.AportacionesIMSS refsImss = wSAlumnosSoap.CalcularIMSS(id);
                string json = JsonConvert.SerializeObject(refsImss);
                aportacionesIMSS =  JsonConvert.DeserializeObject<AportacionesIMSS>(json);
            }
            catch(Exception e)
            {
                Alumno alumno = ConsultarSoloUno(id);
                decimal sueldo = Convert.ToDecimal(alumno.sueldo);
                decimal operandoSBC = sueldo;
                decimal operandoUMA = Convert.ToDecimal(ConfigurationManager.AppSettings["operandoUMA"]);

                decimal enfermedadMaternidad = 0;
                decimal invalidezVida = 0;
                decimal retiro = 0;
                decimal cesantia = 0;
                decimal infonavit = 0;

                enfermedadMaternidad = operandoUMA - 3 * operandoSBC * 0.4m / 100;
                invalidezVida = operandoSBC * 0.625m / 100;
                retiro = operandoSBC * 0 / 100;
                cesantia = operandoSBC * 1.125m / 100;
                infonavit = operandoSBC * 0 / 100;
               
                aportacionesIMSS.enfermedadMaternidad = enfermedadMaternidad;
                aportacionesIMSS.invalidezVida = invalidezVida;
                aportacionesIMSS.retiro = retiro;
                aportacionesIMSS.cesantía = cesantia;
                aportacionesIMSS.infonavit = infonavit;
            }
            return aportacionesIMSS;
        }
        }
}
