using Microsoft.EntityFrameworkCore;
using TareaWeb_9.Models;
using TareaWeb_9.Database;

namespace TareaWeb_9.Services
{
    public class ExperienceService
    {
        private readonly GameDiaryContext _dbContext;

        public ExperienceService(GameDiaryContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GameExperience> CreateExperienceAsync(int userId, string title, string description, DateTime date, string imageUrl)
        {
            var experience = new GameExperience
            {
                UserId = userId,
                Title = title,
                Description = description,
                Date = date,
                ImageUrl = imageUrl
            };

            await _dbContext.GameExperiences.AddAsync(experience);
            await _dbContext.SaveChangesAsync();

            return experience;
        }

        public async Task<List<GameExperience>> GetUserExperiencesAsync(int userId)
        {
            return await _dbContext.GameExperiences
                .Where(e => e.UserId == userId)
                .ToListAsync();
        }

        public async Task DeleteUserExperiencesAsync(int userId)
        {
            var experiences = await GetUserExperiencesAsync(userId);
            _dbContext.GameExperiences.RemoveRange(experiences);
            await _dbContext.SaveChangesAsync();
        }
    }
}
