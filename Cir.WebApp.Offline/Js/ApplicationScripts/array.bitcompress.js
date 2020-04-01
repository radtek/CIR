// this compression algorithm will have very little effect if the array passed to it 
// actually contains something else than zeroes and ones
// and it will degrade more and more for arrays containing more and more unique values
var BitArrayCompressionAlgorithm = {
    compress: function(array) {
        var result = [];
        var currentBit = null;

        for (var i = 0; i < array.length; i++) {
            if (array[i] !== currentBit) {
                currentBit = array[i];

                result.push([currentBit, 1]);
            } else {
                result[result.length - 1][1]++;
            }
        }

        return result;
    },

    decompress(compressed) {
        var result = [];

        for (var i = 0; i < compressed.length; i++) {
            var count = compressed[i][1];

            for (var j = 0; j < count; j++) {
                result.push(compressed[i][0]);
            }
        }

        return result;
    }
};
