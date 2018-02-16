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
