using ALDQuoteService.Models;
using ALDQuoteService.QuoteEngines;
using ALDQuoteService.Services;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ALDQuoteService.Controllers
{
    /// <summary>
    /// Controller for operations relating to Quotes
    /// </summary>
    [EnableCors(origins: "http://localhost", headers: "*", methods: "*")]
    public class QuoteController : ApiController
    {
        private QuoteService _quoteService;
        private VehicleService _vehicleService;

        /// <summary>
        /// Default constructor
        /// </summary>
        public QuoteController()
        {
            _quoteService = new QuoteService();
            _vehicleService = new VehicleService();
        }

        /// <summary>
        /// Calculates a quote for the supplied parameters
        /// </summary>
        /// <param name="quoteType">The type of finance requested</param>
        /// <param name="vehicleRegistration">The VRM of the vehicle on which to quote</param>
        /// <param name="termMonths">The term (in months) over which the vehicle will be financed</param>
        /// <param name="deposit">The deposit amount to be paid at contract start</param>
        /// <returns></returns>
        [SwaggerResponse(HttpStatusCode.OK, "Calculated Quote", typeof(Quote))]
        [SwaggerResponse(HttpStatusCode.InternalServerError, "Quote Calculation Error")]
        public Quote Get(QuoteType quoteType, string vehicleRegistration, short termMonths, decimal deposit)
        {
            var vehiclePrice = _vehicleService.GetRetailPrice(vehicleRegistration);
            var quote = _quoteService.CalculateQuote(quoteType, vehiclePrice, termMonths, deposit);

            return quote;
        }
    }
}
