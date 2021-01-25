using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeRent.Dto
{
    public class BikeDto
    {

        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public BikeTypeDto BikeType { get; set; }

        public byte BikeTypeId { get; set; }
        public int RentCost { get; set; }
        public bool RentStatus { get; set; }
    }
}