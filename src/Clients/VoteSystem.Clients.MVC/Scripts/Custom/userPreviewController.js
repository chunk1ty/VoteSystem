$(function ($) {
    "use strict";

    //grid settings
    var table = $('#user-preview-grid').DataTable({
        columnDefs: [{
            targets: [0],
            searchable: true,
            sortable: true
        }, {
            targets: [1],
            searchable: true,
            sortable: true
        }, {
            targets: [2],
            searchable: true,
            sortable: true
        }, {
            targets: [3],
            searchable: true,
            sortable: true
        }],
        pagingType: "full_numbers",
        aaSorting: [],
        language: {
            search: "Търсене по колони: ",
            info: "Страница _PAGE_ от _PAGES_ страници.",
            lengthMenu: "Покажи _MENU_ потребителя.",
            emptyTable: "Няма налични потребители.",
            paginate: {
                first: "Първа",
                last: "Последна",
                next: "Следваща",
                previous: "Предишна"
            },
        }
    });
}($));