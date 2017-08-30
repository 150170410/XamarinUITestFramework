using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace QlczasXamarinUITestFramework.Framework.Controllers
{
    public class WebViewElements : IWebViewElements
    {
        public WebViewElements(IApp app)
        {
            _app = app;
        }

        private readonly IApp _app;

		public AppWebResult[] FindElement(int index, string selector)
		{
			return _app.Query(c => c.WebView(index).Css(selector));
		}

        public AppWebResult[] FindElementWithIndex(int index, int elementIndex, string selector)
        {
            return _app.Query(c => c.WebView(index).Css(selector).Index(elementIndex));
        }
	      
	    public void TapElement(int index, string selector)
	    {
		    _app.Tap(c => c.WebView(index).Css(selector));
	    }

		public void WaitForNoElement(int index, string selector)
		{
			_app.WaitForNoElement(c => c.WebView(index).Css(selector));
		}

		public void WaitForNoElement(int index, string selector, TimeSpan timeoutInSec)
		{
            _app.WaitForNoElement(c => c.WebView(index).Css(selector), postTimeout: timeoutInSec);
		}

		public void EnterText(int index, string selector, string text, bool clearFirst = false, bool dismissKeyboard = false)
		{
			if (clearFirst)
			{
				_app.ClearText(c => c.Css(selector));
			}
			TapElement(index, selector);
			EnterTextInWebView(index, selector, text);

			if (dismissKeyboard)
			{
				_app.DismissKeyboard();
			}
		}
               
		public int GetWebViewIndexById(string webViewId)
		{
			var result = _app.Query(c => c.WebView());

			foreach (var webView in result)
			{
				if (webView.Id != webViewId) continue;
				break;
			}
			return -1;
		}

		//Supporting methods
		private void EnterTextInWebView(int index, string selector, string content)
        {
            _app.EnterText(c => c.WebView(index).Css(selector), content);
        }

    }

}
