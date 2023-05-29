var tabButtons = document.querySelectorAll(".tab-container .tab-bar button")
var tabPanels = document.querySelectorAll(".tab-container .tab-panel")

function showPanel(panelIndex, colorCode) {
    tabButtons.forEach(function (node) {
        node.style.backgroundColor = "";
        node.style.color = "white";
    });

    tabButtons[panelIndex].style.backgroundColor = colorCode;
    tabButtons[panelIndex].style.color = "white";

    tabPanels.forEach(function (node) {
        node.style.display = "none";
    });

    tabPanels[panelIndex].style.display = "block";
    tabPanels[panelIndex].style.backgroundColor = colorCode;
}
showPanel(0, '#232323')