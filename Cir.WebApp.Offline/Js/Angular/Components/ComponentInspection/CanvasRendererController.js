function CanvasRendererController(canvas, canvasWrapper, data, transparencySymbol) {
    var pixels = decompressPixels();
    var labelsData = data.labelsData;
    var colorData = data.imageData.color;
    var originalColor = 1;
    var pixelMatrix = PixelMatrix();
    var regions = {};
    var assignedRegionColor = '#0094FF';
    var defaultColor = '#' + rgba2hex(colorData.r, colorData.g, colorData.b);
    var noRegionSymbol = transparencySymbol;
    var currentlyHoveredOverColor = defaultColor;
    var currentlyHoveredOverRegion = -1;
    var mouseHoverColor = '#ADD8E6';

    function decompressPixels() {
        var rows = [];

        for (var i = 0; i < data.imageData.pixels.length; i++) {
            rows.push(BitArrayCompressionAlgorithm.decompress(data.imageData.pixels[i]));
        }

        return rows;
    }

    function rgba2hex(r, g, b) {
        if (r > 255 || g > 255 || b > 255) {
            throw 'Invalid color component';
        }

        return ((256 + r).toString(16).substr(1) + ((1 << 24) + (g << 16) | (b << 8)).toString(16).substr(1)).substr(0, 6);
    }

    function sortedArray() {
        var arr = [];

        return {
            all: function () {
                var tmp = [];

                for (var i = 0; i < arr.length; i++) {
                    tmp.push({
                        id: arr[i].id,
                        severity: arr[i].severity,
                        color: arr[i].color
                    });
                }

                return tmp;
            },

            put: function (item) {
                var itemExists = arr.filter(function(element) {
                    return element.id === item.id;
                }).length > 0;

                if (itemExists) {
                    return;
                }
                //unsaved images
                if (item.severity === -1) {
                    arr.splice(0, 0, item);
                }
                else {
                    var lowerIndex = arr.findIndex(function (element) {
                        return element.severity < item.severity;
                    });

                    if (lowerIndex < 0) {
                        arr.push(item);
                    } else {
                        arr.splice(lowerIndex, 0, item);
                    }
                }
            },

            remove: function (id) {
                var index = arr.findIndex(function (element) {
                    return element.id === id;
                });

                if (index < 0) {
                    return;
                }

                arr.splice(index, 1);
            },

            first: function () {
                if (!arr.length) {
                    return null;
                }

                return arr[0];
            }
        };
    };

    function ctxDraw(ctx, color, region) {
        ctx.save();

        ctx.fillStyle = color;

        for (var i = 0; i < regions[region].coords.length; i++) {
            ctx.fillRect(regions[region].coords[i].x, regions[region].coords[i].y, 1, 1);
        }

        ctx.restore();
    }  

    function paintRegions() {
        var ctx = canvas.getContext('2d');

        for (var region in regions) {
            if (!regions.hasOwnProperty(region)) {
                continue;
            }

            var color = defaultColor;
            var firstElement = regions[region].severityInfo.first();

            if (!!firstElement && !!firstElement.color) {
                color = firstElement.color;
            } else if (!!firstElement) {
                color = assignedRegionColor;
            }

            ctxDraw(ctx, color, region);
        }
    }
   
    function calculateRegionsPixels() {
        var matrix = pixelMatrix.value();

        for (var y = 0; y < matrix.length; y++) {
            for (var x = 0; x < matrix[y].length; x++) {
                var region = matrix[y][x];

                if (region === noRegionSymbol) {
                    continue;
                }
                if (!regions[region]) {
                    regions[region] = {
                        defaultColor: defaultColor,
                        severityInfo: sortedArray(),
                        coords: []
                    };
                }

                regions[region].coords.push({ x: x, y: y });
            }
        }
    }

    function createCanvas() {
        var val = pixelMatrix.value();
        var ctx = canvas.getContext('2d');

        canvas.height = val.length;
        canvas.width = val[0].length;
        canvasWrapper.style.height = val.length + 'px';
        canvasWrapper.style.width = val[0].length + 'px';

        ctx.save();

        ctx.fillStyle = 'rgba(' + colorData.r + ',' + colorData.g + ',' + colorData.b + ',255)';

        for (var y = 0; y < val.length; y++) {
            for (var x = 0; x < val[y].length; x++) {
                if (val[y][x] === transparencySymbol) {
                    continue;
                }

                ctx.fillRect(x, y, 1, 1);
            }
        }

        ctx.restore();
    }

    function drawLabels() {
        for (var i = 0; i < labelsData.length; i++) {
            var label = document.createElement('span');

            label.className = 'label';
            label.style.left = labelsData[i].x + 'px';
            label.style.top = labelsData[i].y + 'px';
            label.innerText = labelsData[i].text;

            canvasWrapper.appendChild(label);
        }
    }

    function initializeRegions(sections, severityColors) {
        for (var key in sections) {
            if (!sections.hasOwnProperty(key)) {
                continue;
            }

            for (var i = 0; i < sections[key].images.length; i++) {
                var sectionKey = parseInt(key.toString().indexOf('section') > -1 ? key.substring(7) : key);

                regions[sectionKey].severityInfo.put({
                    id: sections[key].images[i].imageId,
                    severity: sections[key].damageSeverity,
                    color: severityColors[sections[key].images[i].damageSeverity]
                });
            }
        }

        paintRegions();
    }

    function updateImageOnRegionInternal(region, item) {
        var key = parseInt(region.toString().indexOf('section') > -1 ? region.substring(7) : region);

        regions[key].severityInfo.remove(item.id);
        regions[key].severityInfo.put(item);
        paintRegions();
    }

    function restorePreviousRegion() {
        if (currentlyHoveredOverRegion === -1 || !regions[currentlyHoveredOverRegion]) {
            return;
        }

        var firstElement = regions[currentlyHoveredOverRegion].severityInfo.first();
        var ctx = canvas.getContext('2d');
        var color;

        if (!!firstElement && !!firstElement.color) {
            color = firstElement.color;
        } else if (!!firstElement) {
            color = assignedRegionColor;
        }
        else if (!firstElement) {
            color = defaultColor;
        } else {
            return;
        }

         ctxDraw(ctx, color, currentlyHoveredOverRegion);       
    }

    function highlightRegion(region, color) {
        var ctx = canvas.getContext('2d');

        if (!region || region === -1) {
            return;
        }

        if (!regions[region]) {
            return;
        }

        ctxDraw(ctx, color, region);       
    }

    return {
        init: function (sections, severityColors) {
            pixelMatrix.init(transparencySymbol, originalColor, pixels);
            createCanvas();
            calculateRegionsPixels();

            if (!!sections) {
                initializeRegions(sections, severityColors);
            }

            drawLabels();
        },

        getRegionFor: function(event) {
            var canvasCoords = canvasUtils.relMouseCoords(event, canvas);
            var region = pixelMatrix.findColorAt(canvasCoords.x, canvasCoords.y);

            return region;
        },

        highlight: function(event) {
            var region = this.getRegionFor(event);

            restorePreviousRegion();

            if (region === -1) {
                currentlyHoveredOverRegion = -1;
                currentlyHoveredOverColor = defaultColor;
            } else {
                currentlyHoveredOverRegion = region;
                currentlyHoveredOverColor = mouseHoverColor;
            }

            highlightRegion(region, currentlyHoveredOverColor);
        },

        removeHighlighting: function() {
          paintRegions();         
        },

        putImageOnRegion: function (region, item) {
            regions[region].severityInfo.put(item);
            paintRegions();
        },

        updateImageOnRegion: updateImageOnRegionInternal,

        removeImageFromRegion: function (region, id) {
            if (!regions[region]) {
                return;
            }

            regions[region].severityInfo.remove(id);
            paintRegions();
        }
    };
}