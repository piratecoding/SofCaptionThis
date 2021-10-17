$(function () {
    $("#cat-form").submit(function (e) {
        e.preventDefault();

        var form = $(this);

        $.ajax({
            method: "POST",
            url: $("CaptionUrl").val(),
            data: form.serialize(),
            success: function (response) {
                if (response.success) {
                    alert(response.responseText);
                } else {
                    alert(response.responseText);
                }
            },
            error: function () {
                alert("Something went wrong.");
            }
        })
    })
});