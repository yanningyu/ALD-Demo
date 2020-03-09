using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ALDQuoteService.Services
{
    /// <summary>
    /// Service for operations relating to the Vehicle entity
    /// </summary>
    public class VehicleService
    {
        /// <summary>
        /// Retrieves the retail price for the supplied vehicle registration 
        /// </summary>
        /// <param name="vehicleRegistration"></param>
        /// <returns></returns>
        public decimal GetRetailPrice(string vehicleRegistration)
        {
            // For the purposes of this exercise, this method represents a 
            // database-driven vehicle price lookup.  The algorithm below ensures that 
            // a specific registration plate will always return the same vehicle price.

            if (vehicleRegistration == null)
                throw new ArgumentNullException("vehicleRegistration");

            vehicleRegistration = vehicleRegistration.Replace(" ", string.Empty);
            return vehicleRegistration.ToUpper().Select(c => ((int)c * 30)).Sum();
        }
    }
}