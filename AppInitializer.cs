using Xamarin.UITest;

namespace ExampleProjectName //TODO Update your Project name
{
    public class AppInitializer 
    {
        private const string DroidAppLocation = "../../../Project_Name/Droid/bin/Debug/...Signed.apk"; //TODO Update location to your .ApkFile 
        private const string IosAppLocation = "../../../Project_Name//iOS/bin/iPhoneSimulator/Debug/...iOS.app"; //TODO Update location to your .AppBundle
        private const string TestLogsLocation = "../../../Project_Name/testlogs"; //TODO Update location & add the folder to GitIgnore

        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .ApkFile(DroidAppLocation)
                    .EnableLocalScreenshots()
                    .LogDirectory(TestLogsLocation)
                    .StartApp(); //HACK Use .StartApp(AppDataMode.DoNotClear); if you want to keep the app Data after test run
            }

            return ConfigureApp
                .iOS
                .AppBundle(IosAppLocation)
                .DeviceIdentifier("") //TODO Provide your local Simulator UUID from Xcode to test on different iOS device
                .EnableLocalScreenshots()
                .LogDirectory(TestLogsLocation)
                .StartApp();
        }
    }
}