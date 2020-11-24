$(document).ready(function () {
    console.log("ready!");
    $('.laguage-item').click(function (e) {
        var domainUrl = window.location.origin;
        var language = $(this).attr("data-value");
        $.ajax({
            method: "POST",
            url: domainUrl + "/Forms/SwitchLanguage",
            data: { language: language }
        }).done(function (response) {
            console.log(response)
            if (response !== null && response.status) {
                uri = $(location).attr('href').toString();
                if (response.previousLanguage !==null && response.previousLanguage !== '') {
                    uri = uri.replace(response.previousLanguage, language);
                } else {
                    uri = uri.replace(domainUrl, domainUrl + '/en');
                }
                window.location.href = uri;
                //location.reload();
            }
        });
    });
});