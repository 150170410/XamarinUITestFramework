using System;
using System.Collections.Generic;
using Xamarin.UITest.Queries;

namespace QlczasXamarinUITestFramework.Framework.Controllers
{
    public interface IMobileController
    {
        AppResult[] FindElement(string selector);
        AppResult[] FindElementWithPartialText(string selector);
        AppResult[] WaitForElement(string selector, TimeSpan timeoutInSec);
        AppResult[] WaitForElementWithPartialText(string selector);
        void WaitForNoElement(string selector, TimeSpan timeoutInSec);
        void WaitForNoElementWithPartialText(string selector, TimeSpan timeoutInSec);
        void EnterText(string selector, string text, bool clearFirst = false, bool dismissKeyboard = false);
        void AssertElementCount(string marked, int expectedCount);
        void AssertElementWithPartialTextCount(string marked, int expectedCount);
        void AssertAwaitedElementsCount(IDictionary<string, int> expectedElementsCounts);
        void AssertAwaitedElementCount(string elementText, int expectedCount = 1);
        void SetDroidPicker(int newValueId);
        void SetIosPicker(string newValue);
        void ScrollPageDownToElement(string selector);
        void ScrollPageUpToElement(string selector);
        void TakeScreenshot(string title);
        void TapElement(string selector);
        void TapElementWithPartialText(string selector);
        void DoubleTapElement(string selector);
        void DragAndDropElementOn(string what, string where);
        void ZoomInOnElement(string selector);
        void ZoomOutOnElement(string selector);
        void SwipeElementLeft(string selector);
        void SwipeElementRight(string selector);
        void TouchAndHoldElement(string selector);
        void SetLandscapeOrientation();
        void SetPortraitOrientation();
        void NavigateBack();
    }
}