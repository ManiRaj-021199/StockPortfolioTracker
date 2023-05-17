var BootstrapMethods = BootstrapMethods || {};

BootstrapMethods.ToggleSidebar = function()
{
    const elemBody = document.querySelector("body");
    const elemSidebar = document.querySelector(".navbar-nav.sidebar");

    if(elemBody.classList.contains("sidebar-toggled"))
    {
        elemBody.classList.remove("sidebar-toggled");
        elemSidebar.classList.add("toggled");
        return;
    }

    elemBody.classList.add("sidebar-toggled");
    elemSidebar.classList.remove("toggled");
};

BootstrapMethods.CloseModal = function(element)
{
    element.classList.remove("show");
    document.querySelector(".fade.show").remove();
};

BootstrapMethods.FocusNavItem = function(strElementId)
{
    const element = document.getElementById(strElementId);

    document.querySelectorAll(".collapse-item").forEach(e => e.classList.contains("active") ? e.classList.remove("active") : null);

    if(element) element.classList.add("active");
}