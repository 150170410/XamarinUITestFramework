using System;
using NUnit.Framework;
using QlczasXamarinUITestFramework.Framework.Authentication;

namespace ExampleProjectName.UITests.TestData
{
    public class SelectorsData
    {
                
        //TODO Add your selectors to this class, the below ones are just examples

        public static class LoginWebView
        {
            public const int LoginWebViewIndex = 0;
            public const int SignInButtonIndex = 0;
            public const string LoginWebTextField = "CredUserID";
            public const string PasswordWebTextField = "CredPassword";
            public const string SignInButton = "SignButton";
            public const int EmptyCredentialsAlertIndex = 0;
        }

        public static class LoginPageElementsIos
        {
            public const string LoginButtonName = "Press to Login";
            public const string HomePageHeader = "Welcome to Homepage";
        }

        public static class LoginPageElementsAndroid
        {
            public const string LoginButtonName = "PRESS TO LOGIN";
            public const string HomePageHeader = "WELCOME TO HOMEPAGE";
        }
        
        public static class Alerts
        {
            public const string EmptyCredentials = "To sign in, start by entering a user ID.";
        }

}