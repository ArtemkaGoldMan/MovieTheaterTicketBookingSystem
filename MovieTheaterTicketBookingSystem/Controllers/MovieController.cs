using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieTheaterTicketBookingSystem.Helpers;
using MovieTheaterTicketBookingSystem.Models;
using Microsoft.Extensions.Hosting;

namespace MovieTheaterTicketBookingSystem.Controllers
{
    public class MovieController : Controller
    {
        private readonly string _filePath;

        public MovieController(IWebHostEnvironment env)
        {
            _filePath = System.IO.Path.Combine(env.ContentRootPath, "Content", "movies.json");
        }

        public IActionResult Index()
        {
            var movies = JsonFileHandler<Movie>.LoadFromFile(_filePath);
            return View(movies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            var movies = JsonFileHandler<Movie>.LoadFromFile(_filePath);
            movie.ID = movies.Count + 1;
            movies.Add(movie);
            JsonFileHandler<Movie>.SaveToFile(_filePath, movies);
            return RedirectToAction("Index");
        }

        public IActionResult Get(int id)
        {
            var movies = JsonFileHandler<Movie>.LoadFromFile(_filePath);
            var movie = movies.Find(m => m.ID == id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            var movies = JsonFileHandler<Movie>.LoadFromFile(_filePath);
            var index = movies.FindIndex(m => m.ID == movie.ID);
            if (index != -1)
            {
                movies[index] = movie;
                JsonFileHandler<Movie>.SaveToFile(_filePath, movies);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var movies = JsonFileHandler<Movie>.LoadFromFile(_filePath);
            var movie = movies.Find(m => m.ID == id);
            if (movie != null)
            {
                movies.Remove(movie);
                JsonFileHandler<Movie>.SaveToFile(_filePath, movies);
            }
            return RedirectToAction("Index");
        }
    }
}
