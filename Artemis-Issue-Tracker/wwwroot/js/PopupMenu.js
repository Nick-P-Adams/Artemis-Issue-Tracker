class PopupMenu {
    constructor() {
        this.popupMenu = null;
    }

    displayPopup(menuClass, itemId) {
        this.createMenu(menuClass, itemId);

        if (menuClass = "project-delete-menu") {
            let title = `<div class="project-delete-menu-title"><h1>Delete Project?</h1></div>`;

            let body = `<div class="project-delete-menu-body"><p>Warning! Are you sure you want to delete this project? \
                        Pressing delete will result in the project and everything under it being permanently deleted</p></div>`;

            let cancelButton = `<div class="project-delete-menu-button text-light" id="project-delete-cancel-button ${itemId}"\
                                onclick="popupMenu.removeMenu()">Cancel</div>`;
            let deleteButton = `<div class="project-delete-menu-button text-light" id="project-delete-delete-button ${itemId}">Delete</div>`;
            this.popupMenu.innerHTML = title + body + cancelButton + deleteButton;
        }

        document.body.appendChild(this.popupMenu);
        document.addEventListener('click', this.clickOutside);
    }

    createMenu(menuClass, itemId) {
        this.popupMenu = document.createElement("div");
        this.popupMenu.className = menuClass;
        this.popupMenu.id = menuClass + itemId;
    }

    clickOutside(event) {
        // If the click is outside of the this.popupMenu and the button
        if (!this.popupMenu.contains(event.target)) {
            this.removeMenu();
        }
    }

    removeMenu() {
        document.body.removeChild(this.popupMenu);
        document.removeEventListener('click', this.clickOutside);
        this.popupMenu = null;
    }
}

const popupMenu = new PopupMenu();