using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio.Eventos
{
   public class TipoAmbientacion
    {
        public int IdTipoAmbientacion { get; set; }
        public string Descripcion { get; set; }

        public List<TipoAmbientacion> LeerTodo()
        {
            Onbreak.Datos.OnBreakEntities bbdd = new Onbreak.Datos.OnBreakEntities();
            List<Onbreak.Datos.TipoAmbientacion> datos = bbdd.TipoAmbientacion.ToList();
            List<TipoAmbientacion> ListaContrato = ConvertirLista(datos);
            return ListaContrato;
        }
        public List<TipoAmbientacion> ConvertirLista(List<Onbreak.Datos.TipoAmbientacion> ListaAConvertir)
        {
            List<TipoAmbientacion> ListaContrato = new List<TipoAmbientacion>();
            foreach (Onbreak.Datos.TipoAmbientacion datos in ListaAConvertir)
            {
                TipoAmbientacion modal = new TipoAmbientacion();
                CommonBC.Syncronize(datos, modal);
                ListaContrato.Add(modal);
            }
            return ListaContrato;
        }
    }
}
