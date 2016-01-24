//window.onload = hideLongContet;

//function hideLongContet() {
//    var newsList = $(".newsContent");

//    for (var i = 0; i < newsList.length; i++) {
//        if (newsList[i].innerText.length >= 500) {
//            newsList[i].innerText = newsList[i].innerText.substring(0, 500) + "(...)";
//        }
//    }
//}

$(window).on("scroll", function () {
    $('navbar-brand').addClass('shrink');
});
$(window).on("scrollstop", function () {
    $('navbar-brand').removeClass('shrink');
}); 