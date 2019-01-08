using FlightManager.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManager.Web
{
    public class FlightManagerWebConfig : IRepositoryConfig
    {

        public FlightManagerWebConfig(IConfiguration config )
        {
            ConnectionString = config.GetConnectionString("Sqlite");
        }

        public string ConnectionString { get; }
    }
}
