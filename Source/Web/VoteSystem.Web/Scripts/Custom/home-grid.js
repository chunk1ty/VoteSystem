$(function ($) {
    "use strict";

    $('#example').dataTable({
        pagingType: "full_numbers",
        search: "Search all columns:",
        "oLanguage": {
            "sSearch": "Search by Name: "
        },
        columnDefs: [{
            targets: [0],
            "searchable": false,
            "sortable": false
        }, {
            targets: [1]
        }, {
            targets: [2],
            "searchable": false,
            "sortable": false
        }, {
            targets: [3],
            "searchable": false
        }]
    });
}($));