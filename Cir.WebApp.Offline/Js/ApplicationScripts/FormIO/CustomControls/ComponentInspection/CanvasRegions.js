function CanvasRegions(activeRegionColor, transparencySymbol) {
    var lastColoredRegion = null;
    var matrix = null;
    var color = null;
    var canvas = null;

    function rgba2hex(r, g, b, a) {
        if (r > 255 || g > 255 || b > 255 || a > 255) {
            throw 'Invalid color component';
        }

        return (256 + r).toString(16).substr(1) + ((1 << 24) + (g << 16) | (b << 8) | a).toString(16).substr(1);
    }

    function fillLastRegionWithColor(color) {
        var ctx = canvas.getContext('2d');

        ctx.save();

        ctx.fillStyle = color;

        for (var i = 0; i < lastColoredRegion.length; i++) {
            ctx.fillRect(lastColoredRegion[i].x, lastColoredRegion[i].y, 1, 1);
        }

        ctx.restore();
    }

    function colorRegion(virtualColor) {
        var region = matrix.findRegionWithColor(virtualColor);

        lastColoredRegion = region;

        fillLastRegionWithColor(activeRegionColor);
    }

    function uncolorRegion() {
        var newColor = rgba2hex(color.r, color.g, color.b, 255);

        fillLastRegionWithColor('#' + newColor);

        lastColoredRegion = null;
    }

    return {
        init: function(pixelMatrix, colorData, canvasEl) {
            matrix = pixelMatrix;
            color = colorData;
            canvas = canvasEl;
        },

        hover: function($event) {
            if (!matrix.hasRegions()) {
                return;
            }

            var canvasCoords = canvasUtils.relMouseCoords($event, canvas);
            var virtualColor = matrix.findColorAt(canvasCoords.x, canvasCoords.y);

            if (virtualColor === null || virtualColor === transparencySymbol) {
                if (!lastColoredRegion) {
                    return;
                }

                uncolorRegion();
            } else {
                if (lastColoredRegion) {
                    uncolorRegion();
                }

                colorRegion(virtualColor, canvasCoords.x, canvasCoords.y);
            }
        }
    }
}