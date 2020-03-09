var serviceUrl = "http://localhost:54199";



$(function() {
	
	function buildQuoteRequestUrl()
	{
		var quoteType = $("#quoteType").val();
		var vehicleRegistration = $("#vehicleRegistration").val();
		var termMonths = $("#termMonths").val();
		var deposit = $("#deposit").val();
		
		return "/Quote?quoteType="+quoteType+"&vehicleRegistration="+vehicleRegistration+"&termMonths="+termMonths+"&deposit="+deposit;
	}
	
	function renderQuote(quoteData)
	{
		$("#quoteId").text(quoteData.QuoteId);
		$("#quoteVehiclePrice").text(quoteData.VehicleRetailPrice);
		$("#quoteDeposit").text(quoteData.DepositAmount);
		$("#quoteApr").text(quoteData.Apr);
		$("#quoteMonthlyPayment").text(quoteData.MonthlyPayment);
		$("#quoteFinalPayment").text(quoteData.FinalPayment);
		$("#quoteTotalInterest").text(quoteData.TotalInterestPayable);
		$("#quoteTotalPayable").text(quoteData.TotalAmountPayable);
	}
	
	
	$("#getQuote").click(function() {

		var requestUrl = buildQuoteRequestUrl();
	
		jQuery.ajax ({
			url: serviceUrl+requestUrl,
			type: "GET",
			dataType: "json",
			contentType: "application/json; charset=utf-8",
			success: function(data){
				renderQuote(data);
			}
		});

	});
});