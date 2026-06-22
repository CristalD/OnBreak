using OnBreak.Negocio.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OnBreak.Negocio
{
    public class Cenas : IEventos
    {
        public string Numero { get; set; }
        public int IdTipoAmbientacion { get; set; }
        public bool MusicaAmbiental { get; set; }
        public bool LocalOnBreak { get; set; }
        public bool OtroLocalOnBreak { get; set; }
        public double ValorArriendo { get; set; }

        public bool Crear()
        {

                Onbreak.Datos.OnBreakEntities bbdd = new Onbreak.Datos.OnBreakEntities();
                Onbreak.Datos.Cenas cenas = new Onbreak.Datos.Cenas();
                CommonBC.Syncronize(this, cenas);
                bbdd.Cenas.Add(cenas);
                bbdd.SaveChanges();
                return true;
            

        }
    }
}
