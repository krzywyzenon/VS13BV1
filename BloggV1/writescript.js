$(function() {
    
    $('#articleText').keyup(function(event) {
        var text = $('#articleText');
        var len = text.val().length;
        if (len <= 2000) {
            
        $('#charNum').text(2000 - len);
        } else {
            
            $('#charNum').text(0);
        }

        if (text.val().length >= 2000) {
            text.attr('value', text.val().substring(0, 2000));
        }
    });

    $('#articleTitle').keyup(function(event) {
        var title = $('#articleTitle');
        var len = title.val().length;
        if (len <= 50) {
            
        $('#titleChars').text(50 - len);
        } else {
            
            $('#titleChars').text(0);
        }

        if (title.val().length >= 50) {
            title.attr('value', title.val().substring(0, 50));
        }
    });

    
});