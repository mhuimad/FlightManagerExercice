using FlightManager.Module.Entities;
using FlightManager.Module.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlightManager.Module.Calculator
{
    public class FlightCalculator
    {
        private List<IFormula> _formulaListToApply;

        public FlightCalculator()
        {
            _formulaListToApply = new List<IFormula>();
            _formulaListToApply.Add(new DistanceBetweenAirportFormula());
            _formulaListToApply.Add(new FuelConsumptionFormula());
        }

        public void ApplyAllFormula(Flight flight)
        {
            foreach (var formula in _formulaListToApply)
            {
                formula.Apply(flight);
            }
        }
    }
}
