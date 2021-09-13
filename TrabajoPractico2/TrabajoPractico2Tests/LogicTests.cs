using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrabajoPractico2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico2.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        public void DivisionSinExcepcionTest()
        {
            //Arrange

            int dividendo = 50;
            int divisor = 5;

            int resultadoEsperado = 10;
            Logic logica = new Logic();

            //Act

            int resultadoActual = logica.Division(dividendo, divisor);

            //Assert

            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }

        [ExpectedException(typeof(Exceptions.DivisionPorCeroExcepcion))]
        [TestMethod()]
        public void DivisionConExcepcionTest()
        {
            //Arrange

            int dividendo = 50;
            int divisor = 0;

            Logic logica = new Logic();

            //Act

            logica.Division(dividendo, divisor);

            //Assert
        }

        [TestMethod]
        public void ConvertirUnaCadenaAEnteroSinExcepcionTest()
        {
            //Arrange

            String dato = "50";

            int resultadoEsperado = 50;
            Logic logica = new Logic();

            //Act

            int resultadoActual = logica.ConvertirUnaCadenaAEntero(dato);

            //Assert

            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }

        [ExpectedException(typeof(Exceptions.FormatoIncorrectoExcepcion))]
        [TestMethod()]
        public void ConvertirUnaCadenaAEnteroConExcepcionTest()
        {
            //Arrange

            String dato = "Hola";

            Logic logica = new Logic();

            //Act

            logica.ConvertirUnaCadenaAEntero(dato);

            //Assert
        }
    }
}