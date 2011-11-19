using HTTPDriver.TestServer;
using NUnit.Framework;

namespace HTTPDriver.FunctionalTests
{
    [SetUpFixture]
    public class HttpTestSiteFixture
    {
        private readonly TestServer.TestServer _server;

        public HttpTestSiteFixture()
        {
            _server = new TestServer.TestServer(9001, new Site(@"..\..\..\HTTPDriver.TestSite", "/TestSite"));   
        }

        [SetUp]
        public void BeforeTests()
        {
            _server.Start();
        }

        [TearDown]
        public void AfterTests()
        {
            _server.Stop();
        }
    }
}