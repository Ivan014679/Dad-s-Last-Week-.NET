using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dads_Last_Week.Models.DataAccess;

namespace Dads_Last_Week.Models
{
    public class DecisionModel
    {
        public string Id_Decision { get; set; }
        public string Texto { get; set; }
        public string Dia { get; set; }
        public string Estado { get; set; }
        public string EventoFinal { get; set; }
        public int Salud { get; set; }
        public string Left { get; set; }
        public string Right { get; set; }

        public DecisionModel ObtenerDecision(string DecisionTomada)
        {
            DecisionDao dedao = new DecisionDao();
            return dedao.Consultar(DecisionTomada);
        }
    }
}
