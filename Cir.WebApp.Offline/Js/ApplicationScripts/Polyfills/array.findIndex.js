if (!Array.prototype.findIndex) {
    Object.defineProperty(Array.prototype, 'findIndex', {
        value: function (predicate) {
            if (this == null) {
                throw new TypeError('"this" ma wartość null lub undefined');
            }

            var o = Object(this);
            var len = o.length >>> 0;

            if (typeof predicate !== 'function') {
                throw new TypeError('predykat musi być funkcją');
            }

            var thisArg = arguments[1];
            var k = 0;

            while (k < len) {
                var kValue = o[k];

                if (predicate.call(thisArg, kValue, k, o)) {
                    return k;
                }

                k++;
            }

            return -1;
        }
    });
}