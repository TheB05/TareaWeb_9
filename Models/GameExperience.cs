using TareaWeb_9.Models;
using TareaWeb_9.Database;

namespace TareaWeb_9.Models{

    public class GameExperience
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime Date { get; set; } = DateTime.Now;
        public string ImageUrl { get; set; } = "";
        public int UserId { get; set; }
        public User user { get; set; }
    }
}