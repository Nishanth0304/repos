namespace Question5.Models
{
    public class UserProfile
    {
        public int ProfileId { get; set; }

        public string Address { get; set; } = "";

        public string MobileNumber { get; set; } = "";

        public int UserId { get; set; }

        public User? User { get; set; }
    }
}