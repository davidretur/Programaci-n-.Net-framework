using CapaEntidades;
using CapaNegocio;
using RazorMvcDll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorMvcDll.Controllers
{

    public class AlumnosCController : Controller
    {
        CNAlumno _cNAlumno = new CNAlumno();
        CNEstado _cNEstado = new CNEstado();
        CNEstatusAlumno _nEstatusAlumno = new CNEstatusAlumno();
        // GET: AlumnosC
        public ActionResult Index()
        {
            List<Alumno> listAlumnos = _cNAlumno.ConsultarTodos();
            List<Estado> listEstado = _cNEstado.ConsultarTodos();
            List<EstatusAlumno> listEstatus = _nEstatusAlumno.ConsultarTodos();
            //consulta
            var listaNombreES = (from alumno in listAlumnos
                                 join estado in listEstado on alumno.estado equals estado.id
                                 join estatus in listEstatus on alumno.estatus equals estatus.id
                                 select new AlumnoLocal
                                 {
                                     id = alumno.id,
                                     nombre = alumno.nombre,
                                     primerApellido = alumno.primerApellido,
                                     segundoApellido = alumno.segundoApellido,
                                     fechaNacimiento = alumno.fechaNacimiento,
                                     correo = alumno.correo,
                                     telefono = alumno.telefono,
                                     curp = alumno.curp,
                                     sueldo = alumno.sueldo,
                                     estado = estado.nombre,
                                     estatus = estatus.nombre
                                 }).ToList();
            return View(listaNombreES);
        }
        public ActionResult Details(int id)
        {
            Alumno alumnos = _cNAlumno.ConsultarSoloUno(id);
            return View(alumnos);
        }
        public ActionResult Create()
        {
            CargarEstados();
            CargarEstatus();
            return View();

        }
        public ActionResult Edit(int id)
        {
            CargarEstados();
            CargarEstatus();
            Alumno alumnos = _cNAlumno.ConsultarSoloUno(id);
            return View(alumnos);

        }
        public ActionResult Delete(int id)
        {
            Alumno alumnos = _cNAlumno.ConsultarSoloUno(id);
            return View(alumnos);

        }
        private void CargarEstados()
        {
            List<Estado> listaEstado = _cNEstado.ConsultarTodos();
            ViewBag.id = new SelectList(listaEstado, "id", "nombre");
            ViewBag.estados = listaEstado;

        }
        private void CargarEstatus()
        {
            List<EstatusAlumno> listaEstatus = _nEstatusAlumno.ConsultarTodos();
            ViewBag.id = new SelectList(listaEstatus, "id", "nombre");
            ViewBag.estatus = listaEstatus;

        }
        [HttpPost]
        public ActionResult Create(Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                bool insertar = _cNAlumno.Agregar(alumno);
                return RedirectToAction("Index");
            }
            return View(alumno);
        }
        [HttpPost]
        public ActionResult Delete(Alumno alumno)
        {
                bool insertar = _cNAlumno.Eliminar(alumno.id);
                return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Edit(Alumno alumno)
        {
            bool insertar = _cNAlumno.Editar(alumno);
            return RedirectToAction("Index");
        }
    }
}