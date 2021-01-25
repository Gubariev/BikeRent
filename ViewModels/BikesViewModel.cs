using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BikeRent.Models;

namespace BikeRent.ViewModels
{
    public class BikesViewModel
    {
        public List<Bike> Bikes { get; set; }
        public Bike Bike { get; set; }

        public List<BikeType> BikeTypes { get; set; }
    }
}