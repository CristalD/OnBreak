using OnBreak.Negocio.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio
{
    public class Cocktail : IEventos
    {
        public string Numero { get; set; }
        public int IdTipoAmbientacion { get; set; }
        public bool Ambientacion { get; set; }
        public bool MusicaAmbiental { get; set; }
        public bool MusicaCliente { get; set; }

        public bool Crear()
        {
            try
            {
                Onbreak.Datos.OnBreakEntities bbdd = new Onbreak.Datos.OnBreakEntities();
                Onbreak.Datos.Cocktail cocktail = new Onbreak.Datos.Cocktail();
                CommonBC.Syncronize(this, cocktail);
                bbdd.Cocktail.Add(cocktail);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}