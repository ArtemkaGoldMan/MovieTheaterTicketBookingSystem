namespace MovieTheaterTicketBookingSystem.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int EntertainmentID { get; set; }
        public int ShowtimeID { get; set; }
        public string CustomerName { get; set; }
        public int NumberOfTickets { get; set; }
    }
}
