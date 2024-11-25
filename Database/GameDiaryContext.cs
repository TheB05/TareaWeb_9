using Microsoft.EntityFrameworkCore;
using TareaWeb_9.Models;
using TareaWeb_9.Database;

namespace TareaWeb_9.Database
{
    public class GameDiaryContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null;
        public DbSet<GameExperience> GameExperiences { get; set; } = null;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=GameDiary.db");
    }
}
