$(function () {
    //בעת לחיצה על הפקדים למעלה,
    //תהפוך את יתר הפקדים ללא אקטיבים, ואת הפקד הספציפי שתפסנו תהפוך לאקטיבי
    $('.navbar-inverse .navbar-brand , .navbar-inverse .navbar-nav > li > a, .connect').click(function () {
        $('.navbar-inverse .navbar-brand , .navbar-inverse .navbar-nav > li > a, .connect').parent().removeClass('active');
        $(this).parent().addClass('active');
    });

    // POST BACK SITUATION
    var splittedPathArr = window.location.pathname.split("/");
    var arrMenuPath = splittedPathArr.slice(1, 3);
    var relativeMenuPath = "/" + arrMenuPath.join("/");
 
    if (window.location.pathname == '/')
        relativeMenuPath = '/Home';

    $("li > a[href*='" + relativeMenuPath + "']").parent().addClass('active');
    //$("a[href*='" + relativeMenuPath + "'].connect").css('color', 'white');

});

          
