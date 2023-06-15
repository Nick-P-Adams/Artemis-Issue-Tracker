const roadmapContainer = document.getElementById("roadmap-container"),
      dateContainer = document.getElementById("date-container"),
      months = ["January", "February", "March", "April", "May", "June",
                    "July", "August", "September", "October", "November", "December"],
      weekDays = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];

let date = new Date(), // todays date
    year = date.getFullYear(), // getting year based on date
    month = date.getMonth(), // getting the month based on date
    lastDateofMonth, // last day number of the month
    lastDateofLastMonth, // last day number of previous month 
    firstDayofMonth, // index 0-6 of where the first day of the month occurs in the week
    lastDayofMonth, // index 0-6 of where the last day of the month occurs in the week
    currentDate, // index of the date-item that contains the current date
    week, // week of the month
    day, // day of month
    dayNameIndex;

function renderRoadmap() { 
    for (i = 0; i < 12; i++) {
        if (day == lastDateofMonth - lastDayofMonth) {
            month += 1;
            dateUpdate();
        }

        // if needed this can be rearragned to have unique ids for date-item instead of the unordered lists in week-container
        let dateItemHTML = `<div class="date-item text-light">
                                <div class="month-container">
                                     <p class="month-name">${months[month]}</p>
                                </div>

                                <div class="week-container">
                                    <ul class="day-name-list" id="day-name-list${i}"></ul>
                                    <ul class="day-list" id="day-list${i}"></ul>
                                </div>
                            </div>`, // date-item HTML format
            liDayName = "", // day-name-list items
            liDay = ""; // day-list items

        dateContainer.innerHTML += dateItemHTML; // adding the date-item to the date-container

        const dayNameList = document.getElementById(`day-name-list${i}`),
              dayList = document.getElementById(`day-list${i}`); // fetching the current day-name-list and day-list associated with current date-item

        if (week == 0) { // for first week only
            for (let i = firstDayofMonth; i > 0; i--) {
                liDayName += `<li>${weekDays[dayNameIndex]}</li>`;
                liDay += `<li>${(lastDateofLastMonth - i) + 1}</li>`; // getting the previous months days that occur in this months first week
                dayNameIndex += 1;
            }
            
            for (let i = firstDayofMonth; i < 7; i++) {
                liDayName += `<li>${weekDays[dayNameIndex]}</li>`;
                liDay += `<li>${day}</li>`;
                dayNameIndex += 1;
                day += 1;
            }
        }
        else { // for all the middle weeks 
            for (let i = 0; i < 7; i++) {
                liDayName += `<li>${weekDays[i]}</li>`;
                liDay += `<li>${day}</li>`;
                day += 1;
            }
        }

        week += 1; // updating the week number for current month
        dayNameIndex = 0; // setting index back to 0 for the start of a new week

        dayNameList.innerHTML = liDayName;
        dayList.innerHTML = liDay;

        if (date.getDate() > day && date.getDate() < (day + 7) && month === new Date().getMonth()
            && year === new Date().getFullYear())
        {
            currentDate = i + 2;
        }
    }
}

function dateUpdate() {
    if (month < 0 || month > 11) { // conditions checks to see if we have moved into previous year or next year
        // creating a new Date object of current year and month then passing it to our date variable
        date = new Date(year, month);
        year = date.getFullYear(); // updating current year with new date year
        month = date.getMonth(); // updating current month with new date month
    }

    week = 0; // indicating the first week of the month
    day = 1; // gets set back to the first of the month for each new month
    dayNameIndex = 0; // the week always starts on sunday // could be a user option later to let the week start on mondays

    lastDateofMonth = new Date(year, month + 1, 0).getDate(); // last date of month
    lastDateofLastMonth = new Date(year, month, 0).getDate(); // last date of previous month
    firstDayofMonth = new Date(year, month, 1).getDay(); // index of first day of month (0-6)
    lastDayofMonth = new Date(year, month, lastDateofMonth).getDay(); // index of last day of the month (0-6)
}

dateUpdate(); // initial setup
renderRoadmap();

// Below is drag to scroll functionality for roadmap-container
 // Would prefer this to have it's own .js file however I am not sure how to pass values between scripts yet.
 // In the future I will need to seperate this and pass the position value for current month and date.

let dateItems = document.getElementsByClassName("date-item"),
    dateItemWidth = dateItems[0].clientWidth;

let currentDateItemPosition = ((dateItemWidth * currentDate) - (dateItemWidth / 2)) - (roadmapContainer.clientWidth / 2),
    currentPosition = { left: 0, x: 0 };

const mouseDownHandler = function (e) {
    pos = {
        // The current scroll
        left: roadmapContainer.scrollLeft,
        // Get the current mouse position
        x: e.clientX,
    };

    // Change the cursor and prevent user from selecting the text
    roadmapContainer.style.cursor = 'grabbing';
    roadmapContainer.style.userSelect = 'none';

    document.addEventListener('mousemove', mouseMoveHandler);
    document.addEventListener('mouseup', mouseUpHandler);
};

const mouseMoveHandler = function (e) {
    // How far the mouse has been moved
    const dx = e.clientX - pos.x;
    // Scroll the element
    roadmapContainer.scrollLeft = pos.left - dx;
};

const mouseUpHandler = function () {
    document.removeEventListener('mousemove', mouseMoveHandler);
    document.removeEventListener('mouseup', mouseUpHandler);

    roadmapContainer.style.cursor = 'grab';
    roadmapContainer.style.removeProperty('user-select');
};

function scrollToPosition(leftPosition) {
    roadmapContainer.scrollTo({
        top: 0,
        left: leftPosition,
    });
}
function smoothScrollToPosition(leftPosition) {
    roadmapContainer.scrollTo({
        top: 0,
        left: leftPosition,
        behavior: "smooth",
    });
}

scrollToPosition(currentDateItemPosition);
roadmapContainer.addEventListener('mousedown', mouseDownHandler);