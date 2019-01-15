using FlightManager.Module.Ports;
using FlightManager.Repository;
using FlightManager.Repository.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FlightManager.Tests.Repository
{
    [TestClass]
    public class FlightRepositoryTest
    {
        private IFlightRepository _flightRepository;

        [TestInitialize]
        public void Setup()
        {
            var config = new Mock<IRepositoryConfig>();
            config.Setup(p => p.ConnectionString).Returns(() => "Data Source=.\\myDb\\FlightManagerDB.db;Version=3");
            _flightRepository = new FlightRepository(config.Object);
        }

        [TestMethod]
        public void ShouldGetFlights()
        {
            var flights = _flightRepository.LoadFlights();
            Assert.IsNotNull(flights);
            Assert.IsTrue(flights.Count > 0);
        }

        [TestMethod]
        public void ShouldGetSingleFlight()
        {
            var flight = _flightRepository.GetFlightById(3);
            Assert.IsNotNull(flight);
            Assert.IsTrue(flight.FlightId == 3);
        }


        [TestMethod]
        public void ShouldCreateFlight()
        {
            var dummyFlight = FakeData.GetFlightBetweenCasaParis();
            var flightId = _flightRepository.CreateFlight(dummyFlight);
            Assert.IsNotNull(flightId);
            Assert.IsTrue(flightId != -1);
        }

        [TestMethod]
        public void ShouldUpdateFlight()
        {
            var dummyFlight = FakeData.GetFlightBetweenCasaParis();
            dummyFlight.FlightId = 2;
            var affectedRowsCount = _flightRepository.UpdateFlight(dummyFlight);
            Assert.IsTrue(affectedRowsCount == 1);
        }



        [TestMethod]
        public void ShouldGetAirports()
        {
            var airports = _flightRepository.LoadAirports();
            Assert.IsNotNull(airports);
            Assert.IsTrue(airports.Count > 0);
        }

        [TestMethod]
        public void ShouldGetSingleAirportById()
        {
            var airport = _flightRepository.GetAirportById(700);
            Assert.IsNotNull(airport);
        }


    }
}
