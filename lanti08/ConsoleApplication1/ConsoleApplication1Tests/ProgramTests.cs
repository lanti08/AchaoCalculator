using Microsoft.VisualStudio.TestTools.UnitTesting;
using Consoleapplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Consoleapplication1.Tests
{
    [TestClass()]
    public class ProgramTests
    {
       

     

        [TestMethod()]
        public void FractionTest()
        {

        }

        [TestMethod()]
        public void JudgeTest()
        {
            int a = 5;
            int b = 6;
            Assert.AreEqual(a,b,6);
        }

        [TestMethod()]
        public void CalcByDataTableTest()
        {

        }

        [TestMethod()]
        public void WriteTest()
        {

        }

        [TestMethod()]
        public void JudgePointTest()
        {

        }
    }
}