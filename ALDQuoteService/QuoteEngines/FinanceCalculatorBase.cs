namespace ALDQuoteService.QuoteEngines
{
    /// <summary>
    /// Base implementation of FinanceCalculator
    /// </summary>
    public class FinanceCalculatorBase
    {
        /// <summary>
        /// Calculates the APR (interest rate) applicable to specified contract term.
        /// </summary>
        /// <param name="termMonths">The contract term in months</param>
        /// <returns></returns>
        public virtual decimal GetAnnualPercentageRate(short termMonths)
        {
            if (termMonths <= 12)
            {
                return 6.6M;
            }
            
            if (termMonths < 36)
            {
                return 5.6M;
            }

            return 4.6M;
            
        }

        /// <summary>
        /// Calculates the total interest payable for the specified apr,
        /// after deducting the deposit payment
        /// </summary>
        /// <param name="vehiclePrice">The retail price of the vehicle</param>
        /// <param name="deposit">The initial payment made at contract start</param>
        /// <param name="apr">The Annual Percentage Rate (interest rate)</param>
        /// <param name="termMonths">The contract term in months</param>
        /// <returns></returns>
        public virtual decimal GetTotalInterestPayable(decimal vehiclePrice, decimal deposit, decimal apr, short termMonths)
        {
            decimal totalAmountOfCredit = vehiclePrice - deposit;
            decimal totalApr = apr * (termMonths / 12);

            return totalAmountOfCredit * (totalApr / 100);
        }

        /// <summary>
        /// Calculates the residual value of a vehicle after at the end of the supplied contract term.
        /// </summary>
        /// <param name="vehiclePrice">The retail price of the vehicle</param>
        /// <param name="termMonths">The contract term in months</param>
        /// <returns></returns>
        public virtual decimal GetFinalPayment(decimal vehiclePrice, short termMonths)
        {
            return 0;
        }
    }
}