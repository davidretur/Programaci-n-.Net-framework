using AlumnosEntityFrameworkMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlumnosEntityFrameworkMvc.Controllers
{

    public class AlumnoLEController : Controller
    {
        private InstitutoTichEntities _DBContext = new InstitutoTichEntities();
        // GET: AlumnoLE
        public ActionResult Index()
        {
            _DBContext.Configuration.LazyLoadingEnabled = true;
            //Include
            List<Alumnos> lstAlumnos = _DBContext.Alumnos.ToList();            
            return View(lstAlumnos);
        }

        // GET: AlumnoLE/Details/5
        public ActionResult Details(int id)
        {
            Alumnos alumnos = _DBContext.Alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }

            return View(alumnos);
        }

        // GET: AlumnoLE/Create
        public ActionResult Create()
        {
            ViewBag.idEstadoOrigen = new SelectList(_DBContext.Estados, "id", "nombre");
            ViewBag.idEstatus = new SelectList(_DBContext.EstatusAlumnos, "id", "nombre");
            return View();
        }

        // POST: AlumnoLE/Create
        [HttpPost]
        public ActionResult Create(Alumnos alumnos)
        {
            Alumnos alumnos1 = new Alumnos();
            try
            {
                _DBContext.Alumnos.Add(alumnos);
                _DBContext.SaveChanges();

                alumnos1 = _DBContext.Alumnos.Find(alumnos.id);

                return View("Details", alumnos1);
            }
            catch
            {
                return View(alumnos);
            }
        }

        // GET: AlumnoLE/Edit/5
        public ActionResult Edit(int id)
        {
            Alumnos alumnos = _DBContext.Alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstadoOrigen = new SelectList(_DBContext.Estados, "id", "nombre", alumnos.idEstadoOrigen);
            ViewBag.idEstatus = new SelectList(_DBContext.EstatusAlumnos, "id", "nombre", alumnos.idEstatus);
            return View(alumnos);
        }

        // POST: AlumnoLE/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Alumnos alumnos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _DBContext.Entry(alumnos).State = EntityState.Modified;
                    _DBContext.SaveChanges();
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AlumnoLE/Delete/5
        public ActionResult Delete(int id)
        {
            Alumnos alumnos = _DBContext.Alumnos.Find(id);
            if (alumnos == null)
            {
                return HttpNotFound();
            }
            return View(alumnos);
        }

        // POST: AlumnoLE/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(int id, Alumnos alumnos)
        {
            try
            {
                alumnos = _DBContext.Alumnos.Find(id);
                _DBContext.Alumnos.Remove(alumnos);
                _DBContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
