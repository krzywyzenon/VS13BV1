$(function () {
    $('form').click(function () {
        console.log("shit");
        console.log(this);
        $(this).submit();
        
    });

});