using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio.Valorizador
{
    public class ValCoffeBreak : IValorizador
    {
        private double _ValorTotal;

        public double ValorTotal
        {
            get { return _ValorTotal; }
            set { _ValorTotal = value; }
        }

        private double valorAsistente;
        private double valorPersonalA;

        public void CalcularTotal(int asistentes, int personalAdicional, double valorBase, int PersonalBase)
        {
            if (asistentes >= 1 && asistentes <= 20)
                valorAsistente = 3;
            if (asistentes >= 21 && asistentes <= 50)
                valorAsistente = 5;
            if (asistentes > 50)
                valorAsistente = 5 + (((asistentes - 50) / 20) * 2);


            if (personalAdicional == 2)
                valorPersonalA = 2;
            else if (personalAdicional == 3)
                valorPersonalA = 3;
            else if (personalAdicional == 4)
                valorPersonalA = 3.5;
            else if (personalAdicional > 4)
            {
                valorPersonalA = 3.5;

                for (int i = 0; i < personalAdicional - 4; i++)
                {
                    valorPersonalA += 0.5;
                }
            }
            ValorTotal = valorAsistente + valorPersonalA + valorBase + PersonalBase;
        }

    }
}
