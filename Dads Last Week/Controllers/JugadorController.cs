using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dads_Last_Week.Models;

namespace Dads_Last_Week.Controllers
{
    public class JugadorController : Controller
    {
        // GET: Jugador
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(JugadorModel jugadorModel)
        {
            if (ModelState.IsValid)
            {
                if (jugadorModel.DatosSesion(jugadorModel.NombreUsuario, jugadorModel.Contrasena) != null)
                {
                    Session["nomusuario"] = jugadorModel.NombreUsuario;
                    Session["contrasena"] = jugadorModel.Contrasena;
                    Session["imagen"] = jugadorModel.DatosSesion(jugadorModel.NombreUsuario, jugadorModel.Contrasena).Imagen;
                    Session["nompersonaje"] = jugadorModel.DatosSesion(jugadorModel.NombreUsuario, jugadorModel.Contrasena).NomPersonaje;
                    Session["dia"] = jugadorModel.DatosSesion(jugadorModel.NombreUsuario, jugadorModel.Contrasena).Dia;
                    Session["decision"] = jugadorModel.DatosSesion(jugadorModel.NombreUsuario, jugadorModel.Contrasena).Decision;
                    return RedirectToAction("Index", "Menu");
                }
                ViewBag.error = "Error";
                return View();
            }
            else
            {
                return View(jugadorModel);
            }
        }

        public ActionResult CrearCuenta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearCuenta(JugadorModel jugadorModel)
        {
            if (ModelState.IsValid)
            {
                jugadorModel.RegistrarJugador();
                ViewBag.mensaje = "Registro exitoso";
                return RedirectToAction("Index");
            }
            else
            {
                return View(jugadorModel);
            }
        }

        public ActionResult Close()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Index");
        }
    }
}