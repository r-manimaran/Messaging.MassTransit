namespace Movies.Api.Models
{
    public class Movie
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Genre { get; set; }
        public required int YearReleased { get; set; }
    }
}
