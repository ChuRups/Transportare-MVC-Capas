using BAL.Interfaces;
using BAL.Modelos;
using BAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControlEscolarMVCCapas.Areas.Mensajeros.Controllers
{
    public class MensajerosController : Controller
    {
        private IRepositorioMensajeros _repositorioMensajeros;

        public MensajerosController()
        {
            if (_repositorioMensajeros == null)
                _repositorioMensajeros = new RepositorioMensajero();
        }

        public ActionResult Index()
        {
            var listaMensajeros = _repositorioMensajeros.ListarMensajeros();
            return View(listaMensajeros);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ModeloMensajeros modelo)
        {
            if (ModelState.IsValid)
            {
                _repositorioMensajeros.AgregarMensajero(modelo);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var Mensajero = _repositorioMensajeros.ListarMensajeroId(id);
            return View(Mensajero);
        }

        public ActionResult Edit(int id)
        {
            var Mensajero = _repositorioMensajeros.ListarMensajeroId(id);
            return View(Mensajero);
        }

        [HttpPost]
        public ActionResult Edit(ModeloMensajeros modelo)
        {
            _repositorioMensajeros.EditarMensajero(modelo);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var m = _repositorioMensajeros.ListarMensajeroId(id);
            return View(m);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteMensajero(int id)
        {
            _repositorioMensajeros.EliminarMensajero(id);
            return RedirectToAction("Index");
        }
    }
}