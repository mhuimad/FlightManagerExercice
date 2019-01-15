using FlightManager.Module;
using FlightManager.Module.Entities;
using FlightManager.Module.Ports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace FlightManager.Tests.Module
{
    [TestClass]
    public class FlightModuleTest
    {
        private Mock<IFlightRepository> _flightRepoMoq;


        [TestInitialize]
        public void Init()
        {
            _flightRepoMoq = new Mock<IFlightRepository>();
        }


        [TestMethod]
        public void ShouldGetAirports()
        {
            var expectedAirportCount = 30;
            var dummyAirports = FakeData.GenerateDummyAirport(expectedAirportCount);
            _flightRepoMoq.Setup(s => s.LoadAirports()).Returns(() => dummyAirports);
            var module = new FlightModule(_flightRepoMoq.Object);
            var airports = module.LoadAirports();
            Assert.AreEqual(expectedAirportCount, airports.Count);
        }

        [TestMethod]
        public void ShouldGetSingleAirport()
        {
            var expectedAirportCount = 1;
            var dummyAirports = FakeData.GenerateDummyAirport(expectedAirportCount);
            _flightRepoMoq.Setup(s => s.GetAirportById(It.IsAny<int>())).Returns(() => dummyAirports.FirstOrDefault());
            var module = new FlightModule(_flightRepoMoq.Object);
            var airport = module.GetAirportById(It.IsAny<int>());
            Assert.IsNotNull(airport);
        }



        [TestMethod]
        public void ShouldGetFlights()
        {
            var expectedFlightCount = 30;
            var dummyFlights = FakeData.GenerateDummyFlight(expectedFlightCount);
            _flightRepoMoq.Setup(s => s.LoadFlights()).Returns(() => dummyFlights);
            var module = new FlightModule(_flightRepoMoq.Object);
            var flights = module.LoadFlights();
            Assert.AreEqual(expectedFlightCount, flights.Count);
        }

        [TestMethod]
        public void ShouldGetSingleFlight()
        {
            var dummyFlight = FakeData.GetFlightBetweenCasaParis();
            _flightRepoMoq.Setup(s => s.GetFlightById(It.IsAny<int>())).Returns(() => dummyFlight);
            var module = new FlightModule(_flightRepoMoq.Object);
            var flight = module.GetFlightById(It.IsAny<int>());
            Assert.IsNotNull(flight);
        }


        [TestMethod]
        public void ShouldCalculateDistanceBetwenTwoAirportsWhenGetFlight()
        {
            var expectedDistanceInKm = 1933;
            var dummyFlightBetweenCasaParis = FakeData.GetFlightBetweenCasaParis();
            _flightRepoMoq.Setup(s => s.LoadFlights()).Returns(() => new List<Flight>() { dummyFlightBetweenCasaParis });
            var module = new FlightModule(_flightRepoMoq.Object);
            var result = module.LoadFlights().SingleOrDefault();
            Assert.AreEqual(expectedDistanceInKm, result.DistanceInKM);
        }


        [TestMethod]
        public void ShouldCalculateFuelBetwenTwoAirportsWhenGetFlight()
        {
            var expectedAmountOfFuel = 46808.6;
            var dummyFlightBetweenCasaParis = FakeData.GetFlightBetweenCasaParis();
            _flightRepoMoq.Setup(s => s.LoadFlights()).Returns(() => new List<Flight>() { dummyFlightBetweenCasaParis });
            var module = new FlightModule(_flightRepoMoq.Object);
            var result = module.LoadFlights().SingleOrDefault();
            Assert.AreEqual(expectedAmountOfFuel, result.AmountOfFuel);
        }


        [TestMethod]
        public void ShouldCalculateDistanceBetwenTwoAirportsWhenCreateFlight()
        {
            var expectedDistanceInKm = 1933;
            var dummyFlightBetweenCasaParis = FakeData.GetFlightBetweenCasaParis();
            _flightRepoMoq.Setup(s => s.CreateFlight(dummyFlightBetweenCasaParis)).Returns(() => It.IsAny<int>());
            var module = new FlightModule(_flightRepoMoq.Object);
            var result = module.CreateFlight(dummyFlightBetweenCasaParis);
            Assert.AreEqual(expectedDistanceInKm, result.DistanceInKM);
        }


        [TestMethod]
        public void ShouldCalculateFuelBetwenTwoAirportsWhenCreateFlight()
        {
            var expectedQuantityOfFuel = 46808.6;
            var dummyFlightBetweenCasaParis = FakeData.GetFlightBetweenCasaParis();
            _flightRepoMoq.Setup(s => s.CreateFlight(dummyFlightBetweenCasaParis)).Returns(() => It.IsAny<int>());
            var module = new FlightModule(_flightRepoMoq.Object);
            var result = module.CreateFlight(dummyFlightBetweenCasaParis);
            Assert.AreEqual(expectedQuantityOfFuel, result.AmountOfFuel);
        }


        [TestMethod]
        public void ShouldCalculateDistanceBetwenTwoAirportsWhenUpdateFlight()
        {
            var expectedDistanceInKm = 1933;
            var dummyFlightBetweenCasaParis = FakeData.GetFlightBetweenCasaParis();
            _flightRepoMoq.Setup(s => s.UpdateFlight(dummyFlightBetweenCasaParis)).Returns(() => It.IsAny<int>());
            var module = new FlightModule(_flightRepoMoq.Object);
            var result = module.UpdateFlight(dummyFlightBetweenCasaParis);
            Assert.AreEqual(expectedDistanceInKm, result.DistanceInKM);
        }


        [TestMethod]
        public void ShouldCalculateFuelBetwenTwoAirportsWhenUpdateFlight()
        {
            var expectedQuantityOfFuel = 46808.6;
            var dummyFlightBetweenCasaParis = FakeData.GetFlightBetweenCasaParis();
            _flightRepoMoq.Setup(s => s.UpdateFlight(dummyFlightBetweenCasaParis)).Returns(() => 1);
            var module = new FlightModule(_flightRepoMoq.Object);
            var result = module.UpdateFlight(dummyFlightBetweenCasaParis);
            Assert.AreEqual(expectedQuantityOfFuel, result.AmountOfFuel);
        }

    }
}
