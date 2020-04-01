function PixelMatrix() {
    var matrix = [];
    var transparency;
    var originalColor;
    var currentColor;

    function colorRegion(x, y, targetColor) {
        var queue = [[x, y]];
        var uniqueChecker = {};

        while (queue.length > 0) {
            var current = queue.shift();
            var neighbours = getNeighbours(current[0], current[1], targetColor);

            matrix[current[1]][current[0]] = targetColor;

            for (var i = 0; i < neighbours.length; i++) {
                if (uniqueChecker[neighbours[i][0] + ':' + neighbours[i][1]] === true) {
                    continue;
                }

                uniqueChecker[neighbours[i][0] + ':' + neighbours[i][1]] = true;

                queue.push(neighbours[i]);
            }
        }
    }

    function recalculate(data) {
        matrix = [];

        for (var i = 0; i < data.data.length; i += data.width * 4) {
            var slice = data.data.slice(i, i + (data.width * 4));
            var row = [];

            for (var j = 0; j < slice.length; j += 4) {
                row.push(slice[j + 3] < 128 ? transparency : originalColor);
            }

            matrix.push(row);
        }
    }

    function neighboringCoordsFor(px, py) {
        var candidates = [];
        var h = matrix.length;
        var w = matrix[0].length;

        if (py - 1 >= 0) {
            candidates.push([px, py - 1]);
        }
        if (py - 1 >= 0 && px + 1 < w) {
            candidates.push([px + 1, py - 1]);
        }
        if (px + 1 < w) {
            candidates.push([px + 1, py]);
        }
        if (px + 1 < w && py + 1 < h) {
            candidates.push([px + 1, py + 1]);
        }
        if (py + 1 < h) {
            candidates.push([px, py + 1]);
        }
        if (px - 1 >= 0 && py + 1 < h) {
            candidates.push([px - 1, py + 1]);
        }
        if (px - 1 >= 0) {
            candidates.push([px - 1, py]);
        }
        if (px - 1 >= 0 && py - 1 >= 0) {
            candidates.push([px - 1, py - 1]);
        }

        var coords = candidates.filter(function (coord) {
            var x = coord[0];
            var y = coord[1];

            return matrix[y][x] !== transparency;
        });

        return coords;
    }

    function getNeighbours(x, y, targetColor) {
        var currentNeighbors = neighboringCoordsFor(x, y);
        var coloredNeighbors = currentNeighbors.filter(function (coords) {
            return matrix[coords[1]][coords[0]] !== targetColor;
        });

        return coloredNeighbors;
    }

    return {
        value: function() { return matrix; },

        init: function(transparentColor, defaultColor, calculatedMatrix) {
            transparency = transparentColor;
            originalColor = defaultColor;

            if (!!calculatedMatrix) {
                matrix = calculatedMatrix;
            }
        },

        findColorAt: function(targetX, targetY) {
            for (var y = 0; y < matrix.length; y++) {
                if (y !== targetY) {
                    continue;
                }
                for (var x = 0; x < matrix[y].length; x++) {
                    if (x !== targetX) {
                        continue;
                    }

                    return matrix[y][x];
                }
            }

            return null;
        },

        findRegionWithColor: function (color) {
            var region = [];

            for (var y = 0; y < matrix.length; y++) {
                for (var x = 0; x < matrix[y].length; x++) {
                    if (matrix[y][x] === color) {
                        region.push({ x: x, y: y });
                    }
                }
            }

            return region;
        },

        restoreRegions: function(data) {
            currentColor = originalColor + 1;

            recalculate(data);

            for (var y = 0; y < matrix.length; y++) {
                for (var x = 0; x < matrix[y].length; x++) {
                    if (matrix[y][x] !== originalColor) {
                        continue;
                    }

                    colorRegion(x, y, currentColor);

                    currentColor++;
                }
            }
        },

        hasRegions: function() {
            var previousColor = transparency;

            for (var y = 0; y < matrix.length; y++) {
                for (var x = 0; x < matrix[y].length; x++) {
                    if (matrix[y][x] === transparency) {
                        continue;
                    } else if (previousColor === transparency) {
                        previousColor = matrix[y][x];
                    } else if (previousColor > transparency && matrix[y][x] !== previousColor) {
                        return true;
                    }
                }
            }

            return false;
        }
    };
}