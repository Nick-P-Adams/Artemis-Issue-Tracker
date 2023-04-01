class DropdownMenu {
    constructor() {
        this.dropdownMenu = null;
        this.button = null;
    }

    // need to fix the logic in this function to be readable 
    displayDropdown(buttonId, menuClass, itemId) {
        let previousMenu;

        if (this.dropdownMenu != null) {
            previousMenu = this.dropdownMenu;
            this.removeMenu();
        }

        if (previousMenu == null || (this.dropdownMenu == null && previousMenu.id != menuClass + itemId)) {
            this.button = document.getElementById(buttonId);
            this.createMenu(menuClass, itemId);

            // sort of a simple dropdownMenu factory based on the Id or class add different options
            if (menuClass = "project-settings-menu") {
                let editButton = `<a class="project-settings-menu-button text-light" href="/Projects/Edit/${itemId}">Edit</a>`;
                let deleteButton = `<div class="project-settings-menu-button text-light" id="project-settings-delete-button ${itemId}" onclick="dropdownMenu.removeMenu(), popupMenu.displayPopup('project-delete-menu', '${itemId}')">Delete</div>`;
                this.dropdownMenu.innerHTML = editButton + deleteButton;
            }

            document.body.appendChild(this.dropdownMenu);
            window.addEventListener('resize', this.repositionMenu);
            document.addEventListener('click', this.clickOutside);
        }
    }

    createMenu(menuClass, itemId) {
        let buttonRect = this.button.getBoundingClientRect();

        this.dropdownMenu = document.createElement("div");
        this.dropdownMenu.className = menuClass;
        this.dropdownMenu.id = menuClass + itemId;
        this.dropdownMenu.style.position = "absolute";
        this.dropdownMenu.style.top = buttonRect.bottom + 'px';
        this.dropdownMenu.style.right = (document.documentElement.clientWidth - buttonRect.right) + 'px';
    }

    clickOutside(event) {
        // If the click is outside of the dropdownMenu and the button
        if (this.dropdownMenu == null) { return; }
        if (!(this.dropdownMenu.contains(event.target) || this.button.contains(event.target))) {
            this.removeMenu();
        }
    }

    repositionMenu() {
        let buttonRect = this.button.getBoundingClientRect();
        this.dropdownMenu.style.top = buttonRect.bottom + 'px';
        this.dropdownMenu.style.right = (document.documentElement.clientWidth - buttonRect.right) + 'px';
    }

    removeMenu() {
        document.body.removeChild(this.dropdownMenu);
        window.removeEventListener('resize', this.repositionMenu);
        document.removeEventListener('click', this.clickOutside);
        this.dropdownMenu = null;
    }
}

const dropdownMenu = new DropdownMenu();