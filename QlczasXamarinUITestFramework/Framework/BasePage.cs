using System;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using QlczasXamarinUITestFramework.Framework.Controllers;
using QlczasXamarinUITestFramework.Framework.Data;

namespace QlczasXamarinUITestFramework.Framework
{
    public abstract class BasePage : MobileController, IPageInteractions
    {
        protected IApp App;
        
        protected BasePage(IApp app) : base (app)
        {
            App = app;
        }

        public AppWebResult[] FindWebElement(int index, string selector)
        {
            var webViewElement = new WebViewElements(App);
            return webViewElement.FindElement(index, selector);
        }

        public AppWebResult[] FindWebElementWithIndex(int index, int elementIndex, string selector)
        {
            var webViewElement = new WebViewElements(App);
            return webViewElement.FindElementWithIndex(index, elementIndex, selector);
        }

		public AppWebResult[] WaitForWebElement(int index, string selector)
		{
			return WaitForWebElement(index, selector, Timeout.VeryShort);
		}

        public AppWebResult[] WaitForWebElement(string webViewId, string selector, TimeSpan timeoutInSec)
        {
            var webViewElement = new WebViewElements(App);
            var webViewIndex = webViewElement.GetWebViewIndexById(webViewId);
            return App.WaitForElement(c => c.WebView(webViewIndex).Css(selector), timeout: timeoutInSec);
        }

        public AppWebResult[] WaitForWebElement(int index, string selector, TimeSpan timeoutInSec)
        {
            return App.WaitForElement(c => c.WebView(index).Css(selector), timeout: timeoutInSec);
        }

        public void WaitForNoWebElement(int index, string selector, TimeSpan timeoutInSec)
        {
			var webViewElement = new WebViewElements(App);
            webViewElement.WaitForNoElement(index, selector, timeoutInSec);
        }

        public void EnterTextInElement(string selector, string text)
        {
            EnterText(selector, text, true, true);
        }

        public void EnterTextInWebElement(int index, string selector, string text)
        {
            var webViewElement = new WebViewElements(App);
            webViewElement.EnterText(index, selector, text, true, true);
        }

        public void SetPicker(string selector, string newValue, int newValueId, Platform platform)
        {
            TapElement(selector);
            if (platform == Platform.Android)
            {
                SetDroidPicker(newValueId);
            }
            else
            {
               SetIosPicker(newValue);
            }
        }

        public void TapElementIfPresent(string selector)
        {
            while (FindElement(selector).Length > 0)
            {
                TakeScreenshot($"Press {selector} button");
                TapElement(selector);
                break;
            }
        }

        public void TapWebElementIfPresent(int index, string selector)
        {
            var webViewElement = new WebViewElements(App);
            while (webViewElement.FindElement(index, selector).Length > 0)
            {
                TakeScreenshot($"Press {selector} button");
                webViewElement.TapElement(index, selector);
                break;
            }
        }

        public void TapElementMarkedWithText(string marked, string elementText)
        {
            App.WaitForElement(c => c.Marked(marked).Text(elementText));
            App.Tap(c => c.Marked(marked).Text(elementText));
        }

        public string GetTextFromTextBox(string selector)
        {
            var textBox = App.Query(selector).SingleOrDefault();
            return textBox != null ? textBox.Text : string.Empty;
        }
    }
}