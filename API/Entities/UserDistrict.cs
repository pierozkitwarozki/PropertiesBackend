namespace API.Entities
{
    public class UserDistrict
    {
        public AppUser User { get; set; }
        public int UserId { get; set; }
        public District District { get; set; }
        public int DistrctId { get; set; }
    }
}