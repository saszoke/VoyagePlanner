using System.ComponentModel;

namespace VoyagePlanner.Models
{
    public class TravelType
    {
        public int Id { get; set; }
        [DisplayName("Traveling by")]
        public string Name { get; set; }
        public decimal CostPerKilometre { get; set; }
    }
}
