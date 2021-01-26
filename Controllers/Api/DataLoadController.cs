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
    public class DataLoadController : ApiController
    {
        private ApplicationDbContext _context;

        public DataLoadController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        [Route("api/DataLoad/yourrents")]
        public IHttpActionResult GetBikes()
        {
            var bikes = _context.Bikes.Include(b => b.BikeType).ToList().Select(Mapper.Map<Bike, BikeDto>);
            var bikesDto = new List<BikeDto>();
            foreach (var bike in bikes)
            {
                if (bike.RentStatus==false)
                {
                    bikesDto.Add(bike);
                }
            }
            return Ok(bikesDto);
        }

        [HttpGet]
        [Route("api/DataLoad/availablerent")]
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
        [Route("api/dataload/cancelrent")]
        public IHttpActionResult UpdateBikeRent(int id)
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

            bikeInDb.RentStatus = false;

            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("api/dataload/rentbike")]
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

            bikeInDb.RentStatus = true;

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
