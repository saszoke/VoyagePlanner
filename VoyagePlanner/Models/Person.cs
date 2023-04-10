namespace VoyagePlanner.Models
{
    public class Person
    {
        public int Id { get; set; }

        public Voyage Voyage { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public DateTime DateOfBirth { get; set; }
        public List<Allowance> Allowances { get; set; }
    }
}
