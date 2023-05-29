var currentFocus = -1;
var smartsearchInput;

/* Main */
function AutoCompleteSmartSearch(element, arr, resultInputId)
{
    smartsearchInput = element;
    
    const ddlSmartSearch = _CreateDropdownList(element);
    const bIsArrEmpty = _InsertDropdownItems(element, arr, ddlSmartSearch, resultInputId);

    if(!bIsArrEmpty) return;
    _CloseAllLists(element);
    
    _AddEventListenersForSmartSearch(element, arr);
};

/* Privates */
const _CreateDropdownList = (element) =>
{
    let ddlSmartSearch = document.getElementById(element.id + "autocomplete-list");

    if(!ddlSmartSearch)
    {
        ddlSmartSearch = document.createElement("DIV");
        ddlSmartSearch.setAttribute("id", element.id + "autocomplete-list");
        ddlSmartSearch.setAttribute("class", "autocomplete-items list-group text-left");
    }
    else ddlSmartSearch.innerHTML = "";

    element.parentNode.appendChild(ddlSmartSearch);

    return ddlSmartSearch;
}

const _InsertDropdownItems = (element, arr, ddlSmartSearch, resultInputId) =>
{
    if(arr.count == 0)
    {
        let ddlItem = document.createElement("DIV");
        ddlItem.setAttribute("class", "list-group-item list-group-item-action");
        ddlItem.innerHTML += "No Stocks Found...";
        ddlItem.addEventListener("click",
            function()
            {
                element.value = this.getElementsByTagName("input")[0].value;
                _CloseAllLists(element);
            });
        ddlSmartSearch.appendChild(ddlItem);

        return false;
    }

    for(let i = 0; i < arr.count; i++)
    {
        let ddlItem = document.createElement("DIV");
        ddlItem.setAttribute("class", "list-group-item list-group-item-action d-flex justify-content-between");
        ddlItem.innerHTML += `<span>${arr.quotes[i].longName || arr.quotes[i].shortName}</span>`;
        ddlItem.innerHTML += `<span class="text-primary">${arr.quotes[i].exchDisp}</span>`;

        ddlItem.addEventListener("click",
            function()
            {
                let smartSearchElement = document.getElementById(resultInputId);

                element.value = arr.quotes[i].longName || arr.quotes[i].shortName;
                smartSearchElement.value = arr.quotes[i].symbol;

                CommonEvents.DispatchChangeEvent(smartSearchElement);

                _CloseAllLists(arr[i]);
            });
        ddlSmartSearch.appendChild(ddlItem);
    }

    return true;
}

const _RemoveActive = (x) =>
{
    for(let i = 0; i < x.length; i++)
    {
        x[i].classList.remove("active");
    }
};

const _AddActive = (x) =>
{
    if(!x) return false;

    _RemoveActive(x);
    if(currentFocus >= x.length) currentFocus = 0;
    if(currentFocus < 0) currentFocus = x.length - 1;
    x[currentFocus].classList.add("active");

    return false;
};

const _CloseAllLists = (element) =>
{
    var x = document.getElementsByClassName("autocomplete-items");
    for(let i = 0; i < x.length; i++)
    {
        if(element !== x[i] && element !== smartsearchInput)
        {
            x[i].parentNode.removeChild(x[i]);
        }
    }
};

const _AddEventListenersForSmartSearch = (element, arr) =>
{
    element.addEventListener("keydown",
        function(e)
        {
            var x = document.getElementById(this.id + "autocomplete-list");
            if(x) x = x.getElementsByTagName("div");
            if(e.keyCode === 40)
            {
                currentFocus++;
                _AddActive(x);
            }
            else if(e.keyCode === 38)
            {
                currentFocus--;
                _AddActive(x);
            }
            else if(e.keyCode === 13)
            {
                e.preventDefault();
                if(currentFocus > -1)
                {
                    if(x) x[currentFocus].click();
                }
            }
        });

    document.addEventListener("click",
        function(e)
        {
            _CloseAllLists(e.target);
        });
}