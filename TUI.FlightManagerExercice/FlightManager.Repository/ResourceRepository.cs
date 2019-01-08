using Dapper;
using FlightManager.Module.Entities;
using FlightManager.Module.Ports;
using FlightManager.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace FlightManager.Repository
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly IRepositoryConfig _config;

        private readonly string _loadAirportsSql = @"SELECT AirportId,	
                                                            AirportCode,
                                                            AirportName,
                                                            CityName,	
                                                            Latitude,	
                                                            Longitude,	
                                                            Geometry 
                                                            FROM Airport ap";

        private readonly string _getAirportByIdSql = @"SELECT AirportId,	
                                                            AirportCode,
                                                            AirportName,
                                                            CityName,	
                                                            Latitude,	
                                                            Longitude,	
                                                            Geometry 
                                                            FROM Airport ap 
                                                            WHERE ap.AirportId = @AirportId";

        public ResourceRepository(IRepositoryConfig config)
        {
            _config = config;
        }

        public Airport GetAirportById(int id)
        {
            using (IDbConnection cx = new SQLiteConnection(_config.ConnectionString))
            {
                var airports = cx.Query<Airport>(_getAirportByIdSql, id);
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



    }
}
