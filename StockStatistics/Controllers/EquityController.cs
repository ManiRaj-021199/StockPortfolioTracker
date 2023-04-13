using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StockPortfolioTracker.Common.Dtos;

namespace StockStatistics.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquityController : ControllerBase
{
    #region Publics
    [HttpGet]
    [Route("GetFinancialData/{strStockSympol}")]
    public IActionResult GetFinancialData(string strStockSympol)
    {
        HttpClient client = new();
        FinancialData financialData = new();

        client.BaseAddress = new Uri($"https://query2.finance.yahoo.com/v10/finance/quoteSummary/{strStockSympol}");

        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = client.GetAsync("?modules=financialData").Result;

        if(!response.IsSuccessStatusCode)
        {
            financialData.StatusCode = 400;
            financialData.StatusMessage = "Something went wrong.";

            return Ok(financialData);
        }

        string responseResult = response.Content.ReadAsStringAsync().Result;
        QuoteSummaryResponse? data = JsonConvert.DeserializeObject<QuoteSummaryResponse>(responseResult);

        financialData = data.QuoteSummary?.Result![0].FinancialData!;
        financialData.StatusCode = 200;
        financialData.StatusMessage = "Data Fetched Successfully.";

        return Ok(financialData);
    }
    #endregion
}