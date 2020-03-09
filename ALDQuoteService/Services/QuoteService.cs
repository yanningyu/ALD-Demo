using ALDQuoteService.Models;
using ALDQuoteService.QuoteEngines;

namespace ALDQuoteService.Services
{
    /// <summary>
    /// Service for calculating finance quotes
    /// </summary>
    public class QuoteService
    {
        private QuoteEngineFactory _quoteFactory;

        /// <summary>
        /// Default constructor
        /// </summary>
        public QuoteService()
        {
            _quoteFactory = new QuoteEngineFactory();
        }

        /// <summary>
        /// Calculates a finance quote of the requested type
        /// </summary>
        /// <param name="quoteType">The type of finance contract <see cref="QuoteType"/></param>
        /// <param name="vehiclePrice">The retail price of the vehicle</param>
        /// <param name="termMonths">The contract term in months</param>
        /// <param name="deposit">The initial payment made at contract start</param>
        /// <returns>Quote model</returns>
        public Quote CalculateQuote(QuoteType quoteType, decimal vehiclePrice, short termMonths, decimal deposit)
        {
            IQuoteEngine quoteEngine = _quoteFactory.Create(quoteType);
            return quoteEngine.Calculate(vehiclePrice, termMonths, deposit);
        }
    }
}