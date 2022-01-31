using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MsTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod, TestCategory("Smoke")]
        public void TestMethod1()
        {
            Console.Write(" Test Method One");
        }

        [TestMethod]
        [Ignore]
        public void TestMethod2()
        {
            Console.Write(" Test Method Two ");
        }

        [TestInitialize]
        public void Setup()
        {
            Console.WriteLine(" This is Setup ");
        }

        [TestCleanup]
        public void TearDown()
        {
            Console.WriteLine(" This is Clean up ");
        }

        [ClassInitialize]
        public static void ClassSetup(TestContext testContext)
        {
            Console.WriteLine(" Class Set up ");
        }

        [ClassCleanup]
        public static void ClassTearDown()
        {
            Console.WriteLine(" Class Tear Down ");
        }

        [AssemblyInitialize]
        public static void AssemblySetup(TestContext testContext)
        {
            Console.WriteLine(" Assembly Setup ");
        }

        [AssemblyCleanup]
        public static void AssemblyTearDown()
        {
            Console.WriteLine(" Assembly Tear Down ");
        }
    }
}
