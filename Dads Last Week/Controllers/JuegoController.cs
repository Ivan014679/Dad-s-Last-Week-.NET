using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dads_Last_Week.Models;

namespace Dads_Last_Week.Controllers
{
    public class JuegoController : Controller
    {
        DiaModel Dia = new DiaModel();
        DecisionModel Decision = new DecisionModel();
        JugadorModel Jugador = new JugadorModel();
        // GET: Juego
        public ActionResult Index()
        {
            ViewBag.Dia = Dia.ObtenerDia("D000").Nom_Dia;
            ViewBag.Decision = Decision.ObtenerDecision("A001");
            ViewBag.Boton1 = "Continuar";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string DecisionTomada)
        {
            if (DecisionTomada != "")
            {
                Jugador.NombreUsuario = Convert.ToString(Session["nomusuario"]);
                Jugador.Contrasena = Convert.ToString(Session["contrasena"]);
                //Jugador.Imagen = Convert.ToByte(Session["imagen"])[];
                Jugador.NomPersonaje = Convert.ToString(Session["nompersonaje"]);
                Decision = Decision.ObtenerDecision(DecisionTomada);
                Dia = Dia.ObtenerDia(Decision.Dia);
                Session["dia"] = Dia.Id_Dia;
                Session["decision"] = Decision.Id_Decision;
                ViewBag.Decision = Decision;
                ViewBag.Dia = Dia.Nom_Dia;
                if (Decision.ObtenerDecision(DecisionTomada).Left == null)
                {
                    Dia.Id_Dia = "D000";
                    Decision.Id_Decision = "A000";
                    ViewBag.Boton1 = "Terminar juego";
                }
                else
                {
                    switch (DecisionTomada)
                    {
                        case "A002":
                            ViewBag.Boton1 = "Bosque";
                            ViewBag.Boton2 = "Camino";
                            break;
                        case "A003":
                            ViewBag.Boton1 = "No hacer nada";
                            ViewBag.Boton2 = "Tratar herida";
                            break;
                        case "A006":
                            ViewBag.Boton1 = "Pelear";
                            ViewBag.Boton2 = "Huir";
                            break;
                        case "A018":
                            ViewBag.Boton1 = "Ayudarlo";
                            ViewBag.Boton2 = "Seguir";
                            break;
                        case "A021":
                            ViewBag.Boton1 = "Ir por el arroyo";
                            ViewBag.Boton2 = "Robar caballo";
                            break;
                        case "A027":
                            ViewBag.Boton1 = "Aceptar";
                            ViewBag.Boton2 = "Rechazar";
                            break;
                        case "A034":
                            ViewBag.Boton1 = "Montaña";
                            ViewBag.Boton2 = "Lago";
                            break;
                        default:
                            ViewBag.Boton1 = "Continuar";
                            break;
                    }                    
                }
                Jugador.Dia = Dia.Id_Dia;
                Jugador.Decision = Decision.Id_Decision;
                Jugador.GuardarProgresos();
                Jugador.GuardarProgresos();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Menu");
            }            
        }
    }
}