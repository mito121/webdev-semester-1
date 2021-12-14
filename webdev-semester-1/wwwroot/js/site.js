

function openNav() {
    document.getElementById("mySidenav").style.width = "300px";
    document.getElementById("mySidenav").style.boxShadow = "1px 1px 9px 1px";
}

function closeNav() {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("mySidenav").style.boxShadow = "none";
}

if (document.getElementById("sideNav")) {
    document.getElementById("sideNav").addEventListener("click", openNav);
}

function calendar2DontSelectDate() {
    console.log('hej');
}

if (document.querySelector('#calendar1')) {
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
  
    let display = "none";
  
    function selectDate(date) {
        $('#calendar1').updateCalendarOptions({
            date: date
        });
      
        console.log(calendar1.getSelectedDate());

        if (display == "none") {
            display = "block";
            $(".popUpEditDay").css("display", display)
        } else {
            display = "none";
            $('.popUpEditDay').css("display", display)
        }

        $('#edit-overlay').css("display", display);
    }

    var calendar1 = $('#calendar1').calendar(calendar1Config);
    /*var calendar2 = $('#calendar2').calendar(calendar2Config);*/
    console.log(calendar1.getSelectedDate());
}
