using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeRent.Models
{
    public class Bike
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public BikeType BikeType { get; set; }
        public byte BikeTypeId { get; set; }
        public int RentCost { get; set; }
        public bool RentStatus { get; set; }
    }
}