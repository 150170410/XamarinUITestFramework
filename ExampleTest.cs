using System;
using NUnit.Framework;
using QlczasXamarinUITestFramework.Framework.Authentication;
using ExampleProjectName.UITests.Pages;

namespace ExampleProjectName.UITests.TestCases
{
    public class LoginToHomePageTests : BaseTest
    {
        private readonly ICredentialsProvider _credentialsProvider;

        public LoginToHomePageTests(Platform platform) : base(platform)
        {
			_credentialsProvider = new EmbeddedResourceFileCredentialsProvider
								  (TestConfiguration.PathToCredentialsResource, TestConfiguration.CallingAssembly);
        }

        [SetUp]
        public virtual void LoginToHomePageTestSetup()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine($"--Settings for LoginToHomePageTests are set--");
            Console.WriteLine("----------------------------------------------");
            new LoginToHomePage(App, _credentialsProvider)
                .WaitForLoginPage(Platform);
        }
        
        [Test]
        public void LoginUnsuccesfulWithEmptyDataTest()
        {
            new LoginToHomePage(App, _credentialsProvider)
                .PressLoginButton(Platform)
                .WaitForLoginWebView()
                .PressSignInButton()
                .AssertEmptyLoginAlertVisible(Platform);
        }

        [Test]
        public void LoginSuccesfulTest()
        {
            new LoginToHomePage(App, _credentialsProvider)
                .PressLoginButton(Platform)
                .WaitForLoginWebView()
                .EnterUserCredentials()
                .WaitForHomePage(Platform);
        }
    }
}