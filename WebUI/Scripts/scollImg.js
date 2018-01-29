var scollImg = function () {
    var taget = 0;
    var root = $(".info_img_small")
    var images = $(root).find("ul");
    var total = $(images).find("li").length;
    var btnPrev = $(root).find(".info_prev"), btnNext = $(root).find(".info_next");
    //if (total < 4) return;
    function slidePrev() {
        if (total < 4 || taget == 0) return;
        taget -= 1;
        $(images).css("top", "-" + taget * 80 + "px");
        $(btnNext).removeClass("inactive");
        if (taget == 0) $(btnPrev).addClass("inactive");
    }

    function slideNext() {
        if (total < 4 || taget + 3 >= total) return;
        taget += 1;
        $(images).css("top", "-" + taget * 80 + "px");
        $(btnPrev).removeClass("inactive");
        if (taget + 3 == total) $(btnNext).addClass("inactive");
    }
    $(btnPrev).on("click", function () { slidePrev(); });
    $(btnNext).on("click", function () { slideNext(); });
}