using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AirportTest
{
    [TestFixture]
    public class AirportTest
    {
        [Test]
        public void Test1()
        {
            using (var page = new Page())
            {
                page.TestCase1();
                Thread.Sleep(5000);
            }
        }

        [Test]
        public void Test2()
        {
            using (var page = new Page())
            {
                page.TestCase2();
                Thread.Sleep(5000);
            }
        }

        [Test]
        public void Test3()
        {
            using (var page = new Page())
            {
                page.TestCase3();
                Thread.Sleep(5000);
            }
        }

        [Test]
        public void Test4()
        {
            using (var page = new Page())
            {
                page.TestCase4();
                Thread.Sleep(5000);
            }
        }

        [Test]
        public void Test5()
        {
            using (var page = new Page())
            {
                page.TestCase5();
                Thread.Sleep(5000);
            }
        }

        [Test]
        public void Test6()
        {
            using (var page = new Page())
            {
                page.TestCase6();
                Thread.Sleep(5000);
            }
        }

        [Test]
        public void Test7()
        {
            using (var page = new Page())
            {
                page.TestCase7();
                Thread.Sleep(5000);
            }
        }

        [Test]
        public void Test8()
        {
            using (var page = new Page())
            {
                page.TestCase8();
                Thread.Sleep(10000);
            }
        }

        [Test]
        public void Test9()
        {
            using (var page = new Page())
            {
                page.TestCase9();
                Thread.Sleep(5000);
            }
        }


    }
}
