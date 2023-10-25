using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.API.Models
{
    [Table("tasks")]
    public class Item
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsDone { get; set; }
        public int UserId { get; set; }
    }
}
