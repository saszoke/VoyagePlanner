using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace VoyagePlanner.Models.DTOs
{
    public class VoyageDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string DestinationId { get; set; }

        //[Required(ErrorMessage = "Travel type is required.")]
        [TransportType]
        public string TravelType { get; set; }
    }
}
