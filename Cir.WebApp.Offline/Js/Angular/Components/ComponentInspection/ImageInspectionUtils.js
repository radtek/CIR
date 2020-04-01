var ImageInspectionUtils = {
    getNowDateStr: function() {
        var now = new Date();
        var d = now.getDate();
        var m = now.getMonth() + 1;
        var hours = now.getHours();
        var minutes = now.getMinutes();
        var ampm = hours >= 12 ? 'pm' : 'am';
        var y = now.getFullYear();

        if (d < 10) {
            d = '0' + d;
        }
        if (m < 10) {
            m = '0' + m;
        }

        var date = y + '-' + m + '-' + d;

        hours = hours % 12;
        hours = hours ? hours : 12;
        minutes = minutes < 10 ? '0' + minutes : minutes;

        return date + ' ' + hours + ':' + minutes + ' ' + ampm;
    }
};
