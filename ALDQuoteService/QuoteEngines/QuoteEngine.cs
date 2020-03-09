using System;
using ALDQuoteService.Models;
using ALDQuoteService.Services;

namespace ALDQuoteService.QuoteEngines
{
    public class QuoteEngine : IQuoteEngine
    {
        internal QuoteEngine() { }

        /// <summary>
        /// An implementation of FinanceCalculator appropriate to generating
        /// quotes of a particular finance type
        /// </summary>
        public FinanceCalculatorBase FinanceAmountCalculator { get; set; }

        /// <summary>
        /// Calculates a new quote from the specified parameters
        /// </summary>
        /// <param name="vehiclePrice">The retail price of the vehicle</param>
        /// <param name="termMonths">The retail price of the vehicle</param>
        /// <param name="deposit">The deposit amount to be paid at contract start</param>
        /// <returns></returns>
        public Quote Calculate(decimal vehiclePrice, short termMonths, decimal deposit)
        {
            var apr = FinanceAmountCalculator.GetAnnualPercentageRate(termMonths);
            var interestPayable = FinanceAmountCalculator.GetTotalInterestPayable(vehiclePrice, deposit, apr, termMonths);

            var totalAmountPayable = vehiclePrice + interestPayable;
            var finalPayment = FinanceAmountCalculator.GetFinalPayment(vehiclePrice, termMonths);
            var monthlyPayment = Math.Round((totalAmountPayable - finalPayment) / termMonths, 2);

            var quote = new Quote()
            {
                QuoteId = IdGenerator.NewId(),
                Apr = apr,
                TotalInterestPayable = Math.Round(interestPayable, 2),
                TotalAmountPayable = Math.Round(vehiclePrice + interestPayable, 2),
                MonthlyPayment = monthlyPayment,
                VehicleRetailPrice = vehiclePrice,
                DepositAmount = deposit,
                FinalPayment = finalPayment
            };

            return quote;
        }
    }
}