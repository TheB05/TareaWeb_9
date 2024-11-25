using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TareaWeb_9.Models;
using TareaWeb_9.Database;

namespace TareaWeb_9.Services{
    
    public class AuthService
    {
        private readonly GameDiaryContext _dbContext;

        public AuthService(GameDiaryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> RegisterAsync(string username, string email, string password)
        {
            // Validar si el usuario y el correo ya existen
            if (await _dbContext.Users.AnyAsync(u => u.Username == username || u.Email == email))
                throw new Exception("Username or email already exists.");

            var user = new User
            {
                Username = username,
                Email = email,
                Password = password
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User> LoginAsync(string usernameOrEmail, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);
            if (user == null || user.Password != password)
                throw new Exception("Invalid username/email or password.");

            return user;
        }

        public async Task<User> GetCurrentUserAsync()
        {
            // Obtener el usuario actual desde la sesión
            var userId = GetCurrentUserId();
            return await _dbContext.Users.FindAsync(userId);
        }

        private int GetCurrentUserId()
        {
            // Lógica para obtener el ID del usuario actual desde la sesión
            return 1; // Temporal, reemplazar con la lógica real
        }
    }
}