namespace MovieTheaterTicketBookingSystem.Models
{
    public class Theater
    {
        public int TheaterID { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; } // Total number of seats
        public string Location { get; set; } = "";
    }   
}