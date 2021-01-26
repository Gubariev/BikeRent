using System;
using System.Collections;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using BikeRent.Models;
using System.Data.Entity;
using BikeRent.Dto;

namespace BikeRent.Controllers.Api
{
    public class CancelRentController : ApiController
    {
        private ApplicationDbContext _context;

        public CancelRentController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetBikes()
        {
            var bikesDto = _context.Bikes
                .Include(b => b.BikeType)
                .ToList()
                .Select(Mapper.Map<Bike, BikeDto>)
                .Where(b=>b.RentStatus==false);
            return Ok(bikesDto);
        }

        
        [HttpPut]
        public IHttpActionResult CancelRent(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var bikeInDb = _context.Bikes.SingleOrDefault(b => b.Id == id);
            if (bikeInDb==null)
            {
                return NotFound();
            }

            bikeInDb.RentStatus = true;

            _context.SaveChanges();
            return Ok();
        }



        
    }
}
