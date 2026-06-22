using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio
{
    public class ModalidadServicio
    {
        public string IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public string Nombre { get; set; }
        public double ValorBase { get; set; }
        public int PersonalBase { get; set; }

        public bool Leer()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            var modal = new Onbreak.Datos.ModalidadServicio();

            try
            {
                modal = bbdd.ModalidadServicio.First(s => s.IdModalidad == IdModalidad);
                CommonBC.Syncronize(modal, this);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }
        public List<ModalidadServicio> LeerTodo(int tipoSeleccionado)
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            List<Onbreak.Datos.ModalidadServicio> datos = bbdd.ModalidadServicio.Where(m => m.IdTipoEvento == tipoSeleccionado).ToList();
            List<ModalidadServicio> ListaContrato = ConvertirLista(datos);
            foreach(ModalidadServicio modal in ListaContrato)
            {
                modal.Nombre.Trim();
            }
            return ListaContrato;
        }
        public List<ModalidadServicio> LeerTodo()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            List<Onbreak.Datos.ModalidadServicio> datos = bbdd.ModalidadServicio.ToList();
            List<ModalidadServicio> ListaContrato = ConvertirLista(datos);
            foreach(ModalidadServicio modal in ListaContrato)
            {
                modal.Nombre.Trim();
            }
            return ListaContrato;
        }
        public List<ModalidadServicio> ConvertirLista(List<Onbreak.Datos.ModalidadServicio> ListaAConvertir)
        {
            List<ModalidadServicio> ListaContrato = new List<ModalidadServicio>();
            foreach (Onbreak.Datos.ModalidadServicio datos in ListaAConvertir)
            {
                ModalidadServicio modal = new ModalidadServicio();
                CommonBC.Syncronize(datos, modal);
                modal.Nombre = modal.Nombre.Trim();
                ListaContrato.Add(modal);
            }
            return ListaContrato;
        }
    }
}
