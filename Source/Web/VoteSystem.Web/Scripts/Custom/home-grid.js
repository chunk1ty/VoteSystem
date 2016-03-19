$(function ($) {
    "use strict";

    $(document).ready(function () {
        $('#example').dataTable({
            columnDefs: [{
                targets: [0],
                searchable: false,
                sortable: false
            }, {
                targets: [1]
            }, {
                targets: [2],
                searchable: false,
                sortable: false
            }, {
                targets: [3],
                searchable: false
            }],
            pagingType: "full_numbers",
            oLanguage: {
                sSearch: "Search by vote system name: "
            }
        });
    });
}($));