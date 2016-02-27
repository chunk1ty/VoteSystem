(function () {
    'use strict';

    $('#add-more-questions').on('click', function () {
        var moreQuestionUrl = $('#more-question-url').val();

        $.ajax({
            type: 'GET',
            url: moreQuestionUrl,
            success: function (html) {
                $('#question-list').append(html);

                $('.close-link').on('click', function () {
                    $(this)
                        .closest('div.row')
                        .remove();
                });

                $('.collapse-link').off().on('click', function () {
                    var x_panel = $(this).closest('div.x_panel');
                    var button = $(this).find('i');
                    var content = x_panel.find('div.x_content');

                    content.slideToggle(200);
                    (x_panel.hasClass('fixed_height_390') ? x_panel.toggleClass('').toggleClass('fixed_height_390') : '');
                    (x_panel.hasClass('fixed_height_320') ? x_panel.toggleClass('').toggleClass('fixed_height_320') : '');
                    button.toggleClass('fa-chevron-up').toggleClass('fa-chevron-down');
                    setTimeout(function () {
                        x_panel.resize();
                    }, 50);
                });
            },
            error: function (ex) {
                alert('Can not add new question ' + ex);
            }
        });
    });

    $('#question-list').on('click', '.remove-btn', function () {
        $(this)
            .parent()
            .remove();
    });
}());