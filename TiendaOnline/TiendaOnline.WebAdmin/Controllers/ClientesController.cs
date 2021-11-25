using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaOnline.WebAdmin.Controllers;
using TiendaOnline.BL;

namespace TiendaOnline.WebAdmin.Controllers
{
    public class ClientesController : Controller
    {

        ClienteBL _clienteBL;
        public ClientesController()
        {
            _clienteBL = new ClienteBL();
        }

            // GET: Ordenes

        public ActionResult Index()
        {
            var ListadeOrdenes = _clienteBL.ObtenerClientes();
            return View(ListadeOrdenes );
        }
        public ActionResult Crear()
        {
            var nuevoCliente = new Cliente();
            return View(nuevoCliente);
        }

        [HttpPost]
        public ActionResult Crear(Cliente cliente)
        {
            if (ModelState .IsValid)
            {
                _clienteBL.GuardarCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }


        public ActionResult Editar(int id)
        {
            var cliente = _clienteBL.ObtenerCliente(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteBL.GuardarCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Detalle(int id)
        {
            var cliente = _clienteBL.ObtenerCliente(id);
            return View(cliente);
        }

        public ActionResult Eliminar(int id)
        {
            var cliente = _clienteBL.ObtenerCliente(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Eliminar(Cliente cliente)
        {
            _clienteBL.EliminarCliente(cliente.Id);
            return RedirectToAction("Index");
        }
    }
}
