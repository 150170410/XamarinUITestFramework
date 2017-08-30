using QlczasXamarinUITestFramework.Framework.Authentication;
using Xamarin.UITest;

namespace QlczasXamarinUITestFramework.Framework
{
    public abstract class BasePageWithLogin : BasePage
    {
        private readonly ICredentialsProvider _credentialsProvider;
        protected Credentials Credentials;

        protected BasePageWithLogin(IApp app, ICredentialsProvider credentialsProvider) : base(app)
        {
            _credentialsProvider = credentialsProvider;
        }
        
        public BasePageWithLogin GetCredentialsForLogin()
        {
            Credentials = _credentialsProvider.GetCredentials();
            return this;
        }
    }
}