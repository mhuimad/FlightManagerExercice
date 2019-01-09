using Dapper;
using FlightManager.Module.Entities;
using FlightManager.Module.Ports;
using FlightManager.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace FlightManager.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IRepositoryConfig _config;

        private readonly string _createFlightSql = @"insert into Flight(OriginAirportId, DestinationAirportId,DistanceInKM, AircraftFuelConsumption, Fuel) 
                                                     values(@OriginAirportId, @DestinationAirportId,@DistanceInKM, @AircraftFuelConsumption, @Fuel); 
                                                     SELECT last_insert_rowid();";

        private readonly string _updateFlightSql = @"update  Flight
                                                     SET 
	                                                     OriginAirportId = @OriginAirportId, 
	                                                     DestinationAirportId = @DestinationAirportId,
	                                                     DistanceInKM = @DistanceInKM,
	                                                     AircraftFuelConsumption = @AircraftFuelConsumption,
	                                                     Fuel   = @Fuel
                                                     where FlightId = @FlightId";

        private readonly string _loadFlightsSql = @"select FlightId
	                                                    , OriginAirportId
	                                                    , DestinationAirportId
	                                                    , DistanceInKM
	                                                    , AircraftFuelConsumption
	                                                    , Fuel  
                                                    from Flight ";

        private readonly string _getFlightByIdSql = @"select FlightId
	                                                    , OriginAirportId
	                                                    , DestinationAirportId
	                                                    , DistanceInKM
	                                                    , AircraftFuelConsumption
	                                                    , Fuel  
                                                    from Flight where flightid = @FlightId  ";


        public FlightRepository(IRepositoryConfig config)
        {
            _config = config;
        }

        public int? CreateFlight(Flight flight)
        {
            int? flightId = null;
            using (IDbConnection cx = new SQLiteConnection(_config.ConnectionString))
            {
                flightId = cx.ExecuteScalar<int>(_createFlightSql, new
                {
                    OriginAirportId = flight.OriginAirport.AirportId,
                    DestinationAirportId = flight.DestinationAirport.AirportId,
                    flight.DistanceInKM,
                    flight.AircraftFuelConsumption,
                    flight.Fuel
                });
            }

            return flightId;
        }

        public List<Flight> LoadFlights()
        {
            using (IDbConnection cx = new SQLiteConnection(_config.ConnectionString))
            {
                var flights = cx.Query<Flight>(_loadFlightsSql);
                return flights?.ToList();
            }
        }


        public Flight GetFlightById(int id)
        {
            using (IDbConnection cx = new SQLiteConnection(_config.ConnectionString))
            {
                var flights = cx.Query<Flight>(_getFlightByIdSql, new { FlightId = id });
                return flights?.SingleOrDefault();
            }
        }

        public void UpdateFlight(Flight flight)
        {
            using (var cx = new SQLiteConnection(_config.ConnectionString))
            {
                cx.Execute(_updateFlightSql, new
                {
                    OriginAirportId = flight.OriginAirport.AirportId,
                    DestinationAirportId = flight.DestinationAirport.AirportId,
                    flight.DistanceInKM,
                    flight.AircraftFuelConsumption,
                    flight.Fuel,
                    flight.FlightId
                });
            }
        }
    }
}
