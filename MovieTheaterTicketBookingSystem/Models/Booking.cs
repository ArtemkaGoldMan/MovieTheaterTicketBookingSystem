namespace MovieTheaterTicketBookingSystem.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int MovieID { get; set; }
        public int ShowtimeID { get; set; }
        public int SeatsBooked { get; set; }
        public string? CustomerName { get; set; }
        public int NumberOfTickets { get; set; }
        public decimal TotalPrice { get; set; }
    }

}
