namespace ALDQuoteService.Models
{
    /// <summary>
    /// Quote model for a finance contract
    /// </summary>
    public class Quote
    {
        /// <summary>
        /// A unique identifier for this Quote
        /// </summary>
        public string QuoteId { get; set; }

        /// <summary>
        /// The retail price of the vehicle
        /// </summary>
        public decimal VehicleRetailPrice { get; set; }

        /// <summary>
        /// The initial payment made at contract start
        /// </summary>
        public decimal DepositAmount { get; set; }

        /// <summary>
        /// The monthly payment amount
        /// </summary>
        public decimal MonthlyPayment { get; set; }

        /// <summary>
        /// The total amount payable over the contract term
        /// </summary>
        public decimal TotalAmountPayable { get; set; }

        /// <summary>
        /// The total amount of interest payable over the contract term
        /// </summary>
        public decimal TotalInterestPayable { get; set; }

        /// <summary>
        /// Annual Percentage Rate (Interest Rate)
        /// </summary>
        public decimal Apr { get; set; }

        /// <summary>
        /// The payment amount required to end the contract at full term
        /// </summary>
        public decimal FinalPayment { get; set; }
    }
}