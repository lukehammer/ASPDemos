var jsonData;
var today = new Date();
var todayDay = today.getDate();
var todayMonth = today.getMonth() + 1; //January is 0!
var todayYear = today.getFullYear();

if (todayDay < 10) {
    todayDay = '0' + todayDay;
}

if (todayMonth < 10) {
    todayMonth = '0' + todayMonth;
}

$('.datepicker').datepicker({
    forceParse: false,
    daysOfWeekHighlighted: '6',
    calendarWeeks: true,
    todayHighlight: true,
    defaultViewDate: { year: todayYear, month: todayMonth, day: todayDay }
});

$(' .input-group.date').datepicker({
    todayBtn: true,
    clearBtn: true,
    daysOfWeekHighlighted: "0,6",
    calendarWeeks: true,
    autoclose: true,
    todayHighlight: true,
    defaultViewDate: { year: 1977, month: 04, day: 25 }
});




$('#commitDatePicker').datepicker();
$('#commitDatePicker').on('changeDate',
    function () {
        console.log('commit date changed');
        $('#Commit').val(
            $('#commitDatePicker').datepicker('getFormattedDate')
        );
    });
$('#needDatePicker').datepicker();
$('#needDatePicker').on('changeDate',
    function () {
        console.log('commit date changed');
        $('#Need').val(
            $('#needDatePicker').datepicker('getFormattedDate')
        );
    });
$(function () {
    $('#IsAcculized').bootstrapToggle({
        on: 'Yes',
        off: 'No',
        onstyle: 'success',
        offstyle: 'warning'
    });
});

$(document).ready(function () {
    $('#IsAcculized').on('change', function () {
        $('input[name="IsAcculized"]').val($(this).is(':checked') ? 'true' : 'false');
    });
});




$('#clearCommit').click(function () {

    $('#Commit').val('Commit Date Not Set');
});
$('#clearNeed').click(function () {

    $('#Need').val('Need Date Not Set');
});
$('#btnsubmit').click(function (event) {
    event.preventDefault();
});


function SaveButtonOnclick() {

    //$('#ModalConfirmBackPopUp').modal('hide');
    var values = {};
    $.each($('form').serializeArray(),
        function (i, field) {
            values[field.name] = field.value;
        });
    console.log($('form').serializeArray());
    console.log(values);

    $.ajax({
        type: 'POST',
        url: '/product/UpdateActivityTask',
        data: JSON.stringify(values),
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        processData: false,
        success: function (data) {
            jsonData = data;
            var commitTarget = '.commit' + data['TaskID'] + '-' + data['AreaID'];
            $(commitTarget)[0].innerText = data.CommitDate;
            var needTarget = '.' + 'need' + data['TaskID'] + '-' + data['AreaID'];
            $(needTarget)[0].innerText = data.NeedDate;
        }
    });
}
