var Admin = {
    viewModel: {
        ArticleCategorys: ko.observableArray(),
        ArticleCategory: ko.observable(),
        Articles: ko.observableArray(),
        Article: {
            Id: ko.observable(),
            Title: ko.observable(),
            Description: ko.observable(),
            Content: ko.observable(),
            ThumbnailUrl: ko.observable(),
            ArticleCategoryId: ko.observable(),
            IsDeleted: ko.observable()
        },
        Requireds: {
            RequiredModels: ko.observableArray(),
            TotalCount: ko.observable()
        },
        Setting: {
            Id: ko.observable(),
            VideoUrl: ko.observable()
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
Admin.viewModel.LoadArticle = function () {
    $.get("/api/Article", function (articles) {
        ko.mapping.fromJS(articles, {}, Admin.viewModel.Articles);
    })
}
Admin.viewModel.Create = function () {
    var model = {
        Id: "",
        Title: "",
        Description: "",
        Content: "",
        ThumbnailUrl: "",
        ArticleCategoryId: "",
        IsDeleted: false
    };
    ko.mapping.fromJS(model, {}, Admin.viewModel.Article);
    CKEDITOR.instances.content.setData(model.Content);
    $("#article-dialog").modal({
        keyboard: false,
        show: true,
        backdrop:"static"
    });
};
Admin.viewModel.Edit = function () {
    var model = ko.mapping.toJS(this);
    ko.mapping.fromJS(model, {}, Admin.viewModel.Article);
    ko.utils.arrayForEach(Admin.viewModel.ArticleCategorys(), function (item) {
        if (item.Id() === model.ArticleCategoryId) {
            Admin.viewModel.ArticleCategory(item);
        }
    });
    CKEDITOR.instances.content.setData(model.Content);
    $("#article-dialog").modal({
        keyboard: false,
        show: true,
        backdrop: "static"
    });
};
Admin.viewModel.Save = function () {
    var model = ko.mapping.toJS(Admin.viewModel.Article);
    if (model.Id == null || model.Id == "") {
        Admin.viewModel.PostArticle();
    } else {
        Admin.viewModel.PutArticle();
    }
};
Admin.viewModel.PostArticle = function () {
    var model = ko.mapping.toJS(Admin.viewModel.Article);
    var category = ko.mapping.toJS(Admin.viewModel.ArticleCategory);
    model.ArticleCategoryId = category.Id;
    model.Content = CKEDITOR.instances.content.getData();
    $.ajax({
        type: "POST",
        url: "/api/Article/",
        contentType: "application/json",
        data: JSON.stringify(model),
        dataType: "json",
        success: function (result) {
            if (result.Error) {
                alert(result.Message);
            } else {
                Admin.viewModel.LoadArticle();
                $("#article-dialog").modal("hide");
                alert("操作成功");
            }            
        }
    });
};
Admin.viewModel.PutArticle = function () {
    var model = ko.mapping.toJS(Admin.viewModel.Article);
    model.Content = CKEDITOR.instances.content.getData();
    var category = ko.mapping.toJS(Admin.viewModel.ArticleCategory);
    model.ArticleCategoryId = category.Id;
    $.ajax({
        type: "PUT",
        url: "/api/Article/",
        contentType: "application/json",
        data: JSON.stringify(model),
        dataType: "json",
        success: function (result) {
            if (result.Error) {
                alert(result.Message);
            } else {
                $("#article-dialog").modal("hide");
                Admin.viewModel.LoadArticle();
                alert("操作成功");
            }
        }
    });
};
Admin.viewModel.Delete= function () {
    var model = ko.mapping.toJS(Admin.viewModel.Article);
    $.ajax({
        type: "DELETE",
        url: "/api/Article/" + model.Id,
        contentType: "application/json",       
        dataType: "json",
        success: function (result) {
            if (result.Error) {
                alert(result.Message);
            } else {
                Admin.viewModel.LoadArticle();
                alert("操作成功");
            }
        }
    });
}
Admin.viewModel.GetRequired = function () {
    $.get("/api/Required/", function (data) {
        ko.mapping.fromJS(data, {}, Admin.viewModel.Requireds);
        alert("完成");
    })
}
Admin.viewModel.SaveSetting = function () {
    var model = ko.mapping.toJS(Admin.viewModel.Setting);
    $.ajax({
        type: "PUT",
        url: "/api/Setting/",
        contentType: "application/json",
        data: JSON.stringify(model),
        dataType: "json",
        success: function (result) {
            if (result.Error) {
                alert(result.Message);
            } else {
                $("#article-dialog").modal("hide");           
                alert("操作成功");
            }
        }
    });
}
$(function () {    
    ko.applyBindings(Admin);
    $.get("/api/ArticleCategory", function (categorys) {
        ko.mapping.fromJS(categorys, {}, Admin.viewModel.ArticleCategorys);
        $.get("/api/Article", function (articles) {
            ko.mapping.fromJS(articles, {}, Admin.viewModel.Articles);
            CKEDITOR.replace('content', {
                // Load the German interface.
                language: 'zh-cn',
            });
        })
    })
    $.get("/api/Required/", function (data) {
        ko.mapping.fromJS(data, {}, Admin.viewModel.Requireds);
    })
    $.get("/api/Setting/", function (data) {
        ko.mapping.fromJS(data, {}, Admin.viewModel.Setting);
    })
})