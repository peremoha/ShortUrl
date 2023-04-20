using Inforce.Models;

namespace Inforce.Interfaces
{
    public interface IAuthService
    {
        public Task Register(RegisterRequest request);
        public Task<User> Login(LoginRequest loginRequest);
    }
}
