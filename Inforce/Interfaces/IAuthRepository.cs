using Inforce.Models;

namespace Inforce.Interfaces
{
    public interface IAuthRepository
    {
        public Task AddUser(string passwordHash, string login);
        public Task<User> GetUser(string login);
    }
}
