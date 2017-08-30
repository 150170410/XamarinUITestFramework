using System;
using NUnit.Framework;
using Xamarin.UITest;
using QlczasXamarinUITestFramework.Framework;
using QlczasXamarinUITestFramework.Framework.Data;
using ExampleProjectName.UITests.TestData;

namespace ExampleProjectName //TODO Update your Project name
{
    public abstract class ExampleLoginBasePage : BasePageWithLogin
    {
        public ExampleProjectBasePage(IApp app, ICredentialsProvider credentialsProvider) : base(app, credentialsProvider)
        {
        }
       
        public LoginToHomePage WaitForLoginPage(Platform platform)
        {
            WaitForElement(platform == Platform.iOS
                    ? SelectorsData.LoginPageElementsIos.LoginButtonName
                    : SelectorsData.LoginPageElementsAndroid.LoginButtonName, Timeout.VeryShort);
            TakeScreenshot();
            return this;
        }
        
        public LoginToHomePage WaitForLoginWebView()
        {
            WaitForWebElement(SelectorsData.LoginWebView.LoginWebViewIndex, SelectorsData.LoginWebView.LoginWebTextField, Timeout.Medium);
            WaitForWebElement(SelectorsData.LoginWebView.LoginWebViewIndex, SelectorsData.LoginWebView.PasswordWebTextField, Timeout.Medium);
            TakeScreenshot();
            return this;
        }

        public LoginToHomePage PressSignInButton()
        {
            WaitForWebElement(SelectorsData.LoginWebView.SignInButtonIndex, SelectorsData.LoginWebView.SignInButton, Timeout.VeryLong);
            TapWebElementIfPresent(SelectorsData.LoginWebView.SignInButtonIndex, SelectorsData.LoginWebView.SignInButton);
            return this;
        }

        public LoginToHomePage EnterUserCredentials()
        {
            GetCredentialsForLogin();
            EnterTextInWebElement(SelectorsData.LoginWebView.LoginWebViewIndex, SelectorsData.LoginWebView.LoginWebTextField, Credentials.Username);
            EnterTextInWebElement(SelectorsData.LoginWebView.LoginWebViewIndex, SelectorsData.LoginWebView.PasswordWebTextField, Credentials.Password);
            return this;
        }

        public LoginToHomePage AssertEmptyLoginAlertVisible(Platform platform)
        {
            WaitForWebElement(SelectorsData.LoginWebView.EmptyCredentialsAlertIndex, SelectorsData.Alerts.EmptyCredentialsId, Timeout.VeryLong);
            var errorMessageContent = App.Query(c=>c.Css(SelectorsData.Alerts.EmptyCredentialsId))[0].TextContent; 
            //Hack Above Example of obtaining text contents of element with index 0 by using methods straight from Xamarin.UITest
            Assert.AreEqual(SelectorsData.Alerts.EmptyCredentials, errorMessageContent);
            return this;
        }
        
        public LoginToHomePage WaitForHomePage(Platform platform)
        {
           WaitForElement(platform == Platform.iOS
                    ? SelectorsData.LoginPageElementsIos.HomePageHeader
                    : SelectorsData.LoginPageElementsAndroid.HomePageHeader, Timeout.Long);

            TakeScreenshot(PagesData.Screenshots.LogView);
            return this;
        }
        
    }
}