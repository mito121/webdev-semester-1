if (document.querySelector('#calendar1')) {
    function selectDate(date) {
        $('#calendar1').updateCalendarOptions({
            date: date
        });
        console.log(calendar.getSelectedDate());
    }
}

function openNav() {
    document.getElementById("mySidenav").style.width = "300px";
}

function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
}

if (document.getElementById("sideNav")) {
    document.getElementById("sideNav").addEventListener("click", openNav);
}


var defaultConfig = {
    weekDayLength: 1,
    date: '08/05/2021',
    onClickDate: selectDate,
    showYearDropdown: true,
    startOnMonday: true,
};

if (document.getElementById("#calendar1")) {
    var calendar = $('#calendar1').calendar(defaultConfig);
    console.log(calendar.getSelectedDate());
}
