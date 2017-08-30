using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace QlczasXamarinUITestFramework.Framework
{
    public interface IPageInteractions
    {
        //Mobile Elements handling
        AppResult[] FindElement(string selector);
        AppResult[] WaitForElement(string selector, TimeSpan timeoutInSec);
		void EnterTextInElement(string selector, string text);
        void SetPicker(string elementId, string newValue, int newValueId, Platform platform);
		void TapElementIfPresent(string selector);
        void TapElementMarkedWithText(string marked, string elementText);
		string GetTextFromTextBox(string selector);

        //Web Elements handling
        AppWebResult[] FindWebElement(int index, string selector);
        AppWebResult[] FindWebElementWithIndex(int index, int elementIndex, string selector);
        AppWebResult[] WaitForWebElement(string webViewId, string selector, TimeSpan timeoutInSec);
        AppWebResult[] WaitForWebElement(int index, string selector, TimeSpan timeoutInSec);
        void WaitForNoWebElement(int index, string selector, TimeSpan timeoutInSec);
		void EnterTextInWebElement(int index, string selector, string text);
        void TapWebElementIfPresent(int index, string selector);
    }
}
