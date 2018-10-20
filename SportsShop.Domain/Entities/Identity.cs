namespace SportsShop.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class Identity
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string Comments { get; set; }
    }
}
