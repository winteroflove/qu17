
function $$(id) { return document.getElementById(id); }
function menuToggle(o) {
    if ($(o).html() == "+ 全部展开") {
        $(o).html("- 全部收缩");
        $(".bigMenu").next().slideDown("fast");
    }
    else {
        $(o).html("+ 全部展开");
        $(".bigMenu").next().slideUp("fast");
    }
}

$(document).ready(function() {

    if (document.getElementById("menu")) {
        $(".bigMenu").next().hide();
        $(".bigMenu").bind("click", function() {
            $(this).next().slideToggle("fast");
        });
        $(".bigMenu").each(function() {
            $(this).bind("click", function() {
                $(".bigMenu").removeClass("selected");
                $(this).addClass("selected");
            });
        });
        $("#slide li ul li a").each(function() {
            $(this).bind("click", function() {
                $("#slide li ul li a").removeClass("on");
                $(this).addClass("on");
            });
        });
    }

});

