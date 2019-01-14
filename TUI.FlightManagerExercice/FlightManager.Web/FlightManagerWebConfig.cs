using FlightManager.Repository.Interfaces;
using Microsoft.Extensions.Configuration;

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
