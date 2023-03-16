const currentDate = document.getElementById("current-date"),
    daysTag = document.getElementById("days"),
    prevButton = document.getElementById("prev-button"),
    nextButton = document.getElementById("next-button");

const months = ["January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"]

// getting the current date, year, and month
let date = new Date(),
    currentYear = date.getFullYear(),
    currentMonth = date.getMonth();

const renderCalendar = () => {
    dateUpdate();
    let lastDateofMonth = new Date(currentYear, currentMonth + 1, 0).getDate(), // fetching last date of month
        lastDateofLastMonth = new Date(currentYear, currentMonth, 0).getDate(), // fetching last date of previous month
        firstDayofMonth = new Date(currentYear, currentMonth, 1).getDay(), // fetching first day of month
        lastDayofMonth = new Date(currentYear, currentMonth, lastDateofMonth).getDay(); // fetching last day of the month
    let liTag = "";

    for (let i = firstDayofMonth; i > 0; i--) {
        liTag += `<li class="inactive">${lastDateofLastMonth - i + 1}</li>`;
    }

    for (let i = 1; i <= lastDateofMonth; i++) {
        let isToday = i === date.getDate() && currentMonth === new Date().getMonth()
                      && currentYear === new Date().getFullYear() ? "active" : "";
        liTag += `<li class="${isToday}">${i}</li>`;
    }

    for (let i = lastDayofMonth; i < 6; i++) {
        liTag += `<li class="inactive">${i - lastDayofMonth + 1}</li>`;
    }

    currentDate.innerText = `${months[currentMonth]} ${currentYear}`;
    daysTag.innerHTML = liTag;
}

const dateUpdate = () => {
    if (currentMonth < 0 || currentMonth > 11) { // conditions checks to see if we have moved into previous year or next year
        // creating a new Date object of current year and month then passing it to our date variable
        date = new Date(currentYear, currentMonth);
        currentYear = date.getFullYear(); // updating current year with new date year
        currentMonth = date.getMonth(); // updating current month with new date month
    } else {
        date = new Date();
    }
}
renderCalendar();

prevButton.addEventListener("click", () => {
    currentMonth -= 1;
    renderCalendar();
});

nextButton.addEventListener("click", () => {
    currentMonth += 1;
    renderCalendar();
});