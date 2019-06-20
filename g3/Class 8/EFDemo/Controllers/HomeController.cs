using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly CinemaDbContext _dbContext;

        public HomeController(CinemaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            //This should be part of the Repository in Data Layer
            //var cinema = new Cinema
            //{
            //    Name = "Cineplexx"
            //};

            //_dbContext.Cinemas.Add(cinema);
            //_dbContext.SaveChanges();

            //var hall1 = new Hall
            //{
            //    Name = "Hall 1",
            //    NumberOfSeats = 100,
            //    Cinema = _dbContext.Cinemas.FirstOrDefault(x => x.Name == "Cineplexx")
            //};

            //var hall2 = new Hall
            //{
            //    Name = "Hall 2",
            //    NumberOfSeats = 50,
            //    Cinema = _dbContext.Cinemas.FirstOrDefault(x => x.Name == "Cineplexx")
            //};

            //var allHalls = new List<Hall>() {hall1, hall2};
            //_dbContext.Halls.AddRange(allHalls);
            //_dbContext.SaveChanges();

            //var movie = new Movie()
            //{
            //    Name = "Avangers"
            //};

            //_dbContext.Movies.Add(movie);
            //_dbContext.SaveChanges();

            //var movieHall = new MovieHall()
            //{
            //    Hall = _dbContext.Halls.FirstOrDefault(x => x.Name == "Hall 1"),
            //    Movie = _dbContext.Movies.FirstOrDefault(x => x.Name == "Avangers")
            //};

            //var movieHall2 = new MovieHall()
            //{
            //    Hall = _dbContext.Halls.FirstOrDefault(x => x.Name == "Hall 2"),
            //    Movie = _dbContext.Movies.FirstOrDefault(x => x.Name == "Avangers")
            //};

            //_dbContext.MovieHalls.AddRange(new List<MovieHall>() {movieHall, movieHall2});
            //_dbContext.SaveChanges();

            var allCinemas = _dbContext.Cinemas
                .Include(x => x.Halls)
                .ThenInclude(x => x.Cinema)
                .Include(x => x.Halls)
                .ThenInclude(x => x.MovieHalls)
                .ThenInclude(x => x.Movie)
                .ToList();

            return View(allCinemas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
