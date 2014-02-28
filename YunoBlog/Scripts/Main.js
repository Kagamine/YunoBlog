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
var lock = false;

function LoadArticles() {
    if (lock) return;
    lock = true;
    $.getJSON("Ajax/Articles.GetList.aspx", {
        Page: page,
        Year: year,
        Month: month
        }, function (data) {
            for (var i in data)
            {
                var article = "<div class='article'><div class='header'><div class='title'><a href='Article.aspx?src={Article_Title_Url}'>{Article_Title}</a></div><div class='info info1'><span class='time'>{Article_CreationTime}</span></div></div><div class='section entry'>{Article_Html}{Article_More}</div></div>"
                .replace("{Article_Title_Url}", encodeURIComponent(data[i].Title))
                .replace("{Article_Title}", data[i].Title)
                .replace("{Article_CreationTime}", data[i].CreationTimeAsString)
                .replace("{Article_Html}", data[i].Summary)
                .replace("{Article_More}", data[i].Lines < 10 ? "" : "<p><a href='Article.aspx?src={Article_Title_Url}' class='more-link'>(更多&#8230;)</a></p>")
                $("#main").append(article);
                
            }
            page++;
            lock = false;
        });
}

$(document).ready(function () {
    blog.init()
    $.getJSON("Scripts/Links.js", {}, function (data) {
        for (var i in data) {
            $(".xoxo").append('<li><a href="' + data[i].url + '" target="_blank">' + data[i].title + '</a></li>');
        }
    });
    if (typeof (ArticleList) != "undefined")
    {
        LoadArticles();
        $(window).scroll(function () {
            totalheight = parseFloat($(window).height()) + parseFloat($(window).scrollTop());
            if ($(document).height() <= totalheight) {
                LoadArticles();
            }
        });
    }
});