using FlightManager.Module.Entities;
using FlightManager.Module.Interfaces;
using System.Collections.Generic;

namespace FlightManager.Module.Calculator
{
    public class FlightCalculator
    {
        private readonly List<IFormula> _formulaListToApply;

        public FlightCalculator()
        {
            _formulaListToApply = new List<IFormula>
            {
                new DistanceBetweenAirportFormula(),
                new FuelConsumptionFormula()
            };
        }

        public void ConsolidateFlight(Flight flight)
        {
            foreach (var formula in _formulaListToApply)
            {
                formula.Apply(flight);
            }
        }

        public void ConsolidateFlights(IEnumerable<Flight> flights)
        {
            foreach (var item in flights)
            {
                ConsolidateFlight(item);
            }
        }
    }
}
