function LabelingController() {
    var canvas = null;
    var canvasWrapper = null;
    var labels = [];
    var currentLabelAt = null;
    var modal = null;
    var publicApi = null;
    var exportHandler = null;

    function exportData() {
        var data = [];

        for (var i = 0; i < labels.length; i++) {
            data.push({
                text: labels[i].text,
                x: labels[i].x,
                y: labels[i].y
            });
        }

        exportHandler(data);
    }

    function onLabelClick(e) {
        var target = e.target || e.srcElement;
        var labelInfo = labels.filter(function(info) {
            return info.element === target.parentElement;
        })[0];

        if (!labelInfo) {
            return;
        }

        publicApi.putLabel(null, { x: labelInfo.x, y: labelInfo.y });

        publicApi.currentLabel = target.innerText;
    }

    function onMoveSymbolClick(e) {
        e.stopPropagation();

        var target = (e.target || e.srcElement);
        var parent = target.parentElement;
        var index = -1;
        var x = 0;
        var y = 0;

        for (var i = 0; i < labels.length; i++) {
            if (labels[i].element === parent) {
                index = i;

                break;
            }
        }
        if (index < 0) {
            return;
        }
        switch (target.dataset.dir) {
            case 'up':
                y = -2;
                break;
            case 'right':
                x = 2;
                break;
            case 'down':
                y = 2;
                break;
            case 'left':
                x = -2;
                break;
        }

        var top = parseInt(parent.style.top) + y;
        var left = parseInt(parent.style.left) + x;

        parent.style.top = top + 'px';
        parent.style.left = left + 'px';
        labels[index].x = left + 5;
        labels[index].y = top;

        exportData();
    }

    function removeLabelInternal(index) {
        var el = labels[index].element;
        var children = el.children;

        for (var i = 0; i < children.length; i++) {
            children[i].removeEventListener('click', onMoveSymbolClick);
        }

        el.removeEventListener('click', onLabelClick);
        canvasWrapper.removeChild(el);
        labels.splice(index);
    }

    publicApi = {
        currentLabel: '',

        init: function (canvasEl, exporter) {
            canvas = canvasEl;
            canvasWrapper = document.getElementById('canvas-wrapper');
            modal = document.getElementById('labels-modal');
            exportHandler = exporter;
        },

        putLabel: function (event, coords) {
            currentLabelAt = coords ? coords : canvasUtils.relMouseCoords(event, canvas);
            modal.style.display = 'block';
            modal.style.left = currentLabelAt.x + 'px';
            modal.style.top = (parseInt(currentLabelAt.y - modal.offsetHeight / 2)) + 'px';
        },

        saveLabel: function () {
            if (!publicApi.currentLabel) {
                return;
            }

            var label = publicApi.currentLabel;
            var labelElement = document.createElement('span');
            var up = document.createElement('span');
            var right = document.createElement('span');
            var down = document.createElement('span');
            var left = document.createElement('span');

            up.className = 'move move-up';
            up.dataset.dir = 'up';
            right.className = 'move move-right';
            right.dataset.dir = 'right';
            down.className = 'move move-down';
            down.dataset.dir = 'down';
            left.className = 'move move-left';
            left.dataset.dir = 'left';

            labelElement.className = 'label-contents';
            labelElement.style.top = currentLabelAt.y + 'px';
            labelElement.innerHTML = '<span>' + label + '</span>';

            up.addEventListener('click', onMoveSymbolClick);
            right.addEventListener('click', onMoveSymbolClick);
            down.addEventListener('click', onMoveSymbolClick);
            left.addEventListener('click', onMoveSymbolClick);
            labelElement.addEventListener('click', onLabelClick);
            labelElement.appendChild(up);
            labelElement.appendChild(right);
            labelElement.appendChild(down);
            labelElement.appendChild(left);
            // need to first put the element in the DOM, otherwise offsetWidth will be 0
            canvasWrapper.appendChild(labelElement);

            var x = currentLabelAt.x - labelElement.offsetWidth;

            labelElement.style.left = x + 'px';

            labels.push({
                text: label,
                element: labelElement,
                x: x,
                y: currentLabelAt.y
            });
            publicApi.discardModal();
            exportData();
        },

        discardModal: function () {
            modal.style.display = 'none';
            publicApi.currentLabel = '';
        },

        removeLabel: function (e) {
            var target = (e.target || e.srcElement).parentElement;
            var x = parseInt(target.style.left);
            var y = parseInt(target.style.top) + modal.offsetHeight / 2;
            var index = -1;

            for (var i = 0; i < labels.length; i++) {
                if (labels[i].x === x && labels[i].y === y) {
                    index = i;

                    break;
                }
            }
            if (index < 0) {
                return;
            }

            removeLabelInternal(index);
            publicApi.discardModal();
            exportData();
        }
    };

    return publicApi;
}