using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaNegocio.ServiceReferenceWsfAlumnos;
namespace PresentacionMVC.Controllers
{
    public class AlumnosController : Controller
    {
        NAlumno _nAlumno = new NAlumno();
        NEstado _nEstado = new NEstado();   
        NEstatus _nEstatus = new NEstatus();

        private readonly int _RegistrosPorPagina = 5;

        private List<Alumnos> _lstAlumnos;
        private PaginadorGenerico<Alumnos> _PaginadorAlumnos;

       
        // GET: Alumnos
        public ActionResult Index(int pagina = 1)
        {
            int _TotalRegistros = 0;
            // Número total de registros de la tabla Alumnos
            _TotalRegistros = _nAlumno.ConsultarTodos().Count();
            // Obtenemos la 'página de registros' de la tabla Customers
            _lstAlumnos = _nAlumno.ConsultarTodos().OrderBy(x => x.nombre)
                                             .Skip((pagina - 1) * _RegistrosPorPagina)
                                             .Take(_RegistrosPorPagina)
                                             .ToList();
            // Número total de páginas de la tabla Customers
            var _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / _RegistrosPorPagina);
            // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
            _PaginadorAlumnos = new PaginadorGenerico<Alumnos>()
            {
                RegistrosPorPagina = _RegistrosPorPagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                Resultado = _lstAlumnos
            };
           

            return View(_PaginadorAlumnos);
        }
        public ActionResult IndexSegPag(int? page)
        {
             // segunda paginacion
        const int PageSize = 5; // Tamaño de página
        int pageNumber = (page ?? 1);

            // Simulamos una lista de productos
            var products = _nAlumno.ConsultarTodos();

            // Paginar los productos
            var paginatedProducts = products.Skip((pageNumber - 1) * PageSize).Take(PageSize).ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)products.Count / PageSize);
            ViewBag.CurrentPage = pageNumber;

            return View(paginatedProducts);
        }

            // GET: Alumnos/Details/5
            public ActionResult Details(int id)
        {
            Alumnos alumnos = _nAlumno.ConsultarSoloUno(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // GET: Alumnos/Create
        public ActionResult Create()
        {
            var estados = _nEstado.ConsultarTodos();
            var estatus = _nEstatus.ConsultarTodos();
            ViewBag.idEstadoOrigen = new SelectList(estados, "id", "nombre");
            ViewBag.idEstatus = new SelectList(estatus, "id", "nombre");
            return View();
        }

        // POST: Alumnos/Create
        [HttpPost]
        public ActionResult Create(Alumnos alumnos)
        {
            try
            {
                if (ModelState.IsValid) { 
                _nAlumno.Agregar(alumnos);
                return RedirectToAction("Index");
                }
                var estados = _nEstado.ConsultarTodos();
                var estatus = _nEstatus.ConsultarTodos();
                ViewBag.idEstadoOrigen = new SelectList(estados, "id", "nombre");
                ViewBag.idEstatus = new SelectList(estatus, "id", "nombre");
                return View(alumnos);
            }
            catch
            {
                return View();

            }
          
        }

        // GET: Alumnos/Edit/5
        public ActionResult Edit(int id)
        {
            Alumnos alumnos = _nAlumno.ConsultarSoloUno(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            var estados = _nEstado.ConsultarTodos();
            var estatus = _nEstatus.ConsultarTodos();
            ViewBag.idEstadoOrigen = new SelectList(estados, "id", "nombre");
            ViewBag.idEstatus = new SelectList(estatus, "id", "nombre");
            return View(alumnos);
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Alumnos alumno)
        {
            try
            {
                if (ModelState.IsValid) {
                _nAlumno.Editar(alumno);
                return RedirectToAction("Index");
                }
                var estados = _nEstado.ConsultarTodos();
                var estatus = _nEstatus.ConsultarTodos();
                ViewBag.idEstadoOrigen = new SelectList(estados, "id", "nombre");
                ViewBag.idEstatus = new SelectList(estatus, "id", "nombre");
                return View(alumno);
            }
            catch
            {
                return View();
            }
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int id)
        {
            Alumnos alumnos = _nAlumno.ConsultarSoloUno(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id, Alumnos alumno)
        {
            try
            {
                alumno = _nAlumno.ConsultarSoloUno(id);
                _nAlumno.Eliminar(alumno);
                return RedirectToAction("Index");
 
            }
            catch
            {
                return View();
            }
        }
        public ActionResult _AportacionesIMSS(int id)
        {
            NAlumno nAlumno = new NAlumno();
            AportacionesImss aportacionesIMSS  = nAlumno.CalcularIMSS(id);
            return PartialView(aportacionesIMSS);
        }
        public ActionResult _ItemTablaIsr(int id)
        {
            NAlumno nAlumno = new NAlumno();
            ItemTablaIsr itemTablaIsr = nAlumno.CalcularISR(id);
            return PartialView(itemTablaIsr);
        }
    }
}
