namespace VoyagePlanner.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DistancePlane { get; set; }
        public int DistanceRoad { get; set; }
        public bool FerryNeeded { get; set; }
    }
}
