using System;
using UBC.DivvyAPI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UBC.DivvyAPI.Test
{
    [TestClass]
    public class TestAPI
    {
        [TestMethod]
        public void TestAsyncAPI()
        {
            var stations = DivvyAPI.GetStationsAsync().Result;            

            Assert.IsNotNull(stations);            
        }

        [TestMethod]
        public void TestSyncAPI()
        {
            var stations = DivvyAPI.GetStations();

            Assert.IsNotNull(stations);
        }

        [TestMethod]
        public void TestClosestStations()
        {
            var stations = DivvyAPI.GetClosestStations(5, 41.787806, -87.601247).Result;

            Assert.IsNotNull(stations);
            Assert.IsTrue(stations.Count == 5);
        }
    }
}
