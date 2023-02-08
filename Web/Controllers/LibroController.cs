using ApplicationCore.Services;
using Infraestructure.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Index()
        {
            IEnumerable<Libro> lista = null;
            try
            {
                IServiceLibro _ServiceLibro = new ServiceLibro();
                lista = _ServiceLibro.GetLibro();
                

                return View(lista);

            }
            catch
            {
                throw;
            }
            return View();
        }

        // GET: Libro/Details/5
        public ActionResult Details(int? id)
        {
            IServiceLibro _serviceLibro = new ServiceLibro();
            Libro oLibro = null;
            try
            {
                if(id == null)
                {
                    return RedirectToAction("Index");
                }
                oLibro = _serviceLibro.GetLibroByID(Convert.ToInt32(id));
                if(oLibro == null)
                {
                    TempData["Message"] = "No existe el libro solicitado";
                    // controller
                    TempData["Redirect"] = "Libro";
                    // action
                    TempData["Redirect Action"] = "Index";
                    return RedirectToAction("Default", "Error");
                }
                return View(oLibro);
            }
            catch 
            {
                TempData["Message"] = "Error al procesar los datos";
                // controller
                TempData["Redirect"] = "Libro";
                // action
                TempData["Redirect Action"] = "Index";
                return RedirectToAction("Default", "Error");
            }
            return View();
        }

        // GET: Libro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Libro/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Libro/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Libro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Libro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
