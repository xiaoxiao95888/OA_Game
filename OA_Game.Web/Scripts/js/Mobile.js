var Mobile = {
    viewModel: {
        TotalCount: ko.observable(0),
        RequiredModel: {
            Phone: ko.observable(),
            Email: ko.observable()
        }
    }
};
Mobile.viewModel.GetCount = function () {
    $.get("/api/Required/", function (result) {
        Mobile.viewModel.TotalCount(result.TotalCount);
    });
}
Mobile.viewModel.Schedule = function (data, event) {
    
    var dom = $(event.target);
    dom.fadeOut(function () {
        $($("#book").prev()).fadeIn();
        $("#book").fadeIn();

    });
}
Mobile.viewModel.SubMit = function () {
    var model = ko.toJS(Mobile.viewModel.RequiredModel);
    if (model.Phone == null || model.Email == null) {
        alert("请填写完整");
    } else {
        $.post("/api/Required", model, function (result) {
            if (result.Error) {
                alert(result.Message);
            } else {
                Mobile.viewModel.GetCount();
                $("#book").hide();
                $("#TotalCount").show();
                
            }
        });
    }
};
$(function () {
    var swiper = new Swiper('.swiper-container', {
        pagination: '.swiper-pagination',
        slidesPerView: 2,
        paginationClickable: true,
        spaceBetween: 10,
        autoplay: 2500,
        autoplayDisableOnInteraction: false
    });
    $.ajax({
        type: "put",
        url: "/api/pv/",
        contentType: "application/json",
        dataType: "json",
        success: function () {
            $.get("/api/pv", function (count) {
                $("#pv").text("访问人数：" + count);
            });
        }
    });
    ko.applyBindings(Mobile);
    Mobile.viewModel.GetCount();
})