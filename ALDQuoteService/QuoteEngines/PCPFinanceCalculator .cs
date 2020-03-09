using System;

namespace ALDQuoteService.QuoteEngines
{
    public class PCPFinanceCalculator : FinanceCalculatorBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vehiclePrice"></param>
        /// <param name="deposit"></param>
        /// <param name="apr"></param>
        /// <param name="termMonths"></param>
        /// <returns></returns>
        public override decimal GetTotalInterestPayable(decimal vehiclePrice, decimal deposit, decimal apr, short termMonths)
        {
            decimal residualValue = GetFinalPayment(vehiclePrice, termMonths);

            decimal remainingBalance = (vehiclePrice - deposit);
            decimal monthlyInterestPct = (apr / 12) / 100;
            decimal interestAccrued = 0;
            decimal monthlyPayment = (vehiclePrice - residualValue) / termMonths;

            // Calculate interest on a reducing balance rate
            for (int i = 0; i < termMonths; i++)
            {
                interestAccrued += (remainingBalance * monthlyInterestPct);
                remainingBalance -= monthlyPayment;
            };

            return interestAccrued;
        }

        /// <summary>
        /// Calculates the final payment due at the end of the supplied contract term.
        /// </summary>
        /// <param name="vehiclePrice"></param>
        /// <param name="termMonths"></param>
        /// <returns></returns>
        public override decimal GetFinalPayment(decimal vehiclePrice, short termMonths)
        {
            double depreciationPctPerYear = 17d;
            var residualValue = (double)vehiclePrice * Math.Pow((1 - depreciationPctPerYear / 100), (termMonths / 12));
            return (decimal)Math.Round(residualValue, 2);
        }
    }
}