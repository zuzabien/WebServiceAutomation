using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;

namespace WebServiceAutomation
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Step 1. To create Http Client
            HttpClient httpClient = new HttpClient();
            httpClient.Dispose(); // Close the connection and release the resource
        }
    }
}
