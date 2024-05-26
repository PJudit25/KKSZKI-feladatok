using Microsoft.VisualStudio.TestTools.UnitTesting;
using tesztverseny;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tesztverseny.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void f_telitalalatTest()
        {
            //Assert.AreEqual(true, Program.f_telitalalat("BCCCDBBBBCDAAA", "BCCCDBBBBCDAAA"));
            //Assert.AreEqual(true, Program.f_telitalalat("ACBCDBCCBCDADA", "BCCCDBBBBCDAAA"));
            string helyesValasz = "BCCCDBBBBCDAAA";
            string rosszValaszok = "BCCCDBBBBCDAXX";

            // Tesztelés
            Assert.IsTrue(Program.f_telitalalat(helyesValasz,helyesValasz), "A válaszoknak helyesnek kell lenniük.");
            Assert.IsFalse(Program.f_telitalalat(rosszValaszok,helyesValasz), "A válaszoknak helytelennek kell lenniük.");

        }

        [TestMethod()]
        public void f_szazalekTest()
        {
            string helyesValasz = "BCCCDBBBBCDAAA";
            string valaszok1 = "BCCCDBBBBCDAAA"; // 100%
            string valaszok2 = "BCCCDBBBBCDAXX"; // 10 helyes válasz -> 10/14 * 100 = ~71%

            // Tesztelés
            Assert.AreEqual(100, Program.f_szazalek(valaszok1, helyesValasz), "A százaléknak 100-nak kell lennie.");
            Assert.AreEqual(71, Program.f_szazalek(valaszok2, helyesValasz), "A százaléknak 71-nek kell lennie.");
        }
    }
}