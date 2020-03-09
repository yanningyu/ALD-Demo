using System;

namespace ALDQuoteService.QuoteEngines
{

    /// <summary>
    /// The type of Quote, pertaining to 
    /// recognised finance contract types
    /// </summary>
    public enum QuoteType
    {
        HirePurchase,
        PersonalContractPurchase
    }

    /// <summary>
    /// Creates quote engines for the purpose of calculating finance quotes
    /// </summary>
    public class QuoteEngineFactory
    {
        /// <summary>
        /// Creates an instance of <see cref="IQuoteEngine"/> for the specified <see cref="QuoteType"/>
        /// </summary>
        /// <param name="quoteType">The type of quote being requested <see cref="QuoteType"/></param>
        /// <returns></returns>
        public IQuoteEngine Create(QuoteType quoteType)
        {
            IQuoteEngine quoteEngine = new QuoteEngine();

            if (quoteType == QuoteType.HirePurchase)
            {
                quoteEngine.FinanceAmountCalculator = new HPFinanceCalculator();
            }
            else if(quoteType == QuoteType.PersonalContractPurchase)
            {
                quoteEngine.FinanceAmountCalculator = new PCPFinanceCalculator();
            }
            else
            {
                throw new  NotImplementedException($"A finance amount calculator has not been implemented for the requested QuoteType ({quoteType})");
            }

            return quoteEngine;
        }
    }
}