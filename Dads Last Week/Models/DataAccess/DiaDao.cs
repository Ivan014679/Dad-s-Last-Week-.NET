using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dads_Last_Week.Models.DataModel;

namespace Dads_Last_Week.Models.DataAccess
{
    public class DiaDao
    {
        public DiaModel ConsultarDia(string IdDia)
        {
            using (var contexto = new DadsLastWeekEntities())
            {
                var consulta = (from d in contexto.Dia where d.Id_Dia == IdDia select d).ToList();

                if (consulta.Count() > 0)
                {
                    DiaModel x = new DiaModel();
                    foreach (var item in consulta)
                    {
                        x.Id_Dia = item.Id_Dia;
                        x.Nom_Dia = item.Nom_Dia;
                    }
                    return x;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}