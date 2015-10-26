using System.Collections.Generic;

namespace UBC.DivvyAPI.Models
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class DivvyStations
    {
        public string executionTime { get; set; }
        public List<StationBean> stationBeanList { get; set; }
    }

    public class StationBean
    {
        public int id { get; set; }
        public string stationName { get; set; }
        public int availableDocks { get; set; }
        public int totalDocks { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string statusValue { get; set; }
        public int statusKey { get; set; }
        public int availableBikes { get; set; }
        public string stAddress1 { get; set; }
        public string stAddress2 { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string location { get; set; }
        public string altitude { get; set; }
        public bool testStation { get; set; }
        public object lastCommunicationTime { get; set; }
        public string landMark { get; set; }
    }
}
