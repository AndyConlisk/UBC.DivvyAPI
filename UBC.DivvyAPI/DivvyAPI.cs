using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Device.Location;

using UBC.DivvyAPI.Models;

namespace UBC.DivvyAPI
{
    public static class DivvyAPI
    {
        private static readonly string DIVVYSTATIONENDPOINT = "http://www.divvybikes.com/stations/json";

        public static async Task<DivvyStations> GetStationsAsync()
        {
            return await GetStationsTask();
        }

        public static DivvyStations GetStations()
        {
            return GetStationsTask().Result;
        }

        private static async Task<DivvyStations> GetStationsTask()
        {
            var divvyStations = new DivvyStations();

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync(DIVVYSTATIONENDPOINT);
                if (response.IsSuccessStatusCode)
                {
                    divvyStations = JsonConvert.DeserializeObject<DivvyStations>(await response.Content.ReadAsStringAsync());
                }
            }

            return divvyStations;
        }

        public static async Task<List<Station>> GetClosestStations(int numberOfStations, double latitude, double longitude)
        {
            var nearest = new List<Station>();

            var divvyStations = await GetStationsTask();

            var coordinate = new GeoCoordinate(latitude, longitude);

            nearest = divvyStations.stationBeanList.Where(x => !x.testStation)
                .Select(x => new Station { id = x.id, stationName = x.stationName, location = new GeoCoordinate(x.latitude, x.longitude), availableBikes = x.availableBikes, availableDocks = x.availableDocks, statusValue = x.statusValue, statusKey = x.statusKey })
                .OrderBy(x => x.location.GetDistanceTo(coordinate))
                .Take(numberOfStations).ToList();

            return nearest;
        }
    }
}
