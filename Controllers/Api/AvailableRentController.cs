using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BikeRent.Dto;
using BikeRent.Models;

namespace BikeRent.Controllers.Api
{
    public class AvailableRentController : ApiController
    {
        private ApplicationDbContext _context;

        public AvailableRentController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetAvailableBikes()
        {
            var bikes = _context.Bikes.Include(b => b.BikeType).ToList().Select(Mapper.Map<Bike, BikeDto>);
            var bikesDto = new List<BikeDto>();
            foreach (var bike in bikes)
            {
                if (bike.RentStatus == true)
                {
                    bikesDto.Add(bike);
                }
            }
            return Ok(bikesDto);
        }

        [HttpPut]
        public IHttpActionResult RentBike(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var bikeInDb = _context.Bikes.SingleOrDefault(b => b.Id == id);
            if (bikeInDb == null)
            {
                return NotFound();
            }

            bikeInDb.RentStatus = false;

            _context.SaveChanges();
            return Ok();
        }



        [HttpDelete]
        public IHttpActionResult DeleteBike(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var bikeInDb = _context.Bikes.SingleOrDefault(b => b.Id == id);
            if (bikeInDb == null)
            {
                return NotFound();
            }

            _context.Bikes.Remove(bikeInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
