using System;
using System.Collections.Generic;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using QlczasXamarinUITestFramework.Framework.Data;

namespace QlczasXamarinUITestFramework.Framework.Controllers
{
    public class MobileController : IMobileController
    {
        public MobileController(IApp app)
        {
            _app = app;
        }

        private readonly IApp _app;

        public AppResult[] FindElement(string selector)
        {
            return _app.Query(selector);
        }

	    public AppResult[] FindElementWithPartialText(string selector)
	    {
		    return _app.Query(c => c.Property("text").Contains(selector));
	    }

		public AppResult[] WaitForElement(string selector)
		{
			return WaitForElement(selector, Timeout.VeryShort);
		}

		public AppResult[] WaitForElement(string selector, TimeSpan timeoutInSec)
		{
			return _app.WaitForElement(selector, timeout: timeoutInSec);
		}

	    public AppResult[] WaitForElementWithPartialText(string selector)
	    {
		    return WaitForElementWithPartialText(selector, Timeout.VeryShort);
	    }
	    
	    public AppResult[] WaitForElementWithPartialText(string selector, TimeSpan timeoutInSec)
	    {
		    return _app.WaitForElement(c => c.Property("text").Contains(selector), timeout: timeoutInSec);
	    }

        public void WaitForNoElement(string selector, TimeSpan timeoutInSec)
		{
			_app.WaitForNoElement(selector, postTimeout: timeoutInSec);
		} 
	    
	    public void WaitForNoElementWithPartialText(string selector, TimeSpan timeoutInSec)
	    {
		    _app.WaitForNoElement(c => c.Property("text").Contains(selector), postTimeout: timeoutInSec);
		    
	    } 

		public void EnterText(string selector, string text, bool clearFirst = false, bool dismissKeyboard = false)
        {
            _app.WaitForElement(selector);

            if (clearFirst)
            {
                _app.ClearText(selector);
            }
            TapElement(selector);
            _app.EnterText(selector, text);

            if (dismissKeyboard)
            {
                _app.DismissKeyboard();
            }
        }

		public void AssertElementCount(string marked, int expectedCount)
		{
			var actualCount = FindElement(marked).Length;
			Assert.AreEqual(expectedCount, actualCount,
                            $"There is/are {actualCount} elements marked:' {marked}");
		}
	    
	    public void AssertElementWithPartialTextCount(string marked, int expectedCount)
	    {
		    var actualCount = FindElementWithPartialText(marked).Length;
		    Assert.AreEqual(expectedCount, actualCount,
			    			$"There is/are {actualCount} elements marked:' {marked}");
	    }
	    
	    public void AssertAwaitedElementsCount(IDictionary<string, int> expectedElementsCounts)
	    {
		    foreach (var expectedCount in expectedElementsCounts)
		    {
			    AssertAwaitedElementCount(expectedCount.Key, expectedCount.Value);
		    }
	    }

	    public void AssertAwaitedElementCount(string elementText, int expectedCount = 1)
	    {
		    WaitForElement(elementText);
		    AssertElementCount(elementText, expectedCount);
	    }

        public void SetDroidPicker(int newValueId)
        {
            _app.Query(c => c.Class("numberPicker").Invoke("setValue", newValueId));
	        TapElement("OK");
        }

        public void SetIosPicker(string newValue)
        {
			_app.ScrollUpTo(z => z.Marked(newValue), x => x.Class("UIPickerTableView").Index(0),
					ScrollStrategy.Programmatically, 0.67D, 500, true, Timeout.VeryLong);
			TapElement(newValue);
			TapElement("Done");
        }

	    public void ScrollPageDownToElement(string selector)
	    {
		    _app.ScrollDownTo(selector);
	    }
	    
	    public void ScrollPageUpToElement(string selector)
	    {
		    _app.ScrollUpTo(selector);
	    }

		public void TakeScreenshot(string title)
		{
			_app.Screenshot(title);
		}

		public void TapElement(string selector)
		{
			_app.Tap(selector);
		}
	    
	    public void TapElementWithPartialText(string selector)
	    {
		    _app.Tap(c => c.Property("text").Contains(selector));
	    }

	    public void DoubleTapElement(string selector)
	    {
		    _app.DoubleTap(selector);
	    }

	    public void DragAndDropElementOn(string what, string where)
	    {
		    _app.DragAndDrop(what, where);
	    }
	    
	    public void ZoomInOnElement(string selector)
	    {
		 _app.PinchToZoomIn(selector);   
	    }
	    
	    public void ZoomOutOnElement(string selector)
	    {
		 _app.PinchToZoomOut(selector);   
	    }
	    
	    public void SwipeElementLeft(string selector)
	    {
		 _app.SwipeRightToLeft(selector);   
	    }
	    
	    public void SwipeElementRight(string selector)
	    {
		 _app.SwipeLeftToRight(selector);   
	    }
	    
	    public void TouchAndHoldElement(string selector)
	    {
		    _app.TouchAndHold(selector);
	    }
	    
	    public void SetLandscapeOrientation()
	    {
		    _app.SetOrientationLandscape();
	    }
	    
	    public void SetPortraitOrientation()
	    {
		    _app.SetOrientationPortrait();
	    }
	    
	    public void NavigateBack()
	    {
		    _app.Back();
	    }
    }
}