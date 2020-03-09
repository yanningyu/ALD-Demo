using ALDQuoteService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALDQuoteService.QuoteEngines
{
    public interface IQuoteEngine
    {
        /// <summary>
        /// An implementation of FinanceCalculator appropriate to generating
        /// quotes of a particular finance type
        /// </summary>
        FinanceCalculatorBase FinanceAmountCalculator { get; set; }

        /// <summary>
        /// Calculates a new quote from the specified parameters
        /// </summary>
        /// <param name="vehiclePrice">The retail price of the vehicle</param>
        /// <param name="termMonths">The retail price of the vehicle</param>
        /// <param name="deposit">The deposit amount to be paid at contract start</param>
        /// <returns></returns>
        Quote Calculate(decimal vehiclePrice, short termMonths, decimal deposit);
    }
}