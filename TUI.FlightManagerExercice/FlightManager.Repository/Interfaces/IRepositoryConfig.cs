using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManager.Repository.Interfaces
{
    public interface IRepositoryConfig
    {
        string ConnectionString { get; }
    }
}

