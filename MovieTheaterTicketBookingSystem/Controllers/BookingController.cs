using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterTicketBookingSystem.Helpers;
using MovieTheaterTicketBookingSystem.Models;
using Microsoft.Extensions.Hosting;

namespace MovieTheaterTicketBookingSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly string _filePath;

        public BookingController(IWebHostEnvironment env)
        {
            _filePath = System.IO.Path.Combine(env.ContentRootPath, "Content", "bookings.json");
        }

        public ActionResult Index()
        {
            var bookings = JsonFileHandler<Booking>.LoadFromFile(_filePath);
            return View(bookings);
        }

        public ActionResult Create(int showtimeID, int movieID)
        {
            ViewBag.ShowtimeID = showtimeID;
            ViewBag.MovieID = movieID;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Booking booking)
        {
            var bookings = JsonFileHandler<Booking>.LoadFromFile(_filePath);
            booking.BookingID = bookings.Count + 1;
            bookings.Add(booking);
            JsonFileHandler<Booking>.SaveToFile(_filePath, bookings);
            return RedirectToAction("Index");
        }
    }
}
