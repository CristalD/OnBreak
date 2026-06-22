using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio.Valorizador
{
    public interface IValorizador
    {
        double ValorTotal { get; set;}

        void CalcularTotal(int asistentes, int personalAdicional, double valorBase, int PersonalBase);
    }
}
