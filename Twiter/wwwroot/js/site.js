// Write your Javascript code.
$(document).ready(function () {

    //showPosts(post);

    $('#posts').on('mouseenter mouseleave', 'span', function () {
        divId = $(this).children('div').attr('id');
        if ($('#' + divId).hasClass('bg-info')) {
            $('#' + divId).removeClass('bg-info');
            $('#' + divId).addClass('bgColor');
        } else if ($('#' + divId).hasClass('bgColor')) {
            $('#' + divId).removeClass('bgColor');
            $('#' + divId).addClass('bg-info');
        }
    });

    $("[id^=post]").click(function (e) {
        $(e.target).toggleClass('toggle');
        e.preventDefault();
        $.ajax({

            url: $(this).attr("href"),
            success: function () {
                if ($(e.target).hasClass('unfollow')) {
                    $(e.target).hide();
                    $(e.target).hasClass('follow').show();
                } else if ($(e.target).hasClass('follow')) {
                    $(e.target).hide();
                    $(e.target).hasClass('unfollow').show();
                }                
            }

        });

    });
});

$.fn.extend({
    animateCss: function (animationName) {
        var animationEnd = 'webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend';
        $(this).addClass('animated ' + animationName).one(animationEnd, function () {
            $(this).removeClass('animated ' + animationName);
        });
    }
});

/*function showPosts(model) {
    model.forEach(function(obj, i) {         
        setTimeout(function () {
            var ymd = obj.postDate.slice(0, 10);
            var time = obj.postDate.slice(11, 19);
            $('#posts').append('<span><div class="row linkId bg-info" id="' + obj.postId + '"></div></span>');
            $('#' + obj.postId).animateCss('fadeInRight');
            $('#' + obj.postId).append('<h4 id="title">' + obj.postTitle + '</h4>');
            $('#' + obj.postId).append('<h4 id="data"><small>' + obj.postData + '</small></h4>');
            $('#' + obj.postId).append('<input type="button" value="Follow" onclick="' + "<%: Html.Action(\"AddUser\", \"Home\") %>" + '/><input type="hidden" name="posterName" value="' + obj.userName + '"/><h5 id="poster"><small><i>Posted by: ' + obj.userName +
                '<i></small></h5>  <h5 id="follow"><small><input type="submit" asp-action="Add" asp-controller="Home" value="Follow"/></small></h5></form><h6 id="date"><small>' +
                ymd + ', ' + time + ' UTC</small></h6>');
            $('#' + obj.postId).css('margin-bottom', '5px');
        }, i * 100);
    });
}*/