using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnBreak.Negocio;

namespace PruebasUnitarias
{
    [TestClass]
    public class ValorizadorTest
    {
        [TestMethod()]
        public void AsistentesNegativoTest()
        {
            //Arrange
            OnBreak.Negocio.Valorizador val = new Valorizador();

            //ACT
            try
            {
                val.CalcularValorEvento(2, -5, 2.5, 5);
            }
            catch (Exception ex)
            {
                //Assert
                StringAssert.Contains(ex.Message, "Asistentes debe ser un numero positivo y mayor a 0");
                return;
            }
            Assert.Fail("No se generó excepción por Asistentes negativo");
        }

        [TestMethod]
        public void AsistentesCeroTest()
        {
            //Arrange
            OnBreak.Negocio.Valorizador val = new Valorizador();
            //ACT
            try
            {
                val.CalcularValorEvento(2, 0, 2.5, 5);
            }
            catch (Exception ex)
            {
                //Assert
                StringAssert.Contains(ex.Message, "asistentes no puede ser 0");
                return;
            }
            Assert.Fail("No se generó excepción por Asistentes CERO");
        }

        [TestMethod]
        public void AdicionalMayorDiezTest()
        {
            //Arrange
            OnBreak.Negocio.Valorizador val = new Valorizador();
            //ACT
            try
            {
                val.CalcularValorEvento(11, 5, 2.5, 5);
            }
            catch (Exception ex)
            {
                //Assert
                StringAssert.Contains(ex.Message, "Maxima para personal adicional es 10");
                return;
            }
            Assert.Fail("No se generó excepción por Personal Adicional mayor a 10");
        }
    }
}
