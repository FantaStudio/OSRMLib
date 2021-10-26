﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OSRMLib.Helpers
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public Location() { }

        public Location(double latitude,double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
