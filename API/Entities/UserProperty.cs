namespace API.Entities
{
    public class UserProperty
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public Property Property { get; set; }
        public int PropertyId { get; set; }
    }
}