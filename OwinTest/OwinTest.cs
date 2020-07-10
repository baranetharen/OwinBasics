using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Owin.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owin.selfHosting;

namespace OwinTest
{
   
    [TestClass]
    public class OwinTest
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var content  = await OwinTestWrapper<string>(async (x) =>
            {
                var resp  = await x.GetAsync("/");
                return await resp.Content.ReadAsStringAsync();
            });

            Assert.AreEqual("Welcome", content);
        }

        [TestMethod]
        public async Task TestCheckForJpeg()
        {
            var content = await OwinTestWrapper<string>(async (x) =>
            {
                var resp = await x.GetAsync("/photo.jpg");
                return resp.Content.Headers.ContentType.MediaType;
            });

            Assert.AreEqual("image/jpeg", content);
        }


        private async Task<T> OwinTestWrapper<T>(Func<HttpClient,Task<T>> Callback)
        {
            using (var server = TestServer.Create<Startup>())
            {
                return await Callback(server.HttpClient);
            }
        }
    }
}
