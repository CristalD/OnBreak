using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio
{
    public class TipoEmpresa
    {
        public int IdTipoEmpresa { get; set; }
        public String Descripcion { get; set; }

        public TipoEmpresa()
        {
            this.Init();
        }

        public void Init()
        {
            IdTipoEmpresa = 0;
            Descripcion = String.Empty;
        }
        public bool Leer()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            var tipo = new Onbreak.Datos.TipoEmpresa();
            try
            {
                tipo = bbdd.TipoEmpresa.First(c => c.IdTipoEmpresa == this.IdTipoEmpresa);
                CommonBC.Syncronize(tipo, this);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public List<TipoEmpresa> LeerTodo()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            List<Onbreak.Datos.TipoEmpresa> datos = bbdd.TipoEmpresa.ToList();
            List<TipoEmpresa> ListaContrato = GenerarLista(datos);
            return ListaContrato;
        }
        private List<TipoEmpresa> GenerarLista(List<Onbreak.Datos.TipoEmpresa> listaAConvertir)
        {
            List<TipoEmpresa> listaContrato = new List<TipoEmpresa>();
            foreach (Onbreak.Datos.TipoEmpresa datos in listaAConvertir)
            {
                TipoEmpresa negocio = new TipoEmpresa();
                CommonBC.Syncronize(datos, negocio);
                listaContrato.Add(negocio);
            }
            return listaContrato;
        }
    }
}
