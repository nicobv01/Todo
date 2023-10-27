using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.API.Models
{
    [Table("items")]
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public bool IsDone { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
