function ComponentSidesController(pixelMatrix, transparentColor) {
    var canvas = null;
    var modal = null;
    var currentLabelAt = null;
    var exportHandler = null;
    var sidesData = {};

    function exportData() {
        var data = {};

        for (var key in sidesData) {
            if (!sidesData.hasOwnProperty(key)) {
                continue;
            }

            data[key.toString()] = {
                side: sidesData[key].side,
                x: sidesData[key].x,
                y: sidesData[key].y
            };
        }

        exportHandler(data);
    }

    return {
        currentSide: '0',
        currentX: null,
        currentY: null,
        currentColor: null,

        init: function (canvasEl, exporter) {
            canvas = canvasEl;
            modal = document.getElementById('sides-modal');
            exportHandler = exporter;
        },

        saveSide: function () {
            if (this.currentSide === '0' || this.currentX === null || this.currentY === null) {
                return;
            }

            sidesData[this.currentColor] = {
                side: this.currentSide,
                x: this.currentX,
                y: this.currentY
            };

            this.discardModal();
            exportData();
        },

        removeSide: function(event) {
            if (this.currentColor === null) {
                this.discardModal();

                return;
            }

            delete sidesData[this.currentColor];

            exportData();
            this.discardModal();
        },

        discardModal: function () {
            modal.style.display = 'none';
            this.currentSide = '0';
            this.currentX = null;
            this.currentY = null;
            this.currentColor = null;
        },

        putOrEditSideInfo: function (event) {
            var coords = canvasUtils.relMouseCoords(event, canvas);
            var color = pixelMatrix.findColorAt(coords.x, coords.y);

            if (color === transparentColor) {
                return;
            }
            
            currentLabelAt = coords;
            this.currentColor = color;
            modal.style.display = 'block';
            modal.style.left = currentLabelAt.x + 'px';
            modal.style.top = (parseInt(currentLabelAt.y - modal.offsetHeight / 2)) + 'px';

            if (sidesData[color]) {
                this.currentSide = sidesData[color].side;
                this.currentX = sidesData[color].x;
                this.currentY = sidesData[color].y;
            }
        }
    };
}
