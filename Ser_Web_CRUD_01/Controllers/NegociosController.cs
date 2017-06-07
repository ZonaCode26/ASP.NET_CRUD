using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//importamos eferecnias
using Dominio.Repositorio;
using Dominio.Entidades;



namespace Ser_Web_CRUD_01.Controllers
{
    public class NegociosController : Controller
    {

        clienteBL cliente = new clienteBL();

        // GET: Negocios
        public ActionResult Index()
        {
            return View(cliente.listaClientes());
        }

        
        public ActionResult RegistrarCliente() {

            return View(new tb_clientes());
        }

        [HttpPost]
        public ActionResult RegistrarCliente(tb_clientes reg) {
            string mensaje = cliente.AgregarCliente(reg);

            return RedirectToAction("Index");
        }


        /******************************************************************/

        /******************************************************************/

        paisBL pais = new paisBL();

        public ActionResult CreateCliente() {

            ViewBag.paises = new SelectList(pais.listaPaises(),"idpais","nombrepais");

            return View(new tb_clientes());
        }
        [HttpPost]
        public ActionResult CreateCliente(tb_clientes reg) {

            /*este valor recibe de la pagina*//*esta es la forma de poner la lista*/
            ViewBag.paises = new SelectList(pais.listaPaises(),"idpais","nombrepais", reg.idpais);

            ViewBag.mensaje = cliente.AgregarCliente(reg);

            return View(reg);


        }

        public ActionResult ActualizarCLiente(string id) {

            if (id == null)
                return RedirectToAction("Index");

            var reg = cliente.listaClientes().Where(x => x.idcliente == id).FirstOrDefault();
            
            ViewBag.paises = new SelectList(pais.listaPaises(), "idpais", "nombrepais", reg.idpais);

            return View(reg);
        }
        [HttpPost]
        public ActionResult ActualizarCLiente(tb_clientes reg) {


            ViewBag.paises = new SelectList(pais.listaPaises(), "idpais", "nombrepais", reg.idpais);

            ViewBag.mensaje = cliente.ActualizarCliente(reg);

            return View(reg);

        }

        public ActionResult EliminarCliente(string id) {
            if (id == null)
                return RedirectToAction("Index");

            var reg = cliente.listaClientes().Where(x => x.idcliente==id).FirstOrDefault();

            ViewBag.mensaje = cliente.EliminarCliente(reg);

            return RedirectToAction("Index");

        }








    }
}