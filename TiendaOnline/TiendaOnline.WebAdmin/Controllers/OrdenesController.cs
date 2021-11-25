using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaOnline.WebAdmin.Controllers;
using TiendaOnline.BL;

namespace TiendaOnline.WebAdmin.Controllers
{
    [Authorize]
    public class OrdenesController : Controller
    {

        OrdenesBL _ordenesBL;
        public OrdenesController()
        {
            _ordenesBL = new OrdenesBL();
            
        }

            // GET: Ordenes

        public ActionResult Index()

        {
            var ListadeOrdenes = _ordenesBL.ObtenerOrdenes();
            return View(ListadeOrdenes );
        }
        public ActionResult Crear()
        {
            var nuevaOrden = new Orden();
            //var cliente = ClienteBL.ObtenerClientesActivos();

            //ViewBag.clienteId = new SelectList(cliente, "Id", "Nombre");


            return View(nuevaOrden);
        }

        [HttpPost]
        public ActionResult Crear(Orden orden)
        {
            if (ModelState .IsValid)
            {
                if (orden.ClienteId ==0)
                {
                    ModelState.AddModelError("ClienteId", "Seleccione un cliente");
                    return View(orden);
                }

                _ordenesBL.GuardarOrden(orden);

                return RedirectToAction("Index");
            }

            //var cliente = ClienteBL.ObtenerClientes(Orden);

            //ViewBag.clienteId = new SelectList(cliente, "Id", "Nombre");


            return View(orden);
        }
    }

 
   
    }
