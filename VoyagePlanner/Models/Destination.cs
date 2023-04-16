using System.ComponentModel;

namespace VoyagePlanner.Models
{
    public class Destination
    {
        public int Id { get; set; }
        [DisplayName("Travel destination")]
        public string Name { get; set; }
        public Country Country { get; set; }
        public string Description { get; set; }
        public int DistancePlane { get; set; }
        public int DistanceRoad { get; set; }
        public bool FerryNeeded { get; set; }
    }
}
