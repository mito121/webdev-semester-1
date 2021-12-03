if (document.querySelector('#calendar1')) {
    function selectDate(date) {
        $('#calendar1').updateCalendarOptions({
            date: date
        });
        console.log(calendar.getSelectedDate());
    }

    var defaultConfig = {
        weekDayLength: 1,
        date: '08/05/2021',
        onClickDate: selectDate,
        showYearDropdown: true,
        startOnMonday: true,
    };

    var calendar = $('#calendar1').calendar(defaultConfig);
    console.log(calendar.getSelectedDate());
}
