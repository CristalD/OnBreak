using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio.Valorizador
{
   public class ValCenas : IValorizador
    {
        public double ValorTotal { get; set; }
        private double valorAsistente;
        private double valorPersonalA;
        private double valorAmbientacion;
        private double valorMusicaAmbiente;
        private int valorLocalOnBreak = 0;
        private double valorLocalOtro = 0;
        public void CalcularTotal(int asistentes, int personalAdicional, double valorBase, int PersonalBase)
        {
            if (asistentes >= 1 && asistentes <= 20)
                valorAsistente = asistentes*1.5;
            if (asistentes >= 21 && asistentes <= 50)
                valorAsistente = asistentes*1.2;
            if (asistentes > 50)
                valorAsistente = asistentes;

            if (personalAdicional == 2)
                valorPersonalA = 3;
            else if (personalAdicional == 3)
                valorPersonalA = 4;
            else if (personalAdicional == 4)
                valorPersonalA = 5;
            else if (personalAdicional > 4)
            {
                valorPersonalA = 5;

                for (int i = 0; i < personalAdicional - 5; i++)
                {
                    valorPersonalA += 0.5;
                }
            }
             ValorTotal = valorAsistente + valorPersonalA + valorBase + PersonalBase + valorMusicaAmbiente + valorAmbientacion+ valorLocalOnBreak + valorLocalOtro;
        }

        public double ValorTotalLocal(bool local,double MontoLocal)
        {
            if (local)
            {
                valorLocalOnBreak = 9;
                return valorLocalOnBreak;
            }
            else
            {
                valorLocalOtro = MontoLocal;
                return valorLocalOtro;
            }
        }

        public double ValorMusicaAmbiente(bool SeleccionMusica)
        {
            switch (SeleccionMusica)
            {
                case true:
                    valorMusicaAmbiente = 1.5;
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
                    valorAmbientacion = 3;
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
