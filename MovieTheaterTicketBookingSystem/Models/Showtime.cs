namespace MovieTheaterTicketBookingSystem.Models
{
    public class Showtime
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public DateTime DateTime { get; set; }
        public int AvailableSeats { get; set; }
        public int Price { get; set; }
        public string? TheaterHall { get; set; } 
    }

}
