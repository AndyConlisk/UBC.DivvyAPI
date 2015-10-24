using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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
    }
}
