using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio.Valorizador
{
   public class ValCocktail : IValorizador
    {
        public double ValorTotal { get; set; }
        private double valorAsistente;
        private double valorPersonalA;
        private double valorAmbientacion;
        private int valorMusicaAmbiente;
        public void CalcularTotal(int asistentes, int personalAdicional, double valorBase, int PersonalBase)
        {
            if (asistentes >= 1 && asistentes <= 20)
                valorAsistente = 4;
            if (asistentes >= 21 && asistentes <= 50)
                valorAsistente = 6;
            if (asistentes > 50)
                valorAsistente = 6 + (((asistentes - 50) / 20) * 2);

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
             ValorTotal = valorAsistente + valorPersonalA + valorBase + PersonalBase + valorAmbientacion + valorMusicaAmbiente;
        }

        public int ValorMusicaAmbiente(bool SeleccionMusica)
        {
            switch (SeleccionMusica)
            {
                case true:
                    valorMusicaAmbiente = 1;
                    break;
                case false:
                    valorMusicaAmbiente = 0;
                    break;
            }
            return valorMusicaAmbiente;
        }

        public double ValorAmbientacion(int idTipoAmbientacion)
        {

            switch (idTipoAmbientacion)
            {
                case 10:
                    valorAmbientacion = 2;
                    break;
                case 20:
                    valorAmbientacion = 5;
                    break;
                default: return 0;
            }
            return valorAmbientacion;
        }
    }
}
