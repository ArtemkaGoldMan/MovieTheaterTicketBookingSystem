namespace MovieTheaterTicketBookingSystem.Models
{
    public class Showtime
    {
        public int ShowtimeID { get; set; }
        public int EntertainmentID { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; } // e.g., "7:30 PM"
        public int AvailableSeats { get; set; }
        public string TheaterHall { get; set; }
    }
}
