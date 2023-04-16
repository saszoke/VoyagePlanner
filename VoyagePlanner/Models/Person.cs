using System.ComponentModel.DataAnnotations;

namespace VoyagePlanner.Models
{
    public class Person
    {
        public int Id { get; set; }

        public Voyage Voyage { get; set; }
        [Required]
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Allowance Allowance { get; set; }

        //public List<Allowance> Allowances { get; set; }
    }
}
