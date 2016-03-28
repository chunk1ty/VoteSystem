$(function ($) {
    "use strict";

    var selectedRateSystem,
        deleteRateSystemUrl = $('#delete-rate-system-url').val();

    //grid settings
    $('#admin-grid').dataTable({
        columnDefs: [{
            targets: [0],
            searchable: false,
        }, {
            targets: [1],
        }, {
            targets: [2],
            searchable: false,
            sortable: false
        }, {
            targets: [3],
            searchable: false,
            sortable: false
        }, {
            targets: [4],
            searchable: false,
            sortable: false
        }],
        pagingType: "full_numbers",
        language: {
            search: "Търсене по име на система: ",
            info: "Страница _PAGE_ от _PAGES_ страници.",
            lengthMenu: "Покажи _MENU_ системи.",
            paginate: {
                first: "Първа",
                last: "Последна",
                next: "Следваща",
                previous: "Предишна"
            },
        }
    });

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
                alert('Can not delete rate system!');
            }
        });
    });
}($));