using FlightManager.Module.Entities;
using System;
using System.Collections.Generic;

namespace FlightManager.Tests
{
    internal class FakeData
    {
        internal static List<Flight> GenerateDummyFlight(int expectedFlightCount)
        {
            var dummyFlights = new List<Flight>();
            var random = new Random();
            for (int i = 0; i < expectedFlightCount; i++)
            {
                var flight = new Flight()
                {
                    FlightId = random.Next(0, 1000),
                    OriginAirport = GetDummyCasaAiport(),
                    DestinationAirport = GetDummyParisAiport()
                };
                dummyFlights.Add(flight);
            }
            return dummyFlights;
        }

        internal static List<Airport> GenerateDummyAirport(int count)
        {
            var dummyAirports = new List<Airport>();
            var random = new Random();
            for (int i = 0; i < count; i++)
            {
                var airport = new Airport()
                {
                    AirportId = random.Next(1, 1000),
                    AirportCode = "FAKE",
                    AirportName = "FAKESKY",
                    CityName = "FakeCity",
                    Latitude = 23234.887,
                    Longitude = 23341.98
                };
                dummyAirports.Add(airport);
            }
            return dummyAirports;
        }


        internal static Airport GetDummyCasaAiport()
        {
            var random = new Random();
            return  new Airport()
            {
                AirportId = random.Next(1, 566),
                AirportCode = "GMMN",
                AirportName = "Mohammed V Intl",
                CityName = "Casablanca",
                Latitude = 33.3641666666667,
                Longitude = -7.58166666666667
            };
        }


        internal static Airport GetDummyParisAiport()
        {
            var random = new Random();
            return  new Airport()
            {
                AirportId = random.Next(1, 566),
                AirportCode = "LFPG",
                AirportName = "Charles-De-Gaulle",
                CityName = "Paris",
                Latitude = 49.0097222222222,
                Longitude = 2.54777777777778
            };
        }

        internal static Flight GetFlightBetweenCasaParis()
        {
            var random = new Random();
            var dummyFlight = new Flight()
            {
                FlightId = random.Next(1, 500),
                OriginAirport = GetDummyCasaAiport(),
                DestinationAirport = GetDummyParisAiport()
            };
            return dummyFlight;
        }
    }
}