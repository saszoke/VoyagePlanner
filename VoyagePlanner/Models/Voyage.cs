namespace VoyagePlanner.Models
{
    public class Voyage
    {
        public int Id { get; set; }
        public DateTime DateOfVoyage { get; set; }
        public Destination Destination { get; set; }
        public List<Person> Persons { get; set; }
        public List<Extra> Extras { get; set; }

        public TravelType TravelType { get; set; }
    }
}