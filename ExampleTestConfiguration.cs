using System.Reflection;

namespace ExampleProjectName
{
    public class TestConfiguration
    {
        public const string PathToCredentialsResource = "ExampleProjectName.UITests.TestData.Credentials.txt"; //TODO change to correct path
        public static Assembly CallingAssembly => Assembly.GetExecutingAssembly();
    }

}