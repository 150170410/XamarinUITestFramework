using System;
using NUnit.Framework;
using Xamarin.UITest;
using QlczasXamarinUITestFramework.Framework;
using QlczasXamarinUITestFramework.Framework.Data;

namespace ExampleProjectName.UITests.Pages //TODO Update your Project name
{
    public abstract class ExampleProjectBasePage : BasePage //TODO All your Project Test classes should inherit this class
    {
        public ExampleProjectBasePage(IApp app) : base(app)
        {
        }
       
        public ExampleProjectBasePage AssertExpectedWebViewPageWasOpened(int webViewIndex, string pageHeader)
        {
            WaitForWebElement(webViewIndex, pageHeader, Timeout.VeryShort);
            AssertElementWithPartialTextCount(webViewIndex, pageHeader, 1);
            return this;    
        }
        
        public ExampleProjectBasePage AssertExpectedMobilePageWasOpened(string pageHeader)
        {
            WaitForElement(pageHeader, Timeout.VeryShort);
            AssertElementCount(pageHeader, 1);
            return this;    
        }
        
        //TODO add your Test methods common to all of Pages you test
        
    }
}