# XamarinUITestFramework

Test Framework using Xamarin.UITests and PageObject like approach. Used to create E2E tests for iOS and Droid applications.
------------------------------------------------------
-----------Qlczas Xamarin UI Test Framework----v1.0---
------------------------------------------------------
This Test Framework is using Xamarin.UITests and PageObject like approach.
It is used to create end-to-end test scenarios for iOS and Android applications.

From Original Xamarin UITest description:
-----------------------------------------
If the iOS or Android app being tested is included in the solution 
then open the Unit Tests window, right click Test Apps, select Add App Project
and select the app projects that should be tested.

The iOS project should have the Xamarin.TestCloud.Agent NuGet package
installed. To start the Test Cloud Agent the following code should be
added to the FinishedLaunching method of the AppDelegate:

#if ENABLE_TEST_CLOUD
Xamarin.Calabash.Start();
#endif
----------------------------------------

!Important!
1. Create your Test classes by inheriting from BaseTest.cs
2. Update paths in AppInitializer.cs before running your tests.
3. Page classes you create should be inheriting the SolidBrain.XUITFramework.Framework.BasePage.cs 
   or BasePageWithLogin.cs - if you would like to read credentials from embedded .txt file 
4. Also in the iOS project of your app, compiler in Debug should have ENABLE_TEST_CLOUD; added to defined Constants
