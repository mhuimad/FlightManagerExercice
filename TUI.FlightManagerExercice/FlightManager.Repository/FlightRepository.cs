using Dapper;
using FlightManager.Module.Entities;
using FlightManager.Module.Ports;
using FlightManager.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace FlightManager.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IRepositoryConfig _config;

        private readonly string _createFlightSql = @"insert into Flight(OriginAirportId, DestinationAirportId,DistanceInKM, AircraftFuelConsumption, Fuel) values(@○OriginAirportId, @DestinationAirportId,@DistanceInKM, @AircraftFuelConsumption, @Fuel)";



        public FlightRepository(IRepositoryConfig config)
        {
            _config = config;
        }

        public void CreateFlight(Flight flight)
        {
            using (IDbConnection cx = new SQLiteConnection(_config.ConnectionString))
            {
                var affectedRows = cx.Execute(_createFlightSql, new
                {
                    OriginAirportId = flight.OriginAirport.AirportId,
                    DestinationAirportId = flight.DestinationAirport.AirportId,
                    flight.DistanceInKM,
                    flight.AircraftFuelConsumption,
                    flight.Fuel
                });
            }
        }


    }
}
