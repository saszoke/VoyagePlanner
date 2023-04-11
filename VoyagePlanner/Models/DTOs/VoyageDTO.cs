namespace VoyagePlanner.Models.DTOs
{
    public class VoyageDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string DestinationId { get; set; }

        public string TravelType { get; set; }
    }
}
