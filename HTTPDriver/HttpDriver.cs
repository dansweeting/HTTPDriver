using System.Collections.ObjectModel;
using HTTPDriver.Browser;
using OpenQA.Selenium;

namespace HTTPDriver
{
    public class HttpDriver : IWebDriver
    {
        private readonly BrowserEngine _browser;
        private readonly INavigation _navigation;
        private readonly IOptions _manager;

        public HttpDriver(IWebRequester webRequester)
        {
            _browser = new BrowserEngine(webRequester);
            _navigation = new Navigation(this);
            _manager = new Manage(GetBrowser().Cookies);
        }

        public IWebElement FindElement(By by)
        {
            return by.FindElement(new WebElementFinder(_browser.Page.HtmlNode(), Navigate()));
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return by.FindElements(new WebElementFinder(_browser.Page.HtmlNode(), Navigate()));
        }

        public void Dispose()
        {
        }

        public void Close()
        {
            throw new System.NotImplementedException();
        }

        public void Quit()
        {
            throw new System.NotImplementedException();
        }

        public IOptions Manage()
        {
            return _manager;
        }

        public INavigation Navigate()
        {
            return _navigation;
        }

        public ITargetLocator SwitchTo()
        {
            throw new System.NotImplementedException();
        }

        public string Url
        {
            get { return _browser.Location.AbsoluteUri; }
            set {  }
        }

        public string Title
        {
            get
            {
                return _browser.Page.Title();
            }
        }

        public string PageSource
        {
            get { return _browser.Page.Html(); }
        }

        public void SendRequest(string url)
        {  
            _browser.Load(url);
        }

        public string CurrentWindowHandle
        {
            get { throw new System.NotImplementedException(); }
        }

        public ReadOnlyCollection<string> WindowHandles
        {
            get { throw new System.NotImplementedException(); }
        }

        public BrowserEngine GetBrowser()
        {
            return _browser;
        }
    }
}