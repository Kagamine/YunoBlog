var blog = window.blog = {
    autoHighlight: function () {
        if (window.enable_autoHighlight == undefined) {
            window.enable_autoHighlight = false
        }
        if (!window.enable_autoHighlight) {
            return
        }
        var a = null;
        $(window).scroll(function () {
            var c = $(window).scrollTop();
            var b = $(window).height();
            $(window.enable_autoHighlight).each(function () {
                var d = c + (b * 0.35);
                if (d > $(this).offset().top && d < $(this).offset().top + $(this).height()) {
                    if (a !== null) {
                        a.removeClass("active")
                    }
                    a = $(this).addClass("active");
                    return false
                }
            })
        }).scroll()
    },
    init: function () {
        var a = blog;
        a.autoHighlight();
    }
};
$(document).ready(function () {
    blog.init()
});