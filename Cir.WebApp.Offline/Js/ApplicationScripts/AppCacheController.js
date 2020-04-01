
(function () { if (!/*@cc_on!@*/0) return; var e = "abbr,article,aside,audio,bb,canvas,datagrid,datalist,details,dialog,eventsource,figure,footer,header,hgroup,mark,menu,meter,nav,output,progress,section,time,video".split(','), i = e.length; while (i--) { document.createElement(e[i]) } })();



window.applicationCache.onchecking = function (e) {
    updateCacheStatus('Checking for a new version of the application.');
};
window.applicationCache.ondownloading = function (e) {
    updateCacheStatus('Downloading a new offline version of the application');
};
window.applicationCache.oncached = function (e) {
    updateCacheStatus('The application is available offline.');
    UserCachingController.Login();
};
window.applicationCache.onerror = function (e) {
    updateCacheStatus('Something went wrong while updating the offline version of the application. It will not be available offline.');
    UserCachingController.Login();
};
window.applicationCache.onupdateready = function (e) {
    window.applicationCache.swapCache();
    updateCacheStatus('The application was updated.');
    UserCachingController.Login();
};
window.applicationCache.onnoupdate = function (e) {
    $('#cirProcessingSection .progress-bar').css('width', 100 + '%').attr('aria-valuenow', 100);
    updateCacheStatus('The application is ready for offline use.');
    UserCachingController.Login();
};
window.applicationCache.onobsolete = function (e) {
    updateCacheStatus('The application can not be updated, no manifest file was found.');
    UserCachingController.Login();
};
window.applicationCache.onprogress = function (e) {
    var message = 'Downloading offline resources.. ';
    if (e.lengthComputable) {
        $('#cirProcessingSection .progress-bar').css('width', Math.round(e.loaded / e.total * 100) + '%').attr('aria-valuenow', Math.round(e.loaded / e.total * 100));
    }
    updateCacheStatus(message);
};



