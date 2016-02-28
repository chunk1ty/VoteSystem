$(function ($) {
    "use strict";

    var selectedRateSystem,
        deleteRateSystemUrl = $('#delete-rate-system-url').val();

    //grid settings
    $('#admin-grid').dataTable({
        pagingType: "full_numbers",
        "oLanguage": {
            "sSearch": "Search by System Name: "
        },
        columnDefs: [{
            targets: [1],
        }, {
            targets: [2],
            "sortable": false
        }, {
            targets: [3],
            "searchable": false,
            "sortable": false
        }, {
            targets: [4],
            "searchable": false,
            "sortable": false
        }]
    });

    //TODO get rigth System name
    $('tbody').on('click', '.delete-btn', function () {
        selectedRateSystem = $(this)
                .closest('tr')
                .children()
                .first();

        $('#modal-content').text(
            $(this)
                .closest('tr')
                .children()
                .first()
                .next()
                .text());
    });

    $('#delete-rate-system-btn').on('click', function () {
        $.ajax({
            type: 'POST',
            url: deleteRateSystemUrl,
            data: { rateSystemId: selectedRateSystem.val() },
            success: function (questions) {
                $('#cancel-btn').trigger('click');
                $(selectedRateSystem)
                    .parent()
                    .remove();
            },
            error: function (ex) {

            }
        });
    });
}($));