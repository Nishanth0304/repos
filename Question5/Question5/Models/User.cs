namespace Question5.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Name { get; set; } = "";

        public string Email { get; set; } = "";

        public UserProfile? UserProfile { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}