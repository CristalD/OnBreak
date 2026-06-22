using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio
{
    public class TipoEvento
    {
        public int IdTipoEvento { get; set; }
        public String Descripcion { get; set; }

        public TipoEvento()
        {
            this.Init();
        }

        public void Init()
        {
            IdTipoEvento = 0;
            Descripcion = String.Empty;
        }
        public bool Leer()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            var tipo = new Onbreak.Datos.TipoEvento();
            try
            {
                tipo = bbdd.TipoEvento.First(c => c.IdTipoEvento == this.IdTipoEvento);
                CommonBC.Syncronize(tipo , this);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<TipoEvento> LeerTodo()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            List<Onbreak.Datos.TipoEvento> datos = bbdd.TipoEvento.ToList();
            List<TipoEvento> ListaContrato = GenerarLista(datos);
            return ListaContrato;
        }
        private List<TipoEvento> GenerarLista(List<Onbreak.Datos.TipoEvento> listaAConvertir)
        {
            List<TipoEvento> listaContrato = new List<TipoEvento>();
            foreach (Onbreak.Datos.TipoEvento datos in listaAConvertir)
            {
                TipoEvento negocio = new TipoEvento();
                CommonBC.Syncronize(datos, negocio);
                listaContrato.Add(negocio);
            }
            return listaContrato;
        }
    }
}
