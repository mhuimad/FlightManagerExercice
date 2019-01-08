using FlightManager.Module.Entities;
using FlightManager.Module.Interfaces;
using FlightManager.Module.Ports;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManager.Module
{
    public class ResourceModule : IResourceModule
    {
        private readonly IResourceRepository _repo;


        public ResourceModule(IResourceRepository repo)
        {
            _repo = repo;
        }

        public Airport GetAirportById(int id)
        {
            return _repo.GetAirportById(id);
        }

        public List<Airport> LoadAirports()
        {
            return _repo.LoadAirports();
        }
    }
}
