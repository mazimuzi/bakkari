using System.ComponentModel.DataAnnotations;

namespace bakkari.Models
{
    public class User
    {
        public long Id { get; set; }
        [MinLength(3)]
        [MaxLength(30)]
        public string UserName { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }

        public string Salt { get; set; }
        [MaxLength(100)]
        [EmailAddress]
        public string? Email { get; set; }
        [MaxLength(100)]
        public string? FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool deleted { get; set; }
    }
    public class UserDTO
    {
        [MinLength(3)]
        [MaxLength(30)]

        public string UserName { get; set; }
        [MaxLength(100)]
        [EmailAddress]

        public string? Email { get; set; }
        [MaxLength(100)]

        public string? FirstName { get; set; }
        [MaxLength(100)]

        public string LastName { get; set; }

        public DateTime? JoinDate { get; set; }

        public DateTime? LastLogin { get; set; }
    }
}
