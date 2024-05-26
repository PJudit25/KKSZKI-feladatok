using Microsoft.VisualStudio.TestTools.UnitTesting;
using celloveszetCLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace celloveszetCLI.Tests
{
    [TestClass()]
    public class CellovoTests
    {
        [TestMethod()]
        public void legnagyobbTest()
        {
            Cellovo cellovoA = new Cellovo("A;22;29;12;23");
            int legnagyobb = cellovoA.legnagyobb();
            Assert.AreEqual(29,legnagyobb);
        }
        [TestMethod()]
        public void legnagyobbTest2()
        {
            Cellovo cellovoB = new Cellovo("B;16;45;87;33");
            int legnagyobb = cellovoB.legnagyobb();
            Assert.AreEqual(87, legnagyobb);
        }
        [TestMethod()]
        public void legnagyobbTest3()
        {
            Cellovo cellovoC = new Cellovo("C;96;49;67;45");
            int eredmeny = 96;
            Assert.AreEqual(eredmeny, cellovoC.legnagyobb());
        }
        [TestMethod()]
        public void legnagyobbTest4()
        {
            Cellovo cellovoD = new Cellovo("D;44;3;12;77");
            int eredmeny = 77;
            Assert.AreEqual(eredmeny, cellovoD.legnagyobb());
        }
    }
}