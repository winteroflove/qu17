var activity_slide = function () {
    var root = $(".activity_slide"), images = $(root).find(".activity_images"), titles = $(root).find(".activity_titles");
    var total = $(images).find("li").length, isSliding = false, slideHandler = null;

    var timer;

    function slideTo(ordinal) {
        if (isSliding) return; var currentOrdinal = getCurrentOrdinal(), current = $(images).find("li").eq(currentOrdinal - 1); nextOrdinal = ordinal, next = $(images).find("li").eq(nextOrdinal - 1); isSliding = true; var $nextimg = $(next).find('img'), real_src; if (real_src = $nextimg.attr('data-src')) { $nextimg.attr('src', real_src); }
        $.when($(current).fadeOut(100), $(next).fadeIn(100)).done(function () { $(images).find("li").removeClass("current"); $(titles).find("a").removeClass("current"); isSliding = false; $(next).addClass("current"); $(titles).find("a").eq(nextOrdinal - 1).addClass("current"); });
    }

    function getCurrentOrdinal() { var current = $(images).find(".current"), currentOrdinal = $(current).prevAll().length + 1; return currentOrdinal; }

    function slidePrev() {
        var currentOrdinal = getCurrentOrdinal(); var prevOrdinal = 1; if (currentOrdinal == 1) { prevOrdinal = total; } else { prevOrdinal = currentOrdinal - 1; }
        slideTo(prevOrdinal);
    }

    function slideNext() { var currentOrdinal = getCurrentOrdinal(); var nextOrdinal = (currentOrdinal + 1) % total; slideTo(nextOrdinal); }

    $(root).hover(
function () { clearInterval(slideHandler); slideHandler = null; },
function () { slideHandler = setInterval(function () { slideNext(); }, 4000); });

    $(titles).on("mouseenter", "a", function () { var isCurrent = $(this).hasClass("current"); if (isCurrent) return; var nextOrdinal = $(this).prevAll().length + 1; clearTimeout(timer); timer = setTimeout(function () { slideTo(nextOrdinal); }, 50); });
    slideHandler = setInterval(function () { slideNext(); }, 5000);
}
var activity_artlist = function () {
    var o3 = document.getElementById('art_list');
    mr3 = window.setInterval(function () { scrollup(o3, 30, 40); }, 3000);
    function scrollup(o, d, c) {
        if (d <= c) {
            var t = o.firstChild.cloneNode(true);
            o.removeChild(o.firstChild);
            o.appendChild(t);
            t.style.marginTop = o.firstChild.style.marginTop = '0px';
        }
        else {
            var s = 1, c = c + s, l = (c >= d ? c - d : 0);
            o.firstChild.style.marginTop = -c + l + 'px';
            window.setTimeout(function () { scrollup(o, d, c - l) }, 1000);
        }
    }
}