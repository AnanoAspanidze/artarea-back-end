$(function () {
   

    var url = window.location.pathname;
    var activePage = url.substring(url.lastIndexOf('/') + 1);
    $('#header-nav-menu li a').each(function () {
        var currentPage = this.href.substring(this.href.lastIndexOf('/') + 1);

        if (activePage == currentPage) {
            $(this).parent().addClass('active');
        }
    });


    var url = window.location.pathname;
    var activePage = url.substring(url.lastIndexOf('/') + 1);
    $('#filter li a').each(function () {
        var currentPage = this.href.substring(this.href.lastIndexOf('/') + 1);

        if (activePage == currentPage) {
            $(this).parent().addClass('active');
        }
    });

});