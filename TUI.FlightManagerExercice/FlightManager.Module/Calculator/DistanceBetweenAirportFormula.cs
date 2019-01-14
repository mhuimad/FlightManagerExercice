using FlightManager.Module.Entities;
using FlightManager.Module.Interfaces;
using GeoCoordinatePortable;
using System;

namespace FlightManager.Module.Calculator
{
    class DistanceBetweenAirportFormula : IFormula
    {
        public Flight Apply(Flight flight)
        {

            flight.DistanceInKM = GetDistanceFromLatitudeLongitudeInKm(flight.OriginAirport.Latitude,
                                                                    flight.OriginAirport.Longitude,
                                                                    flight.DestinationAirport.Latitude,
                                                                    flight.DestinationAirport.Longitude);


            return flight;
        }

        private double GetDistanceFromLatitudeLongitudeInKm(double latitude1, double longitude1, double latitude2, double longitude2)
        {
            var point1 = new GeoCoordinate(latitude1, longitude1);
            var point2 = new GeoCoordinate(latitude2, longitude2);
            return Math.Round(point1.GetDistanceTo(point2) / 1000);
        }



    }
}
