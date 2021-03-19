using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Coin_Return_Algorithm;
using System.Linq;


namespace CoinUnitTest
{
    [TestClass]
    public class CoinUnitTest
    {
        [TestMethod]
        public void ReturnOneDollar()
        {
            //Arange
            int[] result;

            //Act
            result = Program.GetReturns(11,10);

            //Assert
            Assert.AreEqual(result[0], 1);
        }
        [TestMethod]
        public void ReturnOneDollarRecursive()
        {
            //Arange
            int[] result;

            //Act
            result = Program.GetReturnsRecursive(11, 10);

            //Assert
            Assert.AreEqual(result[0], 1);
        }
        [TestMethod]
        public void ReturnNothingRecursive()
        {
            //Arange
            int[] result;
            //Act
            result = Program.GetReturnsRecursive(100, 100);

            //Assert
            Assert.AreEqual(result.Sum(), 0);
        }
        [TestMethod]
        public void ReturnNothing()
        {
            //Arange
            int[] result;

            //Act
            result = Program.GetReturns(100, 100);

            //Assert
            Assert.AreEqual(result.Sum(), 0);
        }
    }
}
