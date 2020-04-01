angular.module('formio')
    .factory('templateService', [function () {
        var service = {
            windAmsPostfix: "_WindAMS",
            bladeInspectionTemplateName: "BladeInspection",

            getTemplates: function(brand) {
                var deferredObject = $.Deferred();
                cirOfflineApp.GetCirTemplateList().done(function (templates) {
                    let unitedTemplates = templates.filter(x => x.cirBrand.id == brand);                

                    let selectedBrand = unitedTemplates[0] ? unitedTemplates[0].cirBrand.name : null;

                    if (selectedBrand.length == 0 || selectedBrand.indexOf(service.windAmsPostfix) != -1) {
                        deferredObject.resolve(unitedTemplates);
                        return;
                    }

                    let windAmsTemplates =
                        templates.filter(x => x.cirBrand.name == selectedBrand + service.windAmsPostfix);
                    if (windAmsTemplates.length == 0) {
                        deferredObject.resolve(unitedTemplates);
                        return;
                    }

                    let windAmsTemplateNames = windAmsTemplates.map(x => x.name);

                    let templatesToReplace = templates.filter(x => windAmsTemplateNames.indexOf(x.name) != -1 &&
                        x.cirBrand.name == selectedBrand + service.windAmsPostfix);

                    for (var i = 0; i < templatesToReplace.length; i++) {
                        var template = unitedTemplates.filter(x => x.name == templatesToReplace[i].name);
                        if (template.length != 0) {
                            var templateIndex = unitedTemplates.indexOf(template[0]);
                            if (templateIndex != -1) {
                                unitedTemplates[unitedTemplates.indexOf(template[0])] = templatesToReplace[i];
                            } else {
                                unitedTemplates.push(templatesToReplace[i]);
                            }
                        } else {
                            unitedTemplates.push(templatesToReplace[i]);
                        }
                    }

                    deferredObject.resolve(unitedTemplates);
                });

                return deferredObject.promise();
            },

            getBrands: function () {
                var deferredObject = $.Deferred();
                cirOfflineApp.GetCirTemplateList().done(function (templates) {
                    let brandList = [];
                    let brands = templates.map(t => { return { id: t.cirBrand.id, name: t.cirBrand.name } })
                    brands.forEach(function (item, idx) {
                        if (item.name.indexOf(service.windAmsPostfix) != -1) {
                            let nonWindAmsBrands =
                                brands.filter(x => x.name == item.name.replace(service.windAmsPostfix, ''));
                            if (nonWindAmsBrands.length == 0) {
                                item.name = item.name.replace(service.windAmsPostfix, '');
                                if (!brandList.filter(x => x.name == item.name)[0]) {
                                    brandList.push(item);

                                }
                            } else {
                                if (!brandList.filter(x => x.name == nonWindAmsBrands[0].name)[0]) {
                                    brandList.push(nonWindAmsBrands[0]);

                                }
                            }
                        } else {
                            if (!brandList.filter(x => x.name == item.name)[0]) {
                                brandList.push(item);

                            }
                        }
                    });
                    if (brandList.length > 0) {
                        if (brandList.filter(x => x.name == "Vestas").length == 1) {
                            var vestasbrand = (brandList.filter(x => x.name == "Vestas"))[0];
                            var index = brandList.indexOf(vestasbrand);
                            brandList.splice(index, 1);
                            brandList.unshift(vestasbrand);
                        }
                    }
                    deferredObject.resolve(brandList);
                });
                //if (Offline.state == "down") {
                //    return service.getBrandsinOfflineMode();
                //}

                //var deferredObject = $.Deferred();
                //cirOfflineApp.GetBrandsName().done(function (userBrands) {
                //    let brandList = [];
                //    let brands = userBrands.map(t => { return { id: t.id, name: t.name } })
                //    brands.forEach(function (item, idx) {
                //        if (item.name.indexOf(service.windAmsPostfix) != -1) {
                //            let nonWindAmsBrands =
                //                brands.filter(x => x.name == item.name.replace(service.windAmsPostfix, ''));
                //            if (nonWindAmsBrands.length == 0) {
                //                item.name = item.name.replace(service.windAmsPostfix, '');
                //                if (!brandList.filter(x => x.name == item.name)[0]) {
                //                    brandList.push(item);
                                  
                //                }
                //            } else {
                //                if (!brandList.filter(x => x.name == nonWindAmsBrands[0].name)[0]) {
                //                    brandList.push(nonWindAmsBrands[0]);
                                    
                //                }
                //            }
                //        } else {
                //            if (!brandList.filter(x => x.name == item.name)[0]) {
                //                brandList.push(item);
                               
                //            }
                //        }
                //    });
                //    if (brandList.length > 0) {
                //        if (brandList.filter(x => x.name == "Vestas").length == 1) {
                //            var vestasbrand = (brandList.filter(x => x.name == "Vestas"))[0];
                //            var index = brandList.indexOf(vestasbrand);
                //            brandList.splice(index, 1);
                //            brandList.unshift(vestasbrand);
                //        }
                //    }
                //    deferredObject.resolve(brandList);
                //});

                return deferredObject.promise();
            },

            getBrandsinOfflineMode: function(){
                var deferredObject = $.Deferred();
                cirOfflineApp.GetCirTemplateList().done(function (templates) {
                    let brandList = [];
                    let brands = templates.map(t => { return { id: t.cirBrand.id, name: t.cirBrand.name } })
                    brands.forEach(function (item, idx) {
                        if (item.name.indexOf(service.windAmsPostfix) != -1) {
                            let nonWindAmsBrands =
                                brands.filter(x => x.name == item.name.replace(service.windAmsPostfix, ''));
                            if (nonWindAmsBrands.length == 0) {
                                item.name = item.name.replace(service.windAmsPostfix, '');
                                if (!brandList.filter(x => x.name == item.name)[0]) {
                                    brandList.push(item);

                                }
                            } else {
                                if (!brandList.filter(x => x.name == nonWindAmsBrands[0].name)[0]) {
                                    brandList.push(nonWindAmsBrands[0]);

                                }
                            }
                        } else {
                            if (!brandList.filter(x => x.name == item.name)[0]) {
                                brandList.push(item);

                            }
                        }
                    });
                    if (brandList.length > 0) {
                        if (brandList.filter(x => x.name == "Vestas").length == 1) {
                            var vestasbrand = (brandList.filter(x => x.name == "Vestas"))[0];
                            var index = brandList.indexOf(vestasbrand);
                            brandList.splice(index, 1);
                            brandList.unshift(vestasbrand);
                        }
                    }
                    deferredObject.resolve(brandList);
                });

                return deferredObject.promise();
            },


            getTemplateById: function (templateId) {
                var deferredObject = $.Deferred();
                cirOfflineApp.GetCirTemplateById(templateId)
                    .done(function(template) {
                        deferredObject.resolve(template);
                    })
                    .fail(function() {
                        deferredObject.reject(); 
                    });

                return deferredObject.promise();
            },

            getTemplateFromApiById: function(templateId) {
                if (Offline.state == "down") {
                    return service.getTemplateById(templateId);
                }

                var deferredObject = $.Deferred();

                cirOfflineApp.GetCirTemplateById(templateId)
                    .done(function(template) {
                        CallSyncApi("CirTemplate/GetLatestVersion?cirBrandCollectionName=" +
                                template.cirBrandCollectionName,
                                "GET").done(
                                function(response) {
                                    var latestTemplate = JSON.parse(response.response);

                                    cirOfflineApp.UpdateCirTemplate(latestTemplate).done(function() {
                                            deferredObject.resolve(latestTemplate);
                                        })
                                        .fail(function() {
                                            deferredObject.reject();
                                        });
                                })
                            .fail(function() {
                                deferredObject.reject();
                            });
                    })
                    .fail(function() {
                        deferredObject.reject();
                    });

                return deferredObject.promise();
            },

            getBrandById: function(brandId) {
                var deferredObject = $.Deferred();
                cirOfflineApp.GetCirBrandById(brandId)
                    .done(function(brand) {
                        deferredObject.resolve(brand);
                    })
                    .fail(function() {
                        deferred.reject();
                    });

                return deferredObject.promise();
            },

            isBladeInspection: function(templateName) {
                return templateName.startsWith(this.bladeInspectionTemplateName);
            },

            isWindAmsBrand: function(brandName) {
                return brandName.indexOf(this.windAmsPostfix) > 0
                    ? true
                    : false;
            }
        };

        return service;
    }]);