"use strict";

var currentFocus;
var smartsearchInput;

function autocomplete(element, arr)
{
    smartsearchInput = element;
    arr = arr.quotes.map(x => x.longName || x.shortName);
    
    const ddlSmartSearch = createDropdownList(element);
    const bIsArrEmpty = insertDropdownItems(element, arr, ddlSmartSearch);

    if(!bIsArrEmpty) return;
    closeAllLists(element);

    currentFocus = -1;
    addEventListenersForSmartSearch(element, arr);
};

const createDropdownList = (element) =>
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

const insertDropdownItems = (element, arr, ddlSmartSearch) =>
{
    if(arr.count == 0 || arr.length == 0)
    {
        let ddlItem = document.createElement("DIV");
        ddlItem.setAttribute("class", "list-group-item list-group-item-action");
        ddlItem.innerHTML += "No Stocks Found...";
        ddlItem.addEventListener("click",
            function()
            {
                element.value = this.getElementsByTagName("input")[0].value;
                closeAllLists(element);
            });
        ddlSmartSearch.appendChild(ddlItem);

        return false;
    }

    for(let i = 0; i < arr.length; i++)
    {
        let ddlItem = document.createElement("DIV");
        ddlItem.setAttribute("class", "list-group-item list-group-item-action d-flex justify-content-between");
        ddlItem.innerHTML += `<span>${arr[i]}</span>`;
        ddlItem.innerHTML += `<span class="text-primary">${arr[i]}</span>`;
        ddlItem.innerHTML += `<input type='hidden' value='${arr[i]}'>`;

        ddlItem.addEventListener("click",
            function()
            {
                element.value = this.getElementsByTagName("input")[0].value;
                closeAllLists(arr[i]);
            });
        ddlSmartSearch.appendChild(ddlItem);
    }

    return true;
}

const removeActive = (x) =>
{
    for(let i = 0; i < x.length; i++)
    {
        x[i].classList.remove("active");
    }
};

const addActive = (x) =>
{
    if(!x) return false;

    removeActive(x);
    if(currentFocus >= x.length) currentFocus = 0;
    if(currentFocus < 0) currentFocus = x.length - 1;
    x[currentFocus].classList.add("active");

    return false;
};

const closeAllLists = (element) =>
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

const addEventListenersForSmartSearch = (element, arr) =>
{
    element.addEventListener("keydown",
        function(e)
        {
            var x = document.getElementById(this.id + "autocomplete-list");
            if(x) x = x.getElementsByTagName("div");
            if(e.keyCode === 40)
            {
                currentFocus++;
                addActive(x);
            }
            else if(e.keyCode === 38)
            {
                currentFocus--;
                addActive(x);
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
            closeAllLists(e.target);
        });
}