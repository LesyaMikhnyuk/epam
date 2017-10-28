using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_2
{
    public  class calc
    {
        public static int Sum(int a, int b)
        {
            return a + b;
        }
        public static int Subtraction(int a, int b)
        {
            return a - b;
        }
        public static int Multiplication(int a, int b)
        {
            return a * b;
        }
        public static int Division(int a, int b)
        {
            return a / b;
        }
    }

    [TestFixture]
    public class Test
    {
        [Test]
        public void TSum()
        {
            int res = calc.Sum(3, 2);
            Assert.AreEqual(5, res);
            res = calc.Sum(8, -1);
            Assert.AreEqual(7, res);
            res = calc.Sum(-2, -5);
            Assert.AreEqual(-7, res);
            res = calc.Sum(0, 1);
            Assert.AreEqual(1, res);

        }
        [Test]
        public void TSubtraction()
        {
            int res = calc.Subtraction(3, 2);
            Assert.AreEqual(1, res);
            res = calc.Subtraction(8, -1);
            Assert.AreEqual(9, res);
            res = calc.Subtraction(-2, -5);
            Assert.AreEqual(3, res);
            res = calc.Subtraction(0, 1);
            Assert.AreEqual(-1, res);
        }

        [Test]
        public void TMultiplication()
        {
            int res = calc.Multiplication(3, 2);
            Assert.AreEqual(6, res);
            res = calc.Multiplication(8, -1);
            Assert.AreEqual(-8, res);
            res = calc.Multiplication(-2, -5);
            Assert.AreEqual(10, res);
            res = calc.Multiplication(0, 1);
            Assert.AreEqual(0, res);
        }

        [Test]
        public void TDivision()
        {
            int res = calc.Division(4, 2);
            Assert.AreEqual(2, res);
            res = calc.Division(8, -1);
            Assert.AreEqual(-8, res);
            res = calc.Division(9, 3);
            Assert.AreEqual(3, res);
            res = calc.Division(10, 5);
            Assert.AreEqual(2, res);
        }
    }
}

