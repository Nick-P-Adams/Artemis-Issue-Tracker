class PopupMenu {
    constructor() {
        this.popupMenu = null;
        this.button = null;
        this.boundClickOutside = this.clickOutside.bind(this);
    }

    displayPopup(buttonId, menuClass, itemId) {
        this.button = document.getElementById(buttonId);
        this.createMenu(menuClass, itemId);
        
        document.body.appendChild(this.popupMenu);
        document.addEventListener('click', this.boundClickOutside);
    }

    createMenu(menuClass, itemId) {
        this.popupMenu = document.createElement("div");
        this.popupMenu.className = menuClass;
        this.popupMenu.id = menuClass + itemId;

        this.populateMenu(itemId);
    }

    populateMenu(itemId) {
        if (this.populateMenu.className = "project-delete-menu") {
            let title = `<div class="popup-menu-title"><h1>Delete Project?</h1></div>`;

            let body = `<div class="popup-menu-body"><p>Warning! Are you sure you want to delete this project? \
                            Pressing delete will result in the project and everything under it being permanently deleted</p></div>`;

            let cancelButton = document.createElement("div");
            cancelButton.className = "popup-menu-button";
            cancelButton.onclick = this.removeMenu.bind(this);
            cancelButton.innerText = "Cancel";

            let deleteButton = document.createElement("form");
            deleteButton.className = "popup-menu-button-delete";
            deleteButton.action = "/Projects/Delete";
            deleteButton.method = "post";

            let inputValue = document.createElement("input");
            inputValue.type = "hidden";
            inputValue.name = "id";
            inputValue.value = itemId;

            let inputSubmit = document.createElement("input");
            inputSubmit.type = "submit";
            inputSubmit.value = "Delete";

            let verificationToken = $('input[name="__RequestVerificationToken"]').val();
            let inputToken = document.createElement("input");
            inputToken.name = "__RequestVerificationToken"
            inputToken.type = "hidden";
            inputToken.value = verificationToken;

            deleteButton.append(inputValue, inputSubmit, inputToken);

            let buttonContainer = document.createElement("div");
            buttonContainer.className = "popup-menu-button-container";

            buttonContainer.append(cancelButton, deleteButton);

            this.popupMenu.innerHTML = title + body;
            this.popupMenu.appendChild(buttonContainer);
        }
    }

    clickOutside(event) {
        // If the click is outside of the this.popupMenu and the button
        if (this.popupMenu.contains(event.target) || this.button.contains(event.target)) { return; }
        else { this.removeMenu(); }
    }

    removeMenu() {
        document.body.removeChild(this.popupMenu);
        document.removeEventListener('click', this.boundClickOutside);
        this.popupMenu = null;
    }
}

const popupMenu = new PopupMenu();