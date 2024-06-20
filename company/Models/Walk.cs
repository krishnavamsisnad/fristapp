namespace company.Models
{
    public class Walk
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInkm { get; set; }
        public string? walkImageUrl { get; set; }

        public Guid DifficultyID { get; set; }
        public Guid RegionID { get; set; }
        //naviigation
        public Difficulty Difficulty { get; set; }
        public Rengion Rengion { get; set; }
    }
}
