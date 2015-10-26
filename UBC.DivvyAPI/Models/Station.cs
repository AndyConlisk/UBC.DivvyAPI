using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

namespace UBC.DivvyAPI.Models
{
    public class Station
    {
        public int id { get; set; }

        public string stationName { get; set; }

        public GeoCoordinate location { get; set; }

        public int availableBikes { get; set; }

        public int availableDocks { get; set; }

        public string statusValue { get; set; }

        public int statusKey { get; set; }
    }
}
