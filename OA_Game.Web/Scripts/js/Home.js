var isMobile = {
    Android: function () {
        return navigator.userAgent.match(/Android/i) ? true : false;
    },
    BlackBerry: function () {
        return navigator.userAgent.match(/BlackBerry/i) ? true : false;
    },
    iOS: function () {
        return navigator.userAgent.match(/iPhone|iPad|iPod/i) ? true : false;
    },
    Windows: function () {
        return navigator.userAgent.match(/IEMobile/i) ? true : false;
    },
    any: function () {
        return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Windows());
    }
};
if (isMobile.any()) {
    location.href = "../Mobile/Index";
}

var Home = {
    viewModel: {
        TotalCount: ko.observable(0),
        RequiredModel: {
            Phone: ko.observable(),
            Email: ko.observable()
        },
        Articles: ko.observableArray(),
        Article: {
            Id: ko.observable(),
            Title: ko.observable(),
            Description: ko.observable(),
            Content: ko.observable(),
            ThumbnailUrl: ko.observable(),
            ArticleCategoryId: ko.observable(),
            IsDeleted: ko.observable()
        }
    }
};
ko.bindingHandlers.date = {
    update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
        var value = valueAccessor();
        var allBindings = allBindingsAccessor();
        var valueUnwrapped = ko.utils.unwrapObservable(value);

        // Date formats: http://momentjs.com/docs/#/displaying/format/
        var pattern = allBindings.format || "YYYY/MM/DD";

        var output = "-";
        if (valueUnwrapped !== null && valueUnwrapped !== undefined && valueUnwrapped.length > 0) {
            output = moment(valueUnwrapped).format(pattern);
        }

        if ($(element).is("input") === true) {
            $(element).val(output);
        } else {
            $(element).text(output);
        }
    }
};
Home.viewModel.ArticleDetail = function () {
    var model = ko.mapping.toJS(this);
    ko.mapping.fromJS(model, {}, Home.viewModel.Article);
    $("#article-dialog").modal({
        keyboard: false,
        show: true,
        backdrop: "static"
    });
}
Home.viewModel.GetCount = function () {
    $.get("/api/Required/", function (result) {
        Home.viewModel.TotalCount(result.TotalCount);
    });
}
Home.viewModel.Schedule = function (data, event) {
    var dom = $(event.target);
    dom.fadeOut(function () {
        $($("#book").prev()).fadeIn();
        $("#book").fadeIn();

    });
}
Home.viewModel.SubMit = function () {
    var model = ko.toJS(Home.viewModel.RequiredModel);
    if (model.Phone == null || model.Email == null) {
        alert("请填写完整");
    } else {
        $.post("/api/Required", model, function (result) {
            if (result.Error) {
                alert(result.Message);
            } else {
                Home.viewModel.GetCount();
                $("#book").hide();
                $("#TotalCount").show();
                alert("预定成功");
            }
        });
    }
};
Home.viewModel.GetArticles = function () {
    $.get("/api/Article", function(result) {
        ko.mapping.fromJS(result, {}, Home.viewModel.Articles);
    });
}
$(function () {
    $('#slider1').tinycarousel();    
    $('#slider1').rebox({ selector: 'li a' });
    ko.applyBindings(Home);
    Home.viewModel.GetCount();
    Home.viewModel.GetArticles();
})