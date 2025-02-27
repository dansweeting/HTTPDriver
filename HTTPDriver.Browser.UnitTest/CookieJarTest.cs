using System.Net;
using NUnit.Framework;

namespace HTTPDriver.Browser.UnitTest
{
    [TestFixture]
    public class CookieJarTest
    {
        private CookieJar _jar;
        private Cookie _cookie;

        [SetUp]
        public void BeforeEachTest()
        {
            _jar = new CookieJar();
            _cookie = new Cookie("Chocolate", "Chip");
        }

        [Test]
        public void AddCookie()
        {
            Assert.That(_jar.AllCookies.Count, Is.EqualTo(0));            
            _jar.AddCookie(_cookie);

            Assert.That(_jar.AllCookies.Count, Is.EqualTo(1));
        }

        [Test]
        public void GetCookie()
        {
            _jar.AddCookie(_cookie);

            Assert.That(_jar.GetCookieNamed(_cookie.Name).Name, Is.EqualTo(_cookie.Name));
            Assert.That(_jar.GetCookieNamed(_cookie.Name).Value, Is.EqualTo(_cookie.Value));
            Assert.That(_jar.GetCookieNamed(_cookie.Name).Expires, Is.EqualTo(_cookie.Expires));
            Assert.That(_jar.GetCookieNamed(_cookie.Name).Domain, Is.EqualTo(_cookie.Domain));
        }

        [Test]
        public void DeleteCookieNamed()
        {
            _jar.AddCookie(_cookie);

            Assert.That(_jar.AllCookies.Count, Is.EqualTo(1));

            _jar.DeleteCookieNamed(_cookie.Name);

            Assert.That(_jar.AllCookies.Count, Is.EqualTo(0));
        }

        [Test]
        public void DeleteCookie()
        {
            _jar.AddCookie(_cookie);

            Assert.That(_jar.AllCookies.Count, Is.EqualTo(1));

            _jar.DeleteCookie(_cookie);

            Assert.That(_jar.AllCookies.Count, Is.EqualTo(0));
        }

        [Test]
        public void DeleteAllCookies()
        {
            _jar.AddCookie(_cookie);

            Assert.That(_jar.AllCookies.Count, Is.EqualTo(1));

            _jar.DeleteAllCookies();

            Assert.That(_jar.AllCookies.Count, Is.EqualTo(0));
        }
    }
}
