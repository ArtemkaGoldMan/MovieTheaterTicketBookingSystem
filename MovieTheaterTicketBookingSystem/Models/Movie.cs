namespace MovieTheaterTicketBookingSystem.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; } // Duration in minutes
        public double Rating { get; set; } // Rating out of 10
    }
}
