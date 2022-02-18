using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dads_Last_Week.Models.DataAccess;

namespace Dads_Last_Week.Models
{
    public class DiaModel
    {
        public string Nom_Dia { get; set; }
        public string Id_Dia { get; set; }

        public DiaModel ObtenerDia(string IdDia)
        {
            DiaDao didao = new DiaDao();
            return didao.ConsultarDia(IdDia);
        }
    }
}