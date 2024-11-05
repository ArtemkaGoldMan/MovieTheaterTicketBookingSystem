namespace MovieTheaterTicketBookingSystem.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public int Duration { get; set; } // Duration in minutes
        public List<string>? Showtimes { get; set; }
        public string? PictureURL { get; set; }
    }
}
