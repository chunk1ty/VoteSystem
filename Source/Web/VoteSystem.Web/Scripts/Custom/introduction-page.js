'use strict';

$('video').on('ended', function () {
    this.load();
    this.play();
});

/* affix the navbar after scroll below header */
$('#nav').affix({
    offset: {
        top: $('header').height() - $('#nav').height()
    }
});

/* highlight the top nav as scrolling occurs */
$('body').scrollspy({
    target: '#nav'
})

/* smooth scrolling for scroll to top */
$('.scroll-top').click(function () {
    $('body').animate({
        scrollTop: 0
    }, 500);
})

/* smooth scrolling for nav sections */
$('#nav .navbar-nav li>a').click(function () {
    //debugger;
    var link = $(this).attr('href');
    var posi = $(link).offset().top;

    $('body').animate({
        scrollTop: posi
    }, 500);
});