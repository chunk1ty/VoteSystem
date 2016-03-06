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
        oLanguage: {
            sSearch: "Search by all columns: "
        }
    });
}($));