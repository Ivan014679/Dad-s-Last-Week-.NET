using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dads_Last_Week.Models.DataModel;

namespace Dads_Last_Week.Models.DataAccess
{
    public class DecisionDao
    {
        public DecisionModel Consultar(string DecisionTomada)
        {
            using (var contexto = new DadsLastWeekEntities())
            {
                var consulta = (from d in contexto.Decision where d.Id_Decision == DecisionTomada select d).ToList();
                foreach (var item in consulta)
                {
                    DecisionModel x = new DecisionModel();
                    x.Id_Decision = item.Id_Decision;
                    x.Texto = item.Texto;
                    x.Dia = item.Dia;
                    x.Salud = item.Porcentaje_Salud;
                    x.Estado = item.Estado;
                    x.EventoFinal = item.Evento_Final;
                    x.Left = item.Left;
                    x.Right = item.Right;

                    return x;
                }
            }
            return null;
        }
    }
}