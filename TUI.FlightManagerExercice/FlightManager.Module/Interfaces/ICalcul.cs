using FlightManager.Module.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManager.Module.Interfaces
{
    public interface IFormula
    {
        Flight Apply(Flight flight);

    }
}
