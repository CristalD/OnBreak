using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OnBreak.Negocio
{
    public class ActividadEmpresa
    {
        public int IdActividadEmpresa { get; set; }
        public string Descripcion { get; set; }

        public ActividadEmpresa()
        {
            Init();
        }

        private void Init()
        {
            IdActividadEmpresa = 0;
            Descripcion = string.Empty;
        }

        //Filtrar por id
        public bool Leer()
        {
            var context = new Onbreak.Datos.OnBreakEntities();
            var act = new Onbreak.Datos.ActividadEmpresa();
            try
            {
                act = context.ActividadEmpresa.First(a => a.IdActividadEmpresa == this.IdActividadEmpresa);
                CommonBC.Syncronize(act, this);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        //lista de actividades
        public List<ActividadEmpresa> LeerTodo()
        {
            var context = new Onbreak.Datos.OnBreakEntities();
            List<Onbreak.Datos.ActividadEmpresa> datos = context.ActividadEmpresa.ToList();
            List<ActividadEmpresa> ListaNegocio = GenerarListado(datos);
            return ListaNegocio;
        }

        private List<ActividadEmpresa> GenerarListado(List<Onbreak.Datos.ActividadEmpresa> listaAConvertir)
        {
            List<ActividadEmpresa> listaNegocio = new List<ActividadEmpresa>();
            foreach (Onbreak.Datos.ActividadEmpresa datos in listaAConvertir)
            {
                ActividadEmpresa negocio = new ActividadEmpresa();
                CommonBC.Syncronize(datos, negocio);
                listaNegocio.Add(negocio);
            }
            return listaNegocio;
        }
    }
}

