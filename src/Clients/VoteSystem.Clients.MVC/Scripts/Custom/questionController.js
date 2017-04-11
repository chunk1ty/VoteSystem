(function () {
    'use strict';

    $('#question-list').on('click', '.remove-btn', function () {
        $(this)
            .parent()
            .remove();
    });
}());