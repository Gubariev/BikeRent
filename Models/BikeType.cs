using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeRent.Models
{
    public class BikeType
    {
        [Required]
        public byte Id { get; set; }
        public string Name { get; set; }
    }
}