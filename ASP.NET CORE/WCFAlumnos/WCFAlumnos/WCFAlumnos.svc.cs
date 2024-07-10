using CapaNegocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFAlumnos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WCFAlumnos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione WCFAlumnos.svc o WCFAlumnos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WCFAlumnos : IWCFAlumnos
    {
         CNAlumno cNAlumno = new CNAlumno();
        public AportacionesImss CalcularImss(int id)
        {
              try
               {
                   var resultadoOriginal = cNAlumno.CalcularIMSS(id);   
                   string json = JsonConvert.SerializeObject(resultadoOriginal);                
                   AportacionesImss resultado = JsonConvert.DeserializeObject<AportacionesImss>(json);
                   return resultado;
               }
               catch (Exception ex)
               {
                   throw new FaultException($"Error al calcular el IMSS para el ID {id}: {ex.Message}");
               }
             
        }

        public ItemTablaIsr CalcularIsr(int id)
        {
              try
              {
                  var resultadoOriginal = cNAlumno.CalcularISR(id);
              string json = JsonConvert.SerializeObject(resultadoOriginal);
              ItemTablaIsr resultado = JsonConvert.DeserializeObject<ItemTablaIsr>(json);
              return resultado;
              }
              catch (Exception ex)
              {
                  throw new FaultException($"Error al calcular el ISR para el ID {id}: {ex.Message}");
              }
        }


    }
}
