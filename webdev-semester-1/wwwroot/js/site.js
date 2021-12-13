if (document.querySelector('#calendar1')) {


    let display = "none";

    function selectDate(date) {
        $('#calendar1').updateCalendarOptions({
            date: date
        });
        console.log(calendar1.getSelectedDate());

        if (display == "none") {
            display = "block";
            $(".popUpEditDay").css("display", "flex")
        } else {
            display = "none";
            $('.popUpEditDay').css("display", "none")
        }

        $('#edit-overlay').css("display", display);
    }

    function calendar2DontSelectDate() {
        console.log('hej');
    }
 

    var today = new Date();
    var dd = today.getDate();

    var mm = today.getMonth() + 1;
    var yyyy = today.getFullYear();
    today = mm + '/' + dd + '/' + yyyy;

    var calendar1Config = {
        weekDayLength: 1,
        date: today,
        onClickDate: selectDate,
        showYearDropdown: true,
        startOnMonday: true,
    };

    var calendar2Config = {
        showAvailabilityButton: false,
        onClickDate: calendar2DontSelectDate
    }

    var calendar1 = $('#calendar1').calendar(calendar1Config);
    /*var calendar2 = $('#calendar2').calendar(calendar2Config);*/
    console.log(calendar1.getSelectedDate());
}
