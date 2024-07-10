using CapaEntidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class NEstatusAlumnos
    {
        string urlWebAPI = ConfigurationManager.AppSettings["urlWebAPI"];
        public List<EstatusAlumnos> Consultar()
        {
            var estatus = new List<EstatusAlumnos>();
            try
            {
                //Instancia el objeto HttpClient
                using (var client = new HttpClient())
                {
                    //Invoca el método GetAsync del objeto HttpClient, el cual envía una solicitud GET al
                    //URI especificado como parámetro, como una operación asincrónica
                    Task<HttpResponseMessage> responseTask = client.GetAsync(urlWebAPI);

                    // Se invoca al método Wait a fin de esperar a que se complete la operación asincrona
                    responseTask.Wait();

                    //Obtenemos el objeto HttpResponseMessage a través de la propiedad Result del objeto Task<HttpResponseMessage>
                    HttpResponseMessage result = responseTask.Result;

                    // Verificamos que la operación haya sido ejecutada con éxito, para proceder a obtener el resultado enviado
                    // desde la web api, en caso contrario enviamos una excepción
                    if (result.IsSuccessStatusCode)
                    {
                        //Invocamos al método ReadAsStringAsync del objeto HttpContent el cual serializa
                        //el contenido HTTP en una cadena como una operación asincrónica. 
                        Task<string> readTask = result.Content.ReadAsStringAsync();

                        // Se invoca al método Wait a fin de esperar a que se complete la operación asincrona
                        readTask.Wait();

                        //Obtenemos el string en formato json del objeto recibido
                        string json = readTask.Result;

                        //Deserealizamos el objeto recibido, en este caso una lista de estados
                        estatus = JsonConvert.DeserializeObject <List<EstatusAlumnos>>(json);
                    }
                    else //web api envió error de respuesta
                    {
                        throw new Exception($"WebAPI. Respondio con error.{result.StatusCode}");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"WebAPI. Respondio con error.{ex.Message}");
            }
            return estatus;
        }

        public EstatusAlumnos ConsultarUno(int idAlumno)
        {
            var estatus = new EstatusAlumnos();
            try
            {
                //Instancia el objeto HttpClient
                using (var client = new HttpClient())
                {
                    //Invoca el método GetAsync del objeto HttpClient, el cual envía una solicitud GET al
                    //URI especificado como parámetro, como una operación asincrónica
                    Task<HttpResponseMessage> responseTask = client.GetAsync(urlWebAPI+"/"+idAlumno);

                    // Se invoca al método Wait a fin de esperar a que se complete la operación asincrona
                    responseTask.Wait();

                    //Obtenemos el objeto HttpResponseMessage a través de la propiedad Result del objeto Task<HttpResponseMessage>
                    HttpResponseMessage result = responseTask.Result;

                    // Verificamos que la operación haya sido ejecutada con éxito, para proceder a obtener el resultado enviado
                    // desde la web api, en caso contrario enviamos una excepción
                    if (result.IsSuccessStatusCode)
                    {
                        //Invocamos al método ReadAsStringAsync del objeto HttpContent el cual serializa
                        //el contenido HTTP en una cadena como una operación asincrónica. 
                        Task<string> readTask = result.Content.ReadAsStringAsync();

                        // Se invoca al método Wait a fin de esperar a que se complete la operación asincrona
                        readTask.Wait();

                        //Obtenemos el string en formato json del objeto recibido
                        string json = readTask.Result;

                        //Deserealizamos el objeto recibido, en este caso una lista de estados
                        estatus = JsonConvert.DeserializeObject<EstatusAlumnos>(json);
                    }
                    else //web api envió error de respuesta
                    {
                        throw new Exception($"WebAPI. Respondio con error.{result.StatusCode}");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"WebAPI. Respondio con error.{ex.Message}");
            }
            return estatus;

        }
        public EstatusAlumnos Agregar(EstatusAlumnos estatusAlumnos)
        {
            try
            {
                //Instancia el objeto HttpClient
                using (var client = new HttpClient())
                {

                    //Creamos un objeto HttpContent instanciando un objeto StringContent, la cual es una clase derivada de HttpContent.
                    //Este contenido se crea con el objeto Estado que se está recibiendo
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(estatusAlumnos), Encoding.UTF8);

                    //Asignamos a la propiedad ContentType del encabezado de HttpContent
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    //Invoca el método PostAsync del objeto HttpClient, el cual envía una solicitud POST al
                    //URI especificado como parámetro, como una operación asincrónica, asimismo le envía el contenido (objeto estado) dentro del httpContect
                    Task<HttpResponseMessage> postTask = client.PostAsync(urlWebAPI, httpContent);

                    // Se invoca al método Wait a fin de esperar a que se complete la operación asincrona
                    postTask.Wait();

                    //Obtenemos el objeto HttpResponseMessage a través de la propiedad Result del objeto Task<HttpResponseMessage>
                    HttpResponseMessage result = postTask.Result;

                    // Verificamos que la operación haya sido ejecutada con éxito, para proceder a obtener el resultado enviado
                    // desde la web api, en caso contrario enviamos una excepción
                    if (result.IsSuccessStatusCode)
                    {
                        // Verificamos que la operación haya sido ejecutada con éxito, para proceder a obtener el resultado enviado
                        // desde la web api, en caso contrario enviamos una excepción
                        var readTask = result.Content.ReadAsStringAsync();
                        // Se invoca al método Wait a fin de esperar a que se complete la operación asincrona
                        readTask.Wait();
                        //Obtenemos el string en formato json del objeto recibido
                        string json = readTask.Result;
                        //Deserealizamos el objeto recibido, en este caso un estado
                        estatusAlumnos = JsonConvert.DeserializeObject<EstatusAlumnos>(json);
                    }
                    else //web api envió error de respuesta
                    {
                        throw new Exception($"WebAPI. Respondio con error.{result.StatusCode}");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"WebAPI. Respondio con error.{ex.Message}");
            }
            return estatusAlumnos;
        }
        public void Actualizar(int idAlumno,EstatusAlumnos estatusAlumnos)
        {
            try
            {
                //Instancia el objeto HttpClient
                using (var client = new HttpClient())
                {

                    //Creamos un objeto HttpContent instanciando un objeto StringContent, la cual es una clase derivada de HttpContent.
                    //Este contenido se crea con el objeto Estado que se está recibiendo
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(estatusAlumnos), Encoding.UTF8);

                    //Asignamos a la propiedad ContentType del encabezado de HttpContent
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    //Invoca el método PostAsync del objeto HttpClient, el cual envía una solicitud POST al
                    //URI especificado como parámetro, como una operación asincrónica, asimismo le envía el contenido (objeto estado) dentro del httpContect
                    Task<HttpResponseMessage> postTask = client.PutAsync(urlWebAPI + "/" + idAlumno, httpContent);

                    // Se invoca al método Wait a fin de esperar a que se complete la operación asincrona
                    postTask.Wait();

                    //Obtenemos el objeto HttpResponseMessage a través de la propiedad Result del objeto Task<HttpResponseMessage>
                    HttpResponseMessage result = postTask.Result;

                    // Verificamos que la operación haya sido ejecutada con éxito, para proceder a obtener el resultado enviado
                    // desde la web api, en caso contrario enviamos una excepción
                    if (result.IsSuccessStatusCode)
                    {
                        // Verificamos que la operación haya sido ejecutada con éxito, para proceder a obtener el resultado enviado
                        // desde la web api, en caso contrario enviamos una excepción
                        var readTask = result.Content.ReadAsStringAsync();
                        // Se invoca al método Wait a fin de esperar a que se complete la operación asincrona
                        readTask.Wait();
                        //Obtenemos el string en formato json del objeto recibido
                        string json = readTask.Result;
                        //Deserealizamos el objeto recibido, en este caso un estado
                        estatusAlumnos = JsonConvert.DeserializeObject<EstatusAlumnos>(json);
                    }
                    else //web api envió error de respuesta
                    {
                        throw new Exception($"WebAPI. Respondio con error.{result.StatusCode}");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"WebAPI. Respondio con error.{ex.Message}");
            }
            
        }

        public void Eliminar(int idAlumno)
        {
            var estatus = new EstatusAlumnos();
            try
            {
                //Instancia el objeto HttpClient
                using (var client = new HttpClient())
                {
                    //Invoca el método GetAsync del objeto HttpClient, el cual envía una solicitud GET al
                    //URI especificado como parámetro, como una operación asincrónica
                    Task<HttpResponseMessage> responseTask = client.DeleteAsync(urlWebAPI + "/" + idAlumno);

                    // Se invoca al método Wait a fin de esperar a que se complete la operación asincrona
                    responseTask.Wait();

                    //Obtenemos el objeto HttpResponseMessage a través de la propiedad Result del objeto Task<HttpResponseMessage>
                    HttpResponseMessage result = responseTask.Result;

                    // Verificamos que la operación haya sido ejecutada con éxito, para proceder a obtener el resultado enviado
                    // desde la web api, en caso contrario enviamos una excepción
                    if (result.IsSuccessStatusCode)
                    {
                        //Invocamos al método ReadAsStringAsync del objeto HttpContent el cual serializa
                        //el contenido HTTP en una cadena como una operación asincrónica. 
                        Task<string> readTask = result.Content.ReadAsStringAsync();

                        // Se invoca al método Wait a fin de esperar a que se complete la operación asincrona
                        readTask.Wait();

                        //Obtenemos el string en formato json del objeto recibido
                        string json = readTask.Result;

                        //Deserealizamos el objeto recibido, en este caso una lista de estados
                        estatus = JsonConvert.DeserializeObject<EstatusAlumnos>(json);
                    }
                    else //web api envió error de respuesta
                    {
                        throw new Exception($"WebAPI. Respondio con error.{result.StatusCode}");
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"WebAPI. Respondio con error.{ex.Message}");
            }

        }

    }
}
