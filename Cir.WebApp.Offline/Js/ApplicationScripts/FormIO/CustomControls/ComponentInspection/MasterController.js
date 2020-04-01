angular
    .module('formio')
    .config([
        'formioComponentsProvider',
        function (formioComponentsProvider) {
            formioComponentsProvider.register('imageInspectionTool', {
                title: 'Component Inspections Tool',
                label: 'Component Inspections Tool',
                fbtemplate: 'imageInspectionToolView.html',
                template: 'imageInspectionTool.html',
                controller: ['$scope', function ($scope) {
                    var pixelMatrix = PixelMatrix();
                    var canvasController = CanvasController(pixelMatrix, -1);
                    var labelingController = LabelingController();
                    var sidesController = ComponentSidesController(pixelMatrix, -1);

                    function compressPixels(pixels) {
                        var result = [];

                        for (var i = 0; i < pixels.length; i++) {
                            result.push(BitArrayCompressionAlgorithm.compress(pixels[i]));
                        }

                        return result;
                    }

                    $scope.filePresent = false;
                    $scope.drawingMode = false;
                    $scope.labelingMode = false;
                    $scope.sidesMode = false;
                    $scope.canvasController = canvasController;
                    $scope.labelingController = labelingController;
                    $scope.sidesController = sidesController;

                    $scope.onFilesSelected = function(files) {
                        $scope.filePresent = true;
                        canvasController.init(document.getElementById('component-canvas'),
                            function(data) {
                                data.pixels = compressPixels(data.pixels);

                                $scope.component.data.imageData = JSON.stringify(data);
                            });
                        labelingController.init(document.getElementById('component-canvas'),
                            function(data) {
                                $scope.component.data.labelsData = data;
                            });
                        sidesController.init(document.getElementById('component-canvas'),
                            function(data) {
                                $scope.component.data.sidesData = data;
                            });

                        var fr = new FileReader();
                        var onImgLoaded = canvasController.drawImage;

                        fr.onload = function () {
                            var img = new Image();

                            img.onload = onImgLoaded(img);
                            img.src = fr.result;
                        };

                        fr.readAsDataURL(files[0]); 
                    };

                    $scope.redirectToFilePicker = function() {
                        document.getElementById('files-picker').click();
                    };

                    $scope.toggleLabelMode = function () {
                        if (!pixelMatrix.hasRegions()) {
                            return;
                        }

                        $scope.labelingMode = !$scope.labelingMode;

                        if (!$scope.labelingModel) {
                            labelingController.discardModal();
                        } else {
                            sidesController.discardModal();

                            $scope.sidesMode = false;
                        }
                    };

                    $scope.toggleDrawingMode = function() {
                        $scope.drawingMode = !$scope.drawingMode;

                        if (!$scope.drawingMode) {
                            canvasController.drawCurve();
                        } else {
                            $scope.labelingMode = false;
                            $scope.sidesMode = false;

                            labelingController.discardModal();
                            sidesController.discardModal();
                            canvasController.initForMarkers();
                        }
                    };

                    $scope.toggleSidesMode = function () {
                        if (!pixelMatrix.hasRegions()) {
                            return;
                        }

                        $scope.sidesMode = !$scope.sidesMode;

                        if (!$scope.sidesMode) {
                            sidesController.discardModal();
                        } else {
                            $scope.labelingMode = false;
                            $scope.drawingMode = false;
                        }
                    }

                    $scope.onCanvasClick = function(event) {
                        if ($scope.drawingMode) {
                            canvasController.putPoint(event);
                        } else if ($scope.labelingMode) {
                            labelingController.putLabel(event);
                        } else if ($scope.sidesMode) {
                            sidesController.putOrEditSideInfo(event);
                        }
                    };
                }],
                settings: {
                    tableView: true,
                    label: 'Blade inspection tool',
                    leftLabel: 'Load images',
                    rightLabel: 'Drag the loaded images to location',
                    key: 'imageInspectionTool',
                    protected: false,
                    unique: false,
                    persistent: true,
                    data: {
                        imageData: null,
                        labelsData: null,
                        sidesData: null
                    }
                },
                icon: 'fa fa-file-image-o',
                views: [
                    {
                        name: 'Display',
                        template: 'imageDisplayProperties.html'
                    }
                ]
            });
        }
    ]);
