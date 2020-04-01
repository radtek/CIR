function SynchronizationProgressController(cirId, observer) {
    var interval = null;

    return {
        start: function () {
            var that = this;

            interval = setInterval(function() {
                cirOfflineApp.GetCirImageBlobList(cirId).done(function(row) {
                    observer(row.initialCount, row.blobList.length, cirId, this);
                }).fail(function() {
                    observer(0, 0, cirId, that);
                });
            }, 1000);
        },

        stop: function() {
            clearInterval(interval);
        }
    };
}
