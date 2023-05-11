using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using StockPortfolioTracker.Common;

namespace StockPortfolioTracker.Web.Components;

public partial class RemoveStockModal
{
    #region Fields
    private ElementReference RefToRemoveStockModal;
    #endregion

    #region Properties
    [Parameter]
    public int UserId { get; set; }

    [Parameter]
    public string? UserAccessToken { get; set; }

    [Parameter]
    public EventCallback UpdatePortfolio { get; set; }

    [Parameter]
    public List<HoldingStockDto>? HoldingStocks { get; set; }

    [Inject]
    private IJSRuntime? JSRuntime { get; set; }

    private PortfolioTransactionDto? StockNeedToRemove { get; set; }
    #endregion

    #region Protecteds
    protected override void OnInitialized()
    {
        InitializeProperties();
    }
    #endregion

    #region Privates
    private void InitializeProperties()
    {
        this.StockNeedToRemove = new PortfolioTransactionDto();
    }

    private async Task RemoveStockFromPortfolio()
    {
        this.StockNeedToRemove!.UserId = this.UserId;
        this.StockNeedToRemove.Symbol = this.HoldingStocks!.FirstOrDefault(x => x.StockName == this.StockNeedToRemove.Symbol)!.Symbol!;

        await HttpClientHelper.MakeApiRequest(PortfolioEndPoints.RemoveStockFromPortfolio, HttpMethods.Post, this.UserAccessToken!, this.StockNeedToRemove);

        this.StockNeedToRemove = new PortfolioTransactionDto();
        await CloseModal(RefToRemoveStockModal);
        await this.UpdatePortfolio.InvokeAsync();
    }

    private async Task CloseModal(ElementReference refElement)
    {
        await this.JSRuntime!.InvokeVoidAsync("BootstrapMethods.CloseModal", refElement);
    }
    #endregion
}