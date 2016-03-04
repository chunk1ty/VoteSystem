$(function ($) {
    "use strict";
   
    //grid settings
    var table = $('#user-grid').DataTable({
        columnDefs: [{
            targets: [0],
            searchable: false,
            orderable: false,
            className: 'dt-body-center',
            //render: function (data, type, full, meta) {
            //    return '<input type="checkbox" class="tableflat" name="id[]" value="'
            //        + $('<div/>').text(data).html() + '">';
            //}
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
        }, {
            targets: [4],
            searchable: true,
            sortable: true
        }],
        pagingType: "full_numbers",
        aaSorting: [],
        oLanguage: {
            sSearch: "Search by all columns: "
        }
    });
    
    $('#example-select-all').on('click', function () {      
        var rows = table
            .rows({ 'search': 'applied' })
            .nodes();

        $('input[type="checkbox"]', rows).prop('checked', this.checked);
    });
   
    // Handle click on checkbox to set state of "Select all" control
    $('#user-grid tbody').on('change', 'input[type="checkbox"]', function () {          
        if (!this.checked) {
            var el = $('#example-select-all').get(0);   
            if (el && el.checked && ('indeterminate' in el)) {
                el.indeterminate = true;
            }
        }
    });

    // Handle form submission event
    $('#frm-example').on('submit', function (e) {
        var form = this;

        // Iterate over all checkboxes in the table
        table.$('input[type="checkbox"]').each(function () {
            // If checkbox doesn't exist in DOM
            if (!$.contains(document, this)) {
                // If checkbox is checked
                if (this.checked) {
                    // Create a hidden element 
                    $(form).append(
                       $('<input>')
                          .attr('type', 'hidden')
                          .attr('name', this.name)
                          .val(this.value)
                    );
                }
            }
        });
    });
}($));