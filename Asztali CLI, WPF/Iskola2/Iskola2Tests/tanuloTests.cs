using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iskola2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iskola2.Tests
{
    [TestClass()]
    public class tanuloTests
    {
        [TestMethod()]
        public void AzonositoTest()
        {
            tanulo tanulo = new tanulo("2006;c;Bodnar Szilvia");

            // Act
            string azonosito = tanulo.Azonosito();

            // Assert
            Assert.AreEqual("6cbodszi", azonosito);


        }
        [TestMethod()]
        public void AzonositoTest2()
        {
            tanulo tanulo = new tanulo("2002;d;Bodnar Szilvia");

            // Act
            string azonosito = tanulo.Azonosito();

            // Assert
            Assert.AreEqual("6cbodszi", azonosito);


        }
    }
}