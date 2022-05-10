using System.ComponentModel.DataAnnotations;

namespace mvc.vuejs.infrastructure.Entities
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
