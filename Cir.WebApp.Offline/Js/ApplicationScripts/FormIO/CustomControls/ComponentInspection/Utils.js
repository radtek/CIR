var canvasUtils = {
    bezierCurveThrough: function(ctx, points, tension) {
        tension = tension || 0.25;

        var l = points.length;

        if (l < 2) {
            return;
        }

        if (l === 2) {
            ctx.beginPath();
            ctx.moveTo(points[0][0], points[0][1]);
            ctx.lineTo(points[1][0], points[1][1]);
            ctx.closePath();
            ctx.stroke();

            return;
        }

        function h(x, y) {
            return Math.sqrt(x * x + y * y);
        }

        var cpoints = [];

        points.forEach(function() {
            cpoints.push({});
        });

        for (var i = 1; i < l - 1; i++) {
            var pi = points[i],
                pp = points[i - 1],
                pn = points[i + 1];
            var rdx = pn[0] - pp[0],
                rdy = pn[1] - pp[1],
                rd = h(rdx, rdy),
                dx = rdx / rd,
                dy = rdy / rd;
            var dp = h(pi[0] - pp[0], pi[1] - pp[1]),
                dn = h(pi[0] - pn[0], pi[1] - pn[1]);
            var cpx = pi[0] - dx * dp * tension,
                cpy = pi[1] - dy * dp * tension,
                cnx = pi[0] + dx * dn * tension,
                cny = pi[1] + dy * dn * tension;

            cpoints[i] = {
                cp: [cpx, cpy],
                cn: [cnx, cny]
            };
        }

        cpoints[0] = { cn: [(points[0][0] + cpoints[1].cp[0]) / 2, (points[0][1] + cpoints[1].cp[1]) / 2] };
        cpoints[l - 1] = { cp: [(points[l - 1][0] + cpoints[l - 2].cn[0]) / 2, (points[l - 1][1] + cpoints[l - 2].cn[1]) / 2] };

        ctx.beginPath();
        ctx.moveTo(points[0][0], points[0][1]);

        for (i = 1; i < l; i++) {
            var p = points[i],
                cp = cpoints[i],
                cpp = cpoints[i - 1];

            ctx.bezierCurveTo(cpp.cn[0], cpp.cn[1], cp.cp[0], cp.cp[1], p[0], p[1]);
        }

        ctx.stroke();
    },

    trimTransparency: function(pixels, initialWidth, initialHeight, ctx) {
        var l = pixels.data.length,
            i,
            bound = {
                top: null,
                left: null,
                right: null,
                bottom: null
            },
            x,
            y;

        for (i = 0; i < l; i += 4) {
            if (pixels.data[i + 3] !== 0) {
                x = (i / 4) % initialWidth;
                y = ~~((i / 4) / initialWidth);

                if (bound.top === null) {
                    bound.top = y;
                }

                if (bound.left === null) {
                    bound.left = x;
                } else if (x < bound.left) {
                    bound.left = x;
                }

                if (bound.right === null) {
                    bound.right = x;
                } else if (bound.right < x) {
                    bound.right = x;
                }

                if (bound.bottom === null) {
                    bound.bottom = y;
                } else if (bound.bottom < y) {
                    bound.bottom = y;
                }
            }
        }

        var trimHeight = bound.bottom - bound.top,
            trimWidth = bound.right - bound.left,
            trimmed = ctx.getImageData(bound.left, bound.top, trimWidth, trimHeight);

        return {
            width: trimWidth,
            height: trimHeight,
            data: trimmed
        };
    },

    relMouseCoords: function (event, currentElement) {
        var totalOffsetX = 0;
        var totalOffsetY = 0;
        var canvasX = 0;
        var canvasY = 0;

        do {
            totalOffsetX += currentElement.offsetLeft - currentElement.scrollLeft;
            totalOffsetY += currentElement.offsetTop - currentElement.scrollTop;
        } while (currentElement = currentElement.offsetParent)

        canvasX = event.pageX - totalOffsetX;
        canvasY = event.pageY - totalOffsetY;

        if (navigator.userAgent.toLowerCase().indexOf(' electron/') > -1) {
            canvasY -= document.body.scrollTop;
        }

        return { x: canvasX, y: canvasY }
    },

    nearestTransparentPoint: function(pixels, point, width, heigth) {
        var x = point[0];
        var y = point[1];

        var isTransparent = function(alpha) {
            return alpha === 0;
        };
        var alphaIndex = function(coordX, coordY) {
            return (coordX + width * coordY) * 4;
        };

        if (isTransparent(pixels[alphaIndex(x, y)])) {
            return point;
        }

        for (var i = 1; width - i >= 0 && i <= width && heigth - i >= 0 && i <= heigth; i++) {
            //check around pixel for transparency
            if (isTransparent(pixels[alphaIndex(x + i, y)])) {
                return [x + i, y];
            } else if (isTransparent(pixels[alphaIndex(x + i, y + i)])) {
                return [x + i, y + i];
            } else if (isTransparent(pixels[alphaIndex(x, y + i)])) {
                return [x, y + i];
            } else if (isTransparent(pixels[alphaIndex(x - i, y + i)])) {
                return [x - i, y + i];
            } else if (isTransparent(pixels[alphaIndex(x - i, y)])) {
                return [x - i, y];
            } else if (isTransparent(pixels[alphaIndex(x - i, y - i)])) {
                return [x - i, y - i];
            } else if (isTransparent(pixels[alphaIndex(x, y - i)])) {
                return [x, y - i];
            } else if (isTransparent(pixels[alphaIndex(x + i, y - 1)])) {
                return [x + i, y - 1];
            }
        }

        return [x, y];
    }
};