// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('.myTable').DataTable({
        responsive: true,
        scrollX: true
    });

    $('.dt-search label').html("Arama: ")

    window.addEventListener('load', function () {
        document.getElementById('uploadImage').addEventListener('change', function () {
            if (this.files && this.files[0]) {
                var img = document.getElementById('image'); // $('img')[0]
                img.src = URL.createObjectURL(this.files[0]); // set src to file url
            }
        });
    });

    setTimeout(() => {
        $(".notification").fadeOut("slow")
    }, 6000)
});

