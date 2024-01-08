using StarWars.Interface;
using StarWars.Models;
using StarWars.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Web_StarWars.Controllers
{
  public class HomeController : Controller
  { 
        public ActionResult Index()
        {
          return View();
        }

        public ActionResult Films()
        {
            IRepository<Film> filmsRepo = new Repository<Film>();
            var films = filmsRepo.GetEntities().ToList();
            return View(films);
        }
        public ActionResult Starships()
        {
            IRepository<Starship> filmsRepo = new Repository<Starship>();
            var starships = filmsRepo.GetEntities().ToList();
            return View(starships);
        }
        public ActionResult Persons()
        {
            IRepository<Person> filmsRepo = new Repository<Person>();
            var people = filmsRepo.GetEntities().ToList();
            return View(people);
        }
        public ActionResult Vehicles()
        {
            IRepository<Vehicle> filmsRepo = new Repository<Vehicle>();
            var starships = filmsRepo.GetEntities().ToList();
            return View(starships);
        }


        public ActionResult Planets()
        {
            IRepository<Planet> filmsRepo = new Repository<Planet>();
            var planets = filmsRepo.GetEntities().ToList();
            return View(planets);
        }

        public ActionResult Species()
        {
            IRepository<Specie> filmsRepo = new Repository<Specie>();
            var species = filmsRepo.GetEntities().ToList();
            return View(species);
        }

  }
}
