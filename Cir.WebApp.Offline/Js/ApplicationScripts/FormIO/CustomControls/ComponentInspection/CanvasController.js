function CanvasController(pixelMatrix, transparencyColor) {
    var canvas = null;
    var canvasWrapper = null;
    var currentPoints = [];
    var pointElements = [];
    var undoList = [];
    var originalColor = 0;
    var hoverColor = '#0094FF';
    var averageColor = null;
    var exportHandler = null;
    var canvasRegions = CanvasRegions(hoverColor, transparencyColor);

    function exportData() {
        exportHandler({
            color: averageColor,
            pixels: pixelMatrix.value()
        });
    }

    function detectAverageColor() {
        var data = canvas.getContext('2d').getImageData(0, 0, canvas.width, canvas.height);
        var length = data.data.length;
        var count = 0;
        var i = -4;
        var blockSize = 5;
        var rgb = { r: 0, g: 0, b: 0 };

        while ((i += blockSize * 4) < length) {
            if (data.data[i + 3] < 255) {
                continue;
            }

            ++count;
            rgb.r += data.data[i];
            rgb.g += data.data[i + 1];
            rgb.b += data.data[i + 2];
        }

        // ~~ used to floor values
        rgb.r = ~~(rgb.r / count);
        rgb.g = ~~(rgb.g / count);
        rgb.b = ~~(rgb.b / count);

        return rgb;
    }

    function removeLastPoints() {
        if (pointElements.length === 0) {
            return;
        }
        for (var i = 0; i < pointElements[pointElements.length - 1].length; i++) {
            canvasWrapper.removeChild(pointElements[pointElements.length - 1][i]);
        }
    }

    function normalizePoints() {
        var ctx = canvas.getContext('2d');
        var pixels = ctx.getImageData(0, 0, canvas.width, canvas.height).data;

        currentPoints[0] =
            canvasUtils.nearestTransparentPoint(pixels,
                currentPoints[0],
                canvas.width,
                canvas.height);
        currentPoints[currentPoints.length - 1] =
            canvasUtils.nearestTransparentPoint(pixels,
                currentPoints[currentPoints.length - 1],
                canvas.width,
                canvas.height);
    }
    
    function drawCurve() {
        var ctx = canvas.getContext('2d');
        var modifiers = [1, -1, 2, -2];

        ctx.save();

        ctx.globalCompositeOperation = 'destination-out';
        ctx.fillStyle = 'rgba(0,0,0,0)';

        canvasUtils.bezierCurveThrough(ctx, currentPoints);

        for (var i = 0; i < modifiers.length; i++) {
            canvasUtils.bezierCurveThrough(ctx,
                currentPoints.map(function (point) { return [point[0], point[1] + modifiers[i]]; }));
            canvasUtils.bezierCurveThrough(ctx,
                currentPoints.map(function (point) { return [point[0] + modifiers[i], point[1]]; }));
        }

        ctx.fill();
        ctx.restore();
    }

    var publicApi = {
        init: function(canvasEl, exporter) {
            canvas = canvasEl;
            canvasWrapper = document.getElementById('canvas-wrapper');
            exportHandler = exporter;
        },

        drawImage: function(img) {
            return function () {
                var ctx = canvas.getContext('2d');

                ctx.strokeStyle = '#000000';
                ctx.imageSmoothingEnabled = false;

                var maxCanvasWidth = 500;
                var maxCanvasHeight = 500;
                var imgWidth = img.width || img.naturalWidth;
                var imgHeight = img.height || img.naturalHeight;
                var ratio = Math.min(maxCanvasWidth / imgWidth, maxCanvasHeight / imgHeight);

                canvas.width = imgWidth * ratio;
                canvas.height = imgHeight * ratio;

                ctx.drawImage(img, 0, 0, canvas.width, canvas.height);

                var pixels = ctx.getImageData(0, 0, canvas.width, canvas.height);
                var trimmingResult = canvasUtils.trimTransparency(pixels, canvas.width, canvas.height, ctx);

                canvas.width = trimmingResult.width;
                canvas.height = trimmingResult.height;

                ctx.putImageData(trimmingResult.data, 0, 0);

                averageColor = detectAverageColor();

                document.getElementById('canvas-wrapper').style.width = trimmingResult.width + 'px';
                document.getElementById('canvas-wrapper').style.height = trimmingResult.height + 'px';

                pixelMatrix.init(transparencyColor, originalColor);
                canvasRegions.init(pixelMatrix, averageColor, canvas);
                pixelMatrix.restoreRegions(canvas.getContext('2d').getImageData(0, 0, canvas.width, canvas.height));
                exportData();
            };
        },

        putPoint: function(evt) {
            var canvasCoords = canvasUtils.relMouseCoords(evt, canvas);

            currentPoints.push([canvasCoords.x, canvasCoords.y]);

            var marker = document.createElement('div');

            marker.className = 'point';
            marker.style.left = (canvasCoords.x - 5) + 'px';
            marker.style.top = (canvasCoords.y - 5) + 'px';

            canvasWrapper.appendChild(marker);
            pointElements[pointElements.length - 1].push(marker);
        },

        canvasHoverIn: function ($event) {
            canvasRegions.hover($event);
        },

        drawCurve: function () {
            if (currentPoints.length >= 2) {
                undoList.push(canvas.toDataURL());
                normalizePoints();
                drawCurve();
                pixelMatrix.restoreRegions(canvas.getContext('2d').getImageData(0, 0, canvas.width, canvas.height));
                removeLastPoints();
                exportData();

                currentPoints = [];
            }
        },

        initForMarkers: function() {
            pointElements.push([]);
        },

        removeBezier: function() {
            if (!undoList.length) {
                return;
            }

            var lastImage = undoList.pop();
            var img = new Image();
            var ctx = canvas.getContext('2d');

            img.onload = function() {
                ctx.clearRect(0, 0, canvas.width, canvas.height);
                ctx.drawImage(img, 0, 0, canvas.width, canvas.height, 0, 0, canvas.width, canvas.height);
                pixelMatrix.restoreRegions(canvas.getContext('2d').getImageData(0, 0, canvas.width, canvas.height));
                exportData();
            };
            img.src = lastImage;
        },

        assignSideAndPercentage: function() {
            
        },

        debugRegions: function() {
            var ctx = canvas.getContext('2d');
            var colorMap = {};
            var matrix = pixelMatrix.value();

            colorMap[2] = '#000000';
            colorMap[3] = '#FF0000';
            colorMap[4] = '#FF6A00';
            colorMap[5] = '#FFD800';
            colorMap[6] = '#B6FF00';
            colorMap[7] = '#4CFF00';
            colorMap[8] = '#00FFFF';
            colorMap[9] = '#0094FF';
            colorMap[10] = '#0026FF';
            colorMap[11] = '#B200FF';
            colorMap[12] = '#FF00DC';
            colorMap[13] = '#FF006E';
            colorMap[14] = '#7F0000';
            colorMap[15] = '#267F00';
            colorMap[16] = '#7F006E';

            undoList.push(canvas.toDataURL());

            for (var y = 0; y < matrix.length; y++) {
                for (var x = 0; x < matrix[y].length; x++) {
                    if (matrix[y][x] === transparencyColor) {
                        continue;
                    }

                    ctx.fillStyle = colorMap[matrix[y][x]];

                    ctx.fillRect(x, y, 1, 1);
                }
            }
        }
    };

    return publicApi;
}