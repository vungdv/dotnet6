// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('.input').on('change', function (event) {
    var form = $(event.target).parents('form');

    form.submit();
});