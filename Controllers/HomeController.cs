using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using BikeRent.Models;
using BikeRent.ViewModels;

namespace BikeRent.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
                _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var viewModel = new BikesViewModel()
            {
                BikeTypes = _context.BikeTypes.ToList(),
                Bikes = _context.Bikes.ToList()
            };
            
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddBike(BikesViewModel viewModel)
        {
            var newBike = new Bike
            {
                Name = viewModel.Bike.Name,
                BikeTypeId = viewModel.Bike.BikeTypeId,
                RentCost = viewModel.Bike.RentCost,
                RentStatus = true
            };
            _context.Bikes.Add(newBike);
            _context.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}