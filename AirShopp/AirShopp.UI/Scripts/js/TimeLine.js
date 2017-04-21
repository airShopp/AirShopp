$(function() {
    var b = 0,
        f = $(".list li").length,
        d = 0,
        a = !0,
        c;

    (function() {
        var a = $(window).height();
        890 <= a && (row = 6);
        800 <= a && 890 > a && (row = 5);
        726 <= a && 800 > a && (row = 4);
        726 > a && (row = 3)
    })();

    var h = f - row;

    $(".list").height(60 * row);
    $("#content").height(60 * row + 25);

    $(".list").delegate(".liwrap", "mouseover", function(){
    	$(".list li").removeClass("thiscur");
        $(this).parent().addClass("thiscur")
    })
    $(".arrowdown").click(function() {
        h = refreshF() - row;
        a && parseInt($(".list li:first").css("marginTop")) > -60 * h && (d++, b--, a = !1, $(".list li:first").animate({ marginTop: 60 * b }, 600, "easeInOutQuad", function() {
            a = !0;
            $(".arrowdown").css("opacity", 1);
            $(".arrowdown").removeClass("arrow_active")
        }));
    });
    $(".arrowup").click(function() {
        h = refreshF() - row;
        a && 0 != parseInt($(".list li:first").css("marginTop")) && (b++, d--, a = !1, $(".list li:first").animate({ marginTop: 60 * b }, 600, "easeInOutQuad", function() {
            a = !0;
            $(".arrowup").css("opacity", 1);
            $(".arrowup").removeClass("arrow_active")
        }));
    });
    $(".list").mousewheel(function(b, c) {
        h = refreshF() - row;
        Math.abs(c);
        if (a) {
            var d = parseInt($(".list li:first").css("marginTop"));
            0 < c ? 0 != d && ($(".arrowup").addClass("arrow_active"), $(".arrowup").trigger("click")) : d > -60 * h && ($(".arrowdown").addClass("arrow_active"), $(".arrowdown").trigger("click"))
        }
    });
});

function refreshF() {
    return $(".list li").length;
}
