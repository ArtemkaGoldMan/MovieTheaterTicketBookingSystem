using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterTicketBookingSystem.Helpers;
using MovieTheaterTicketBookingSystem.Models;
using Microsoft.Extensions.Hosting;

namespace MovieTheaterTicketBookingSystem.Controllers
{
    public class ShowtimeController : Controller
    {
        private readonly string _showtimesFilePath;
        private readonly string _moviesFilePath;

        public ShowtimeController(IWebHostEnvironment env)
        {
            _showtimesFilePath = System.IO.Path.Combine(env.ContentRootPath, "Content", "showtimes.json");
            _moviesFilePath = System.IO.Path.Combine(env.ContentRootPath, "Content", "movies.json");
        }

        public ActionResult Index()
        {
            var showtimes = JsonFileHandler<Showtime>.LoadFromFile(_showtimesFilePath);
            return View(showtimes);
        }

        public ActionResult Create()
        {
            var movies = JsonFileHandler<Movie>.LoadFromFile(_moviesFilePath);
            ViewBag.Movies = movies; // Pass the list of movies to the view
            return View();
        }

        [HttpPost]
        public ActionResult Create(Showtime showtime)
        {
            var showtimes = JsonFileHandler<Showtime>.LoadFromFile(_showtimesFilePath);
            showtime.ID = showtimes.Count + 1;
            showtimes.Add(showtime);
            JsonFileHandler<Showtime>.SaveToFile(_showtimesFilePath, showtimes);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var showtimes = JsonFileHandler<Showtime>.LoadFromFile(_showtimesFilePath);
            var showtime = showtimes.Find(s => s.ID == id);
            var movies = JsonFileHandler<Movie>.LoadFromFile(_moviesFilePath);
            ViewBag.Movies = movies; // Pass the list of movies to the view
            return View(showtime);
        }

        [HttpPost]
        public ActionResult Edit(Showtime showtime)
        {
            var showtimes = JsonFileHandler<Showtime>.LoadFromFile(_showtimesFilePath);
            var index = showtimes.FindIndex(s => s.ID == showtime.ID);
            if (index != -1)
            {
                showtimes[index] = showtime;
                JsonFileHandler<Showtime>.SaveToFile(_showtimesFilePath, showtimes);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var showtimes = JsonFileHandler<Showtime>.LoadFromFile(_showtimesFilePath);
            var showtime = showtimes.Find(s => s.ID == id);
            if (showtime != null)
            {
                showtimes.Remove(showtime);
                JsonFileHandler<Showtime>.SaveToFile(_showtimesFilePath, showtimes);
            }
            return RedirectToAction("Index");
        }
    }
}
