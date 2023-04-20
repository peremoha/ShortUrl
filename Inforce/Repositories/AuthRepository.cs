using Inforce.Interfaces;
using Inforce.Models;
using Microsoft.EntityFrameworkCore;

namespace Inforce.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ShortenerContext _context;

        public AuthRepository(ShortenerContext context)
        {
            _context = context;
        }

        public async Task AddUser(string  passwordHash, string login)
        {
            var user = new User { Login = login, PasswordHash = passwordHash, RoleId = 2};
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUser(string login)
        {
            var user = await _context.Users.Include(opt => opt.Role).FirstOrDefaultAsync(x => x.Login == login);
            return user;
        }
    }
}
