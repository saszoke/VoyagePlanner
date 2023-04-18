﻿namespace VoyagePlanner.Models
{
    public class Extra
    {
        public int Id { get; set; }
        public Voyage Voyage { get; set; }
        public ExtraDetail ExtraDetail { get; set; }

        public int Quantity { get; set; } = 0;
    }
}
