// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var dataTable;

$(document).ready(function () {
    function loadDataTable() {
        dataTable = $('#tblData').DataTable({
            "ajax": {
                "url": "/Admin/Category/GetAll"
            },
            "columns": [
                { "data": "name", "width": "60%" },
                {
                    "data": "id",
                    "reder": function (data) {
                        return
                        `
                            <div class="text-center">
                                <a href="/Admin/Category/Upsert/$(data)" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i>&nbsp;
                                 </a>
                                <a onclick=Delete("/Admin/Category/Delete/$(data)") class="btn btn-danger text-white" style="cusrsor:pointer">
                                     <i class=" fas fa-trash-alt"></i>&nbsp;
                                </a>
                            </div>
                                `;
                    }, "width": "40%"
                }
            ]
        });
    }
    function Delete(url) {
        swal({
            title: "Are you sure you want to delete?",
            text: "You will not be able to retore data!",
            icon: "Warning",
            buttons: true,
            dangerMode: true
        }).then(willDelete) => {
            if (willDelete) {
                $.ajax({
                    type: "DELETE",
                    url: url,
                    success: function (data) {
                        if (data.success) {
                            toastr.success(data.message);
                            dataTable.ajax.reload();
                        } else {
                            toastr.error(data.message);
                        }
                    }
                });
            }
        }
    }
});