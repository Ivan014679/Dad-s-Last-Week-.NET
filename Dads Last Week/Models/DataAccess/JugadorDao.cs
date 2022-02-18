using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dads_Last_Week.Models;
using Dads_Last_Week.Models.DataModel;

namespace Dads_Last_Week.Models.DataAccess
{
    public class JugadorDao
    {
        public void Registrar(JugadorModel j)
        {
            using (var contexto = new DadsLastWeekEntities())
            {
                Jugador ju = new Jugador();
                ju.Nom_Usuario = j.NombreUsuario;
                ju.Contrasena = j.Contrasena;
                ju.Imagen = null;
                ju.Nom_Personaje = "nuevopersonaje";
                ju.Dia = "D000";
                ju.Decision = "A000";

                contexto.Jugador.Add(ju);
                contexto.SaveChanges();
            }
        }

        public List<JugadorModel> Consultar()
        {
            List<JugadorModel> listajugadores = new List<JugadorModel>();
            using (var contexto = new DadsLastWeekEntities())
            {
                var consulta = (from d in contexto.Jugador select d).ToList();
                foreach (var item in consulta)
                {
                    JugadorModel x = new JugadorModel();
                    x.NombreUsuario = item.Nom_Usuario;
                    x.Contrasena = item.Contrasena;
                    x.Imagen = item.Imagen;
                    x.NomPersonaje = item.Nom_Personaje;
                    x.Dia = item.Dia;
                    x.Decision = item.Decision;

                    listajugadores.Add(x);
                }
            }
            return listajugadores;
        }

        public JugadorModel InicioSesion(string NUsuario, string Password)
        {
            using (var contexto = new DadsLastWeekEntities())
            {
                var consulta = (from d in contexto.Jugador where d.Nom_Usuario == NUsuario && d.Contrasena == Password select d).ToList();

                if (consulta.Count() > 0)
                {
                    JugadorModel x = new JugadorModel();
                    foreach (var item in consulta)
                    {
                        x.NombreUsuario = item.Nom_Usuario;
                        x.Contrasena = item.Contrasena;
                        x.Imagen = item.Imagen;
                        x.NomPersonaje = item.Nom_Personaje;
                        x.Dia = item.Dia;
                        x.Decision = item.Decision;
                    }
                    return x;
                }
                else
                {
                    return null;
                }
            }
        }

        public void Actualizar(JugadorModel j)
        {
            var jugador = new Jugador { Nom_Usuario = j.NombreUsuario };
            using (var contexto = new DadsLastWeekEntities())
            {
                contexto.Jugador.Attach(jugador);
                jugador.Nom_Usuario = j.NombreUsuario;
                jugador.Contrasena = j.Contrasena;
                jugador.Imagen = j.Imagen;
                jugador.Nom_Personaje = j.NomPersonaje;
                jugador.Dia = j.Dia;
                jugador.Decision = j.Decision;
                contexto.SaveChanges();
            }
        }
    }
}