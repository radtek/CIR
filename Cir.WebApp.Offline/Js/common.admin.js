// Convert to Seo URL
String.prototype.toSeoURL = function () {
    // make the url lowercase
    var str = $.trim(this.toLowerCase());
    // replace & with and
    str = str.replaceAll("&", "and");// replace(/&/g, "and");
    // remove characters
    str = str.replaceAll("'", "");
    // remove invalid characters
    str = str.replace(/[^a-z0-9 ]/gi, "");
    str = str.replaceAll(" ", "-");
    // remove duplicates
    str = str.replaceAll("--", "-");
    return str;
};
//Replace all helper
String.prototype.replaceAll = function (oldString, newString) {
    return this.replace(new RegExp(oldString, "g"), newString);
};

//admin data validation
function enableValidation() {
    $('form').submit(function () {
        if ($(this).valid()) {
            $(this).find('div.form-group').each(function () {
                if ($(this).find('span.field-validation-error').find("span").length == 0) {
                    $(this).removeClass('has-error');
                }
            });
        }
        else {
            $(this).find('div.form-group').each(function () {
                if ($(this).find('span.field-validation-error').find("span").length > 0) {
                    $(this).addClass('has-error');
                } else {
                    $(this).removeClass('has-error');
                }
            });
        }
    });
    $('form').each(function () {
        $(this).find('div.form-group').each(function () {
            if ($(this).find('span.field-validation-error').find("span").length > 0) {
                $(this).addClass('has-error');
            }
        });
    });
}


