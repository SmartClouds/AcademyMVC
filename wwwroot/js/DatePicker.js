$(document).ready(function () {
    $('.datepicker').datepicker(
        {
            dateFormat: 'yy-mm-dd',
            minDate: AddSubtractMonths(new Date(), -2),
            maxDate: AddSubtractMonths(new Date(), 4)

        }
    );
    

});