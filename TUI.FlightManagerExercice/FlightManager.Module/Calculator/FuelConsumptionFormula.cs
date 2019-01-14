using FlightManager.Module.Entities;
using FlightManager.Module.Interfaces;

namespace FlightManager.Module.Calculator
{
    class FuelConsumptionFormula : IFormula
    {
        private const double FUEL_FOR_EACH_KM = 24.2;
        private const double TAKEOFF_EFFORT = 30;

        public Flight Apply(Flight flight)
        {
            flight.AmountOfFuel = CalculateFuelConsumption(flight.DistanceInKM);
            return flight;
        }

        private double CalculateFuelConsumption(double distanceInKM)
        {
            return (distanceInKM * FUEL_FOR_EACH_KM) + TAKEOFF_EFFORT;
        }
    }
}
