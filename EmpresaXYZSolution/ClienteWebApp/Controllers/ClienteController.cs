using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClienteWebApp.Controllers
{
    public class ClienteController : Controller
    {
        private Models.Cliente clienteModel = new Models.Cliente();

        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            var listaCliente = clienteModel.GetClienteCampanha();
            return View(listaCliente);
        }

        //
        // GET: /Cliente/Details/5

        public ActionResult Details(long id)
        {
            var cliente = clienteModel.GetClienteById(id);
            return View(cliente);
        }

        //
        // GET: /Cliente/Edit/5

        public ActionResult Edit(long id)
        {
            var cliente = clienteModel.GetClienteById(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Edit(Models.Cliente cliente)
        {
            try
            {
                clienteModel.UpdateCliente(cliente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
