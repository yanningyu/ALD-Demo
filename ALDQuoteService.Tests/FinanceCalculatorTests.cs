using NUnit.Framework;
using ALDQuoteService.QuoteEngines;

namespace ALDQuoteService.Tests
{
    [TestFixture]
    public class FinanceCalculatorTests
    {
        /// <summary>
        /// Test the calculation of APR (interest rate) for unspecified contract types
        /// </summary>
        /// <param name="termMonth"></param>
        /// <param name="expectedApr"></param>
        [TestCase(-1, 6.6)]
        [TestCase(0, 6.6)]
        [TestCase(11, 6.6)]
        [TestCase(12, 6.6)]
        [TestCase(23, 5.6)]
        [TestCase(24, 5.6)]
        [TestCase(35, 5.6)]
        [TestCase(36, 4.6)]
        [TestCase(37, 4.6)]
        [TestCase(100, 4.6)]
        public void TestDefaultAprCalculation(short termMonth, decimal expectedApr)
        {
            var financeCalc = new FinanceCalculatorBase();
            var apr = financeCalc.GetAnnualPercentageRate(termMonth);
            Assert.AreEqual(expectedApr, apr);
        }

        /// <summary>
        /// Test the calculatioon of APR (interest rate) specific to Hire Purchase
        /// </summary>
        /// <param name="termMonth"></param>
        /// <param name="expectedApr"></param>
        [TestCase(-1, 7.9)]
        [TestCase(0, 7.9)]
        [TestCase(12, 7.9)]
        [TestCase(24, 7.9)]
        [TestCase(36, 6.9)]
        [TestCase(48, 5.9)]
        public void TestAprCalculationForHirePurchase(short termMonth, decimal expectedApr)
        {
            var financeCalc = new HPFinanceCalculator();
            var apr = financeCalc.GetAnnualPercentageRate(termMonth);
            Assert.AreEqual(expectedApr, apr);
        }

        /// <summary>
        /// Test calculation of total interest payable
        /// </summary>
        /// <param name="vehiclePrice"></param>
        /// <param name="deposit"></param>
        /// <param name="apr"></param>
        /// <param name="termMonths"></param>
        /// <param name="expectedInterest"></param>
        [TestCase(9000, 0, 4.6, 12, 414.00)]
        [TestCase(9000, 0, 4.6, 24, 828.00)]
        [TestCase(9000, 0, 4.6, 36, 1242.00)]
        [TestCase(15000, 500, 7.9, 12, 1145.50)]
        [TestCase(15000, 500, 7.9, 24, 2291.00)]
        [TestCase(15000, 500, 7.9, 36, 3436.50)]
        public void TestDefaultTotalInterestPayableCalculation(decimal vehiclePrice, decimal deposit, decimal apr, short termMonths, decimal expectedInterest)
        {
            var financeCalc = new FinanceCalculatorBase();
            var totalInterestPayable = financeCalc.GetTotalInterestPayable(vehiclePrice, deposit, apr, termMonths);
            Assert.AreEqual(expectedInterest, totalInterestPayable);
        }
    }
}
