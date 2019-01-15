using Dapper;
using FlightManager.Module.Entities;
using FlightManager.Module.Ports;
using FlightManager.Repository.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace FlightManager.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IRepositoryConfig _config;

        #region Queries
        private const string _createFlightSql = @"insert into Flight(OriginAirportId, DestinationAirportId) 
                                                     values(@OriginAirportId, @DestinationAirportId); 
                                                     SELECT last_insert_rowid();";

        private const string _updateFlightSql = @"update  Flight
                                                     SET 
	                                                     OriginAirportId = @OriginAirportId, 
	                                                     DestinationAirportId = @DestinationAirportId
                                                     where FlightId = @FlightId";

        private const string _loadFlightsSql = @"select FlightId
	                                                    , OriginAirportId
	                                                    , DestinationAirportId 
                                                    from Flight ";

        private const string _getFlightByIdSql = @"select FlightId
	                                                    , OriginAirportId
	                                                    , DestinationAirportId
                                                    from Flight where flightid = @FlightId  ";

        private const string _loadAirportsSql = @"SELECT AirportId,	
                                                            AirportCode,
                                                            AirportName,
                                                            CityName,	
                                                            Latitude,	
                                                            Longitude
                                                            FROM Airport ap";

        private const string _getAirportByIdSql = @"SELECT AirportId,	
                                                            AirportCode,
                                                            AirportName,
                                                            CityName,	
                                                            Latitude,	
                                                            Longitude 
                                                            FROM Airport ap 
                                                            WHERE ap.AirportId = @AirportId";

        #endregion

        public FlightRepository(IRepositoryConfig config)
        {
            _config = config;
        }

        #region Flight
        public int? CreateFlight(Flight flight)
        {
            int? flightId = null;
            using (IDbConnection cx = new SQLiteConnection(_config.ConnectionString))
            {
                flightId = cx.ExecuteScalar<int>(_createFlightSql, new
                {
                    OriginAirportId = flight.OriginAirport.AirportId,
                    DestinationAirportId = flight.DestinationAirport.AirportId
                });
            }

            return flightId;
        }

        public List<Flight> LoadFlights()
        {
            using (var cx = new SQLiteConnection(_config.ConnectionString))
            {
                var flights = cx.Query<Flight>(_loadFlightsSql);
                foreach (var currentFlight in flights)
                {
                    currentFlight.DestinationAirport = GetAirportById(currentFlight.DestinationAirportId);
                    currentFlight.OriginAirport = GetAirportById(currentFlight.OriginAirportId);
                }
                return flights?.ToList();
            }
        }


        public Flight GetFlightById(int id)
        {
            using (var cx = new SQLiteConnection(_config.ConnectionString))
            {
                var flight = cx.Query<Flight>(_getFlightByIdSql, new { FlightId = id }).SingleOrDefault();
                flight.DestinationAirport = GetAirportById(flight.DestinationAirportId);
                flight.OriginAirport = GetAirportById(flight.OriginAirportId);
                return flight;
            }
        }

        public int UpdateFlight(Flight flight)
        {
            var numberOfRowsAffected = -1;
            using (var cx = new SQLiteConnection(_config.ConnectionString))
            {
                numberOfRowsAffected = cx.Execute(_updateFlightSql, new
                {
                    OriginAirportId = flight.OriginAirport.AirportId,
                    DestinationAirportId = flight.DestinationAirport.AirportId,
                    flight.FlightId
                });
            }

            return numberOfRowsAffected;
        }
        #endregion


        #region Airport
        public Airport GetAirportById(int id)
        {
            using (IDbConnection cx = new SQLiteConnection(_config.ConnectionString))
            {
                var airports = cx.Query<Airport>(_getAirportByIdSql, new { AirportId = id });
                return airports?.SingleOrDefault();
            }
        }

        public List<Airport> LoadAirports()
        {
            using (IDbConnection cx = new SQLiteConnection(_config.ConnectionString))
            {

                var airports = cx.Query<Airport>(_loadAirportsSql);
                return airports?.ToList();
            }
        }
        #endregion
    }
}
