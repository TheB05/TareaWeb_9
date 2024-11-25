using TareaWeb_9.Models;
using TareaWeb_9.Database;

namespace TareaWeb_9.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public ICollection<GameExperience> gameexperiences { get; set; }
    }
}
