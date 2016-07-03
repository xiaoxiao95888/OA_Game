var Contact = {
    viewModel: {
        Name: ko.observable(),
        Email: ko.observable(),
        Phone: ko.observable(),
        Content: ko.observable(),
    }
};
Contact.viewModel.Submit = function () {
    var model = ko.mapping.toJS(Contact.viewModel);
    if (model.Name != null && model.Name != "") {
        $.ajax({
            type: "POST",
            url: "/api/Contact/",
            contentType: "application/json",
            data: JSON.stringify(model),
            dataType: "json",
            success: function (result) {
                if (!result) {
                    alert(result.Message);
                } else {
                    $(".btn").hide();
                    alert("非常感谢您的留言！");
                }
            }
        });
    } else {
        alert("姓名必填");
    }

};
$(function () {
    ko.applyBindings(Contact);
})