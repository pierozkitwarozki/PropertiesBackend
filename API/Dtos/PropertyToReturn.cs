using System;

namespace API.Dtos
{
    public class PropertyToReturn
    {
        public int Id { get; set; }
        public int ExternalId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int Rooms { get; set; }
        public float Surface { get; set; }
        public int PriceM2 { get; set; }
        public int TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public int DistrictId { get; set; }
        public string DistrictName { get; set; }
    }
}