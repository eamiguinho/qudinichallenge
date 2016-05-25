using QudiniChallenge.Contracts.DataServices;

namespace QudiniChallenge.DataServices.Implementation
{
    public class LoginCredentials : ILoginCredentials
    {
        public string Username { get { return "codetest1"; } }
        public string Password { get { return "codetest100"; } }
    }
}