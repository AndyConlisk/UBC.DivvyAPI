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
    }
}
