$(document).ready(function(){
    if ($(window).width() >= 992){
    $(".search-div-visible").click(function(){
        $(".header-nav-search").hide();
        $(".header-nav-menu").hide();
        $(".header-nav-lang").hide();
        $(".search-div-hidden").css("display","flex");
        $(".search-div-hidden").css("width","100%");
        $(".search-div-hidden").css("justify-content","space-between");
        $("input#search-input").focus();
    })};
});
$(document).ready(function(){
    if ($(window).width() >= 992){
    $(".close-button").click(function(){
        $(".header-nav-search").show();
        $(".header-nav-menu").show();
        $(".header-nav-lang").show();
        $(".search-div-hidden").hide();
        $(".header-nav-search").css("margin","none");
    })};
});
$(document).ready(function(){
    if ($(window).width() >= 992){
    $("#search-input").focusout(function(){
        $(".header-nav-search").show();
        $(".header-nav-menu").show();
        $(".header-nav-lang").show();
        $(".search-div-hidden").hide();
        $(".header-nav-search").css("margin","none");
    })};
});



$(document).ready(function(){
    if ($(window).width() < 992){
         $(".search-div-visible").click(function(){
        $(".header-nav-search").hide();
        $(".search-div-hidden").css("display","flex");
        $(".search-div-hidden").css("width","90%");
        $(".search-div-hidden").css("justify-content","space-between");
        $("input#search-input").focus();
    })};
});
$(document).ready(function(){
    if ($(window).width() < 992){
    $(".close-button").click(function(){
        $(".header-nav-search").show();
        $(".search-div-hidden").hide();
        $(".header-nav-search").css("margin","none");
    })};
});
$(document).ready(function(){
    if ($(window).width() < 992){
    $("#search-input").focusout(function(){
        $(".header-nav-search").show();
        $(".search-div-hidden").hide();
        $(".header-nav-search").css("margin","none");
    })};
});

