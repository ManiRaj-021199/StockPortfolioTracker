using Microsoft.AspNetCore.Mvc;
using StockPortfolioTracker.Common;

namespace Recommendation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecommendationController : ControllerBase
{
    #region Fields
    private readonly IRecommendationFacade recommendationFacade;
    #endregion

    #region Constructors
    public RecommendationController(IRecommendationFacade recommendationFacade)
    {
        this.recommendationFacade = recommendationFacade;
    }
    #endregion

    #region Publics
    [HttpGet]
    [Route("TestApi")]
    public string TestApi()
    {
        return "Test Api";
    }

    [HttpGet]
    [Route("TestDBCheckApi")]
    public async Task<BaseApiResponseDto> TestDBCheckApi()
    {
        BaseApiResponseDto response = await recommendationFacade.TestDBCheckApi();

        return response;
    }
    #endregion
}