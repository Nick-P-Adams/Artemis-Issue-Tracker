var menu,
    button;

// need to fix the logic in this function to be readable 
function displayDropdown(buttonId, menuClass, itemId) {
    var previousMenu;

    if (menu != null) {
        previousMenu = menu;
        removeMenu();
    }

    if (previousMenu == null || (menu == null && previousMenu.id != menuClass + itemId)) {
        button = document.getElementById(buttonId);
        createMenu(menuClass, itemId);

        // sort of a simple menu factory based on the Id or class add different options
        if (menuClass = "project-dropdown-menu") {
            var option1 = `<a class="text-light" href="/Projects/Edit/${itemId}">Edit</a>`;
            var option2 = `<a class="text-light" href="/Projects/Delete/${itemId}">Delete</a>`;
            menu.innerHTML = option1 + option2;
        }

        document.body.appendChild(menu);
        window.addEventListener('resize', repositionMenu);
        document.addEventListener('click', clickOutside);
    }
}

function createMenu(menuClass, itemId) {
    buttonRect = button.getBoundingClientRect();

    menu = document.createElement("div");
    menu.className = menuClass;
    menu.id = menuClass + itemId;
    menu.style.position = "absolute";
    menu.style.top = buttonRect.bottom + 'px';
    menu.style.right = (document.documentElement.clientWidth - buttonRect.right) + 'px';
}

function clickOutside(event) {
    // If the click is outside of the menu and the button
    if (!menu.contains(event.target) && !button.contains(event.target)) {
        removeMenu();
    }
}

function repositionMenu() {
    buttonRect = button.getBoundingClientRect();
    menu.style.top = buttonRect.bottom + 'px';
    menu.style.right = (document.documentElement.clientWidth - buttonRect.right) + 'px';
}

function removeMenu() {
    document.body.removeChild(menu);
    window.removeEventListener('resize', repositionMenu);
    document.removeEventListener('click', clickOutside);
    menu = null;
}
