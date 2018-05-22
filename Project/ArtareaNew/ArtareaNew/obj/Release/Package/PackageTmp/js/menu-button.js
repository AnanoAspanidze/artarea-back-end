$(document).ready(function(){
    $(".menu-button-responsive").click(function(){
        $(".header-nav-menu-responsive").slideToggle();
        $("#bar1").toggleClass("active");
 		$("#bar2").toggleClass("active");
  		$("#bar3").toggleClass("active");
    });
});
// $(document).ready(function(){
//     $(".menu-button-responsive").focusout(function(){
//         $(".header-nav-menu-responsive").slideToggle();
//         $("#bar1").toggleClass("active");
//  		$("#bar2").toggleClass("active");
//   		$("#bar3").toggleClass("active");
//     });
// });
$(document).ready(function(){
    $("#open-button").click(function(){
        $(".left-navigation").animate({width:"toggle"});
        $(".left-navigation").css("background","white");
        $(".left-navigation").css("z-index","2");
        $(".left-navigation").css("display","flex");
        $(".left-navigation").css("justify-content","center");
        $(".left-navigation").css("text-align","center");
        $("#close-button").show();
        $("#open-button").hide();
        $(".left-navigation").attr("id","affix4");
    });
});
$(document).ready(function(){
    $("#close-button").click(function(){
        $(".left-navigation").hide();
        $(".left-navigation").css("background","none");
        $(".left-navigation").css("justify-content","flext-start");
        $(".left-navigation").css("text-align","left");
        $("#close-button").hide();
        $("#open-button").show();
        $(".left-navigation").attr("id","affix3");
    });
});