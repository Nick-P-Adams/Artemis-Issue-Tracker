const dateContainer = document.getElementById("date-container"),
      monthNames = ["January", "February", "March", "April", "May", "June",
                    "July", "August", "September", "October", "November", "December"],
      weekDays = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

let date = new Date(),
    currentYear = date.getFullYear(),
    currentMonth = date.getMonth(),
    lastDateofMonth,
    lastDateofLastMonth,
    firstDayofMonth,
    lastDayofMonth,
    currentWeek,
    currentDay,
    currentDayName;

function renderRoadmap() { 
    for (i = 0; i < 12; i++) {
        if (currentDay == lastDateofMonth - lastDayofMonth) {
            currentMonth += 1;
            dateUpdate();
        }

        let dateItem = `<div class="date-item">
                            <div class="month-container">
                                <p class="current-month">${monthNames[currentMonth]}</p>
                            </div>

                            <div class="week-container">
                                <ul class="day-name-list" id="day-name-list${i}"></ul>
                                <ul class="day-list" id="day-list${i}"></ul>
                            </div>
                        </div>`, // date-item HTML format
            liDayName = "", x// day-name-list items
            liDay = ""; // day-list items

        dateContainer.innerHTML += dateItem; // adding the date-item to the date-container

        const dayNameList = document.getElementById(`day-name-list${i}`),
              dayList = document.getElementById(`day-list${i}`); // fetching the current day-name-list and day-list associated with current date-item
                                                               // there is probably a better way to do this maybe assign the i value to the date-item
        console.log(currentWeek);
        if (currentWeek == 0) { // for first week only
            console.log("here");
            for (let i = firstDayofMonth; i > 0; i--) {
                liDayName += `<li>${weekDays[currentDayName]}</li>`;
                liDay += `<li>${(lastDateofLastMonth - i) + 1}</li>`; // getting the previous months days that occur in this months first week
                currentDayName += 1;
            }
            
            for (let i = firstDayofMonth; i < 7; i++) {
                liDayName += `<li>${weekDays[currentDayName]}</li>`;
                liDay += `<li>${currentDay}</li>`;
                currentDayName += 1;
                currentDay += 1;
            }
        }
        else { // for all the middle weeks 
            for (let i = 0; i < 7; i++) {
                liDayName += `<li>${weekDays[i]}</li>`;
                liDay += `<li>${currentDay}</li>`;
                currentDay += 1;
            }
        }

        currentWeek += 1; // updating the week number for current month
        currentDayName = 0; // setting index back to 0 for the start of a new week

        dayNameList.innerHTML = liDayName;
        dayList.innerHTML = liDay;
    }
}

function dateUpdate() {
    if (currentMonth < 0 || currentMonth > 11) { // conditions checks to see if we have moved into previous year or next year
        // creating a new Date object of current year and month then passing it to our date variable
        date = new Date(currentYear, currentMonth);
        currentYear = date.getFullYear(); // updating current year with new date year
        currentMonth = date.getMonth(); // updating current month with new date month
    }

    currentWeek = 0;
    currentDay = 1; // gets set back to the first of the month for each new month
    currentDayName = 0; // the week always starts on sunday // could be a user option later to let the week start on mondays

    lastDateofMonth = new Date(currentYear, currentMonth + 1, 0).getDate(); // fetching last date of month
    lastDateofLastMonth = new Date(currentYear, currentMonth, 0).getDate(); // fetching last date of previous month
    firstDayofMonth = new Date(currentYear, currentMonth, 1).getDay(); // fetching index of first day of month
    lastDayofMonth = new Date(currentYear, currentMonth, lastDateofMonth).getDay(); // fetching index of last day of the month
}

dateUpdate();
renderRoadmap();