using System;
using NUnit.Framework;
using Xamarin.UITest;

namespace ExampleProjectName //TODO Update your Project name
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public abstract class BaseTest //TODO All your Project Test classes should inherit this class
    {
        protected readonly Platform Platform;
        protected IApp App;

        protected BaseTest(Platform platform)
        {
            Platform = platform;
        }

        [SetUp]
        public virtual void TestSetUp()
        {
            App = AppInitializer.StartApp(Platform);
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"--Test Start: {GetType().Name}--");
            App.Screenshot("Test initial screen");
        }

        [TearDown]
        public virtual void TestTearDown()
        {
            App.Screenshot("Test final screen");
            Console.WriteLine($"--Test Finished: {GetType().Name}--");
        }
    }
}