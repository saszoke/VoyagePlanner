﻿using System.ComponentModel;

namespace VoyagePlanner.Models
{
    public class Allowance
    {
        public int Id { get; set; }
        [DisplayName("Discount")]
        public string Name { get; set; }
        public int ReductionPercentage { get; set; }

        public List<Person> People { get; set; }
    }
}
