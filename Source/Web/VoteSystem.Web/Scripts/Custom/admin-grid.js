$(function ($) {
    "use strict";
 
    $('#admin-grid').dataTable({
        pagingType: "full_numbers",
        "oLanguage": {
            "sSearch": "Search by System name: "
        },
        columnDefs: [{
            targets: [0]
        }, {
            targets: [1],
            "sortable": false
        }, {
            targets: [2],
            "searchable": false,
            "sortable": false
        }, {
            targets: [3],
            "searchable": false,
            "sortable": false
        }]
    });
}($));