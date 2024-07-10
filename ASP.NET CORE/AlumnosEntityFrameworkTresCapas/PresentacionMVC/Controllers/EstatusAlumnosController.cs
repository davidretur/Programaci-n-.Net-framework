using CapaEntidades;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentacionMVC.Controllers
{
    public class EstatusAlumnosController : Controller
    {
        NEstatusAlumnos _nEstatusAlumnos = new NEstatusAlumnos();
        // GET: EstatusAlumnos
        public ActionResult Index(int? page)
        {
            const int PageSize = 5; // Tamaño de página
            int pageNumber = (page ?? 1);

            // Simulamos una lista de productos
            var products = _nEstatusAlumnos.Consultar();

            // Paginar los productos
            var paginatedEstatus = products.Skip((pageNumber - 1) * PageSize).Take(PageSize).ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)products.Count / PageSize);
            ViewBag.CurrentPage = pageNumber;
            return View(paginatedEstatus);
        }

        // GET: EstatusAlumnos/Details/5
        public ActionResult Details(int id)
        {
            EstatusAlumnos estatusAlumnos = _nEstatusAlumnos.ConsultarUno(id);
            if (estatusAlumnos == null)
            {
                return HttpNotFound();
            }
            return View(estatusAlumnos);
        }

        // GET: EstatusAlumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstatusAlumnos/Create
        [HttpPost]
        public ActionResult Create(EstatusAlumnos estatusAlumnos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _nEstatusAlumnos.Agregar(estatusAlumnos);
                    return RedirectToAction("Index");
                }
                return View(estatusAlumnos);
            }
            catch
            {
                return View();
            }
        }

        // GET: EstatusAlumnos/Edit/5
        public ActionResult Edit(int id)
        {
            EstatusAlumnos estatusAlumnos = _nEstatusAlumnos.ConsultarUno(id);
            if (estatusAlumnos == null)
            {
                return HttpNotFound();
            }
            return View(estatusAlumnos);
        }

        // POST: EstatusAlumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EstatusAlumnos estatusAlumnos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _nEstatusAlumnos.Actualizar(id,estatusAlumnos);
                    return RedirectToAction("Index");
                }
                return View(estatusAlumnos);
            }
            catch
            {
                return View();
            }
        }

        // GET: EstatusAlumnos/Delete/5
        public ActionResult Delete(int id)
        {
            EstatusAlumnos estatusAlumnos = _nEstatusAlumnos.ConsultarUno(id);
            if (estatusAlumnos == null)
            {
                return HttpNotFound();
            }
            return View(estatusAlumnos);
        }

        // POST: EstatusAlumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, EstatusAlumnos estatusAlumnos)
        {
            try
            {
                _nEstatusAlumnos.Eliminar(id);   
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
