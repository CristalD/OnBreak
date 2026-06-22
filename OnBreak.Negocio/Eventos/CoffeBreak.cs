using OnBreak.Negocio.Eventos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio
{
    public class CoffeBreak : IEventos
    {
        public string Numero { get; set; }
        public bool Vegetariana { get; set; }

        public bool Crear()
        {
            try
            {
                Onbreak.Datos.OnBreakEntities bbdd = new Onbreak.Datos.OnBreakEntities();
                Onbreak.Datos.CoffeeBreak coffe = new Onbreak.Datos.CoffeeBreak();
                CommonBC.Syncronize(this, coffe);
                bbdd.CoffeeBreak.Add(coffe);
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
