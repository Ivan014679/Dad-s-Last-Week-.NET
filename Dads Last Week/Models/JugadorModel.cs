using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Dads_Last_Week.Models.DataAccess;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dads_Last_Week.Models
{
    public class JugadorModel
    {
        [Display(Name = "Nombre de usuario")]
        [StringLength(maximumLength: 30, MinimumLength = 1)]
        public string NombreUsuario { get; set; }
        [Display(Name = "Contraseña")]
        [StringLength(maximumLength: 20, MinimumLength = 5)]
        [DataType(dataType: DataType.Password)]
        public string Contrasena { get; set; }
        [Display(Name = "Imagen del personaje")]
        public byte[] Imagen { get; set; }
        [Display(Name = "Nombre del personaje")]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string NomPersonaje { get; set; }
        [Display(Name = "Día")]
        [StringLength(maximumLength: 4, MinimumLength = 4)]
        public string Dia { get; set; }
        [Display(Name = "Decisión")]
        [StringLength(maximumLength: 4, MinimumLength = 4)]
        public string Decision { get; set; }

        public void RegistrarJugador()
        {
            JugadorDao judao = new JugadorDao();
            judao.Registrar(this);
        }

        public List<JugadorModel> ObtenerJugadores()
        {
            JugadorDao judao = new JugadorDao();
            return judao.Consultar();
        }

        public JugadorModel DatosSesion(string NUsuario, string Password)
        {
            JugadorDao judao = new JugadorDao();
            return judao.InicioSesion(NUsuario, Password);
        }

        public void GuardarProgresos()
        {
            JugadorDao judao = new JugadorDao();
            judao.Actualizar(this);
        }
    }
}