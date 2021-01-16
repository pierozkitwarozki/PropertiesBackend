using System;
using System.Collections.Generic;

namespace API.Entities
{
    public class Property
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
        public District District { get; set; }
        public ICollection<UserProperty> UserProperties { get; set; }
    }
}