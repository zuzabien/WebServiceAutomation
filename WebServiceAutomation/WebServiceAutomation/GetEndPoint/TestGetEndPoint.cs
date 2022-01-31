using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceAutomation.GetEndPoint
{
    [TestClass]
    public class TestGetEndPoint
    {
        private string getUrl = "http://localhost:8080/laptop-bag/webapi/api/all"; // private variable, so that it can be accessed by all the test methods
        [TestMethod]
        public void TestGetAllEndPoint()
        {
            // Step 1. To create the HTTP client
            HttpClient httpClient = new HttpClient();

            // Step 2 & 3. Create the request and execute it
            httpClient.GetAsync(getUrl);

            // Close the connection
            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetAllEndPointWithUri()
        {
            // Step 1. To create the HTTP client
            HttpClient httpClient = new HttpClient();

            // Step 2 & 3. Create the request and execute it
            Uri getUri = new Uri(getUrl);
            Task<HttpResponseMessage>  httpResponse = httpClient.GetAsync(getUri);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            // Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status code =>" + statusCode); // only string representation of the status code
            Console.WriteLine("Status code =>" + (int)statusCode); // numerical representation of the status code

            // Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);


            // Close the connection
            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetAllEndPointWithInvalidUri()
        {
            // Step 1. To create the HTTP client
            HttpClient httpClient = new HttpClient();

            // Step 2 & 3. Create the request and execute it
            Uri getUri = new Uri(getUrl + "/random");
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            // Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status code =>" + statusCode); // only string representation of the status code
            Console.WriteLine("Status code =>" + (int)statusCode); // numerical representation of the status code

            // Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            // Close the connection
            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetAllEndPointInJsonFormat()
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/json");

            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            // Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status code =>" + statusCode); // only string representation of the status code
            Console.WriteLine("Status code =>" + (int)statusCode); // numerical representation of the status code

            // Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            // Close the connection
            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetAllEndPointInXmlFormat()
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Add("Accept", "application/xml");

            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            // Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status code =>" + statusCode); // only string representation of the status code
            Console.WriteLine("Status code =>" + (int)statusCode); // numerical representation of the status code

            // Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            // Close the connection
            httpClient.Dispose();
        }

        [TestMethod]
        public void TestGetAllEndPointInXmlFormatUsingAcceptHeader()
        {
            MediaTypeWithQualityHeaderValue jsonHeader = new MediaTypeWithQualityHeaderValue("application/json");
            HttpClient httpClient = new HttpClient();
            HttpRequestHeaders requestHeaders = httpClient.DefaultRequestHeaders;
            requestHeaders.Accept.Add(jsonHeader);
            //requestHeaders.Add("Accept", "application/xml");

            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            // Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status code =>" + statusCode); // only string representation of the status code
            Console.WriteLine("Status code =>" + (int)statusCode); // numerical representation of the status code

            // Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            // Close the connection
            httpClient.Dispose();
        }

        public void TestGetEndPointUsingSendAsync()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.RequestUri = new Uri(getUrl);
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.Headers.Add("Accept", "application/json");

            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);

            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            // Status Code
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status code =>" + statusCode); // only string representation of the status code
            Console.WriteLine("Status code =>" + (int)statusCode); // numerical representation of the status code

            // Response Data
            HttpContent responseContent = httpResponseMessage.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            Console.WriteLine(data);

            // Close the connection
            httpClient.Dispose();

        }

        [TestMethod]
        public void TestUsingStatement()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using(HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                {

                }
            }
        }

    }
}
