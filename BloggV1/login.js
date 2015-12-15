$(function() {


    $('#username').focus(function() {
        $(this).addClass('username.focused');
        $(this).removeClass('username');
        $(this).val('');
    });

    $('#Password').focus(function() {
        $(this).addClass('password.focused');
        $(this).removeClass('password');
        $(this).prop('type', 'password');
        $(this).attr('value', '');
    });

    $('#username').blur(function() {
        $(this).addClass('username');
        $(this).removeClass('username.focused');
        if ($(this).val() == '') {
            $(this).attr('value', 'Username');
        }
    });

    $('#Password').blur(function() {
        $(this).addClass('password');
        $(this).removeClass('password.focused');
        if ($(this).val() == '') {
            $(this).attr('value', 'Password');
            $(this).prop('type', 'text');
        }
    });



});
