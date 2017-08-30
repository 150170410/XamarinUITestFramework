using System;
using System.IO;
using System.Reflection;

namespace QlczasXamarinUITestFramework.Framework.Authentication
{
    public class EmbeddedResourceFileCredentialsProvider : ICredentialsProvider
    {
        private readonly string _pathToResource;
        private readonly Assembly _callingAssembly;

        public EmbeddedResourceFileCredentialsProvider(string pathToResource, Assembly callingAssembly)
        {
            _pathToResource = pathToResource ?? throw new ArgumentNullException(nameof(pathToResource));
            _callingAssembly = callingAssembly ?? throw new ArgumentNullException(nameof(callingAssembly));
        }

        public Credentials GetCredentials()
        {
            using (var stream = _callingAssembly.GetManifestResourceStream(_pathToResource))
            {
                if (stream == null)
                    throw new CredentialsSourceException($"Cannot find credentials file {_pathToResource} inside assembly");
                    
                using (var reader = new StreamReader(stream))
                {
                    return ParseFileContent(reader);
                }
            }
        }

        private static Credentials ParseFileContent(TextReader reader)
        {
            var splitFileContent = reader.ReadToEnd().Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);

            AssertFileContent(splitFileContent);

            return new Credentials
            {
                Username = splitFileContent[0],
                Password = splitFileContent[1]
            };
        }

        private static void AssertFileContent(string[] splitFileContent)
        {
            if (splitFileContent.Length != 2)
                throw new CredentialsSourceException("Bad credentials file format");
        }
    }
}