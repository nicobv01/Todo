using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.API.Models
{
    [Table("users")]
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
    }

    public class UserCredentials
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
