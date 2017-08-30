using System;

namespace QlczasXamarinUITestFramework.Framework.Authentication
{
    public class CredentialsSourceException : Exception
    {
        public CredentialsSourceException()
        {
        }
        
        public CredentialsSourceException(string message) : base(message)
        {
        }

        public CredentialsSourceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}