using Xamarin.UITest.Queries;

namespace QlczasXamarinUITestFramework.Framework.Controllers
{
    public interface IWebViewElements
    {
		AppWebResult[] FindElement(int index, string selector);
        AppWebResult[] FindElementWithIndex(int index, int elementIndex, string selector);
        void TapElement(int index, string selector);
        void WaitForNoElement(int index, string selector);
        void EnterText(int index, string selector, string text, bool clearFirst = false, bool dismissKeyboard = false);
        int GetWebViewIndexById(string webViewId);
    }
}
