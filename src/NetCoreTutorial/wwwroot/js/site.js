﻿//site.js
(function () {

    //var ele = $("#username");// document.getElementById("username");
    //ele.text("Pp Mtz2");//ele.innerHTML = "Pp Mtz";

    //var main = $("#main");//document.getElementById("main");
    //main.on("mouseenter", function () {
    //    main.style= "background-color: #888;";
    //});

    //main.on("mouseleave", function () {
    //    main.style= "";
    //});

    //var menuItems = $("ul.menu li a");
    //menuItems.on("click", function () {
    //    var me = $(this);
    //    alert(me.text());
    //});

    //var $sidebarAndWrapper = $("#sidebar, #wrapper");

    //$("#sidebarToogle").on("click", function () {
    //    $sidebarAndWrapper.toggleClass("hide-sidebar");
    //});

    var $sidebarAndWrapper = $("#sidebar, #wrapper");
    var $icon = $("#sidebarToggle i.fa");


    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa fa-angle-left");
            $icon.addClass("fa fa-angle-right");
        }
        else {
            $icon.removeClass("fa fa-angle-right");
            $icon.addClass("fa fa-angle-left");
        }
    });
    
})();




