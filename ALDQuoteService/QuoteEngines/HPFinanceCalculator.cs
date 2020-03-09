namespace ALDQuoteService.QuoteEngines
{
    public class HPFinanceCalculator : FinanceCalculatorBase
    {
        /// <summary>
        /// Calculates the APR (interest rate) applicable to specified contract term.
        /// </summary>
        /// <param name="termMonths">The contract term in months</param>
        /// <returns></returns>
        public decimal GetAnnualPercentageRate(short termMonths)
        {
            if (termMonths <= 0)
            {
                return 7.9M;
            }

            if (termMonths > 0 && termMonths < 12)
            {
                return 6.6M;
            }

            if (termMonths >= 12 && termMonths <= 24)
            {
                return 7.9M;
            }

            if (termMonths > 24 && termMonths < 36)
            {
                return 5.6M;
            }

            if (termMonths == 36)
            {
                return 6.9M;
            }

            if (termMonths > 36 && termMonths <= 48)
            {
                return 5.9M;
            }

            //return 4.6M;

            return base.GetAnnualPercentageRate(termMonths);
        }
    }
}