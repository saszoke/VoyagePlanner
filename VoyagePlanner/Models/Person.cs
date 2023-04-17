using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VoyagePlanner.Models
{
    public class Person
    {
        public int Id { get; set; }

        public Voyage Voyage { get; set; }
        [Required]
        [DisplayName("First name")]
        public string Firstname { get; set; }
        [DisplayName("Last name")]

        public string Lastname { get; set; }
        [DisplayName("Date of birth")]

        public DateTime DateOfBirth { get; set; }

        [DisplayName("Discount")]

        public Allowance Allowance { get; set; }

        //public List<Allowance> Allowances { get; set; }
    }
}
