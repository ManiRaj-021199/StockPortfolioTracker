var CommonMethods = CommonMethods || {};

CommonMethods.RefreshPage = function()
{
    location.reload();
};

CommonMethods.ChangeInnerHtml = function(elementId, value)
{
    document.getElementById(elementId).innerHTML = value;
}