function formRules() {
    let _disableRolesKey = "disable-roles";
    let _visibleRolesKey = "visible-roles";
    let _requiredRolesKey = "required-role";
    let _enableRolesKey = "enable-roles";

    var _getRequiredComponents = function(components) {
        let requiredComponents = [];

        for (let prop in components) {
            if (components.hasOwnProperty(prop) &&
                components[prop].hasOwnProperty("properties") &&
                components[prop].properties.hasOwnProperty(_requiredRolesKey) &&
                components[prop].properties[_requiredRolesKey] !== "") {
                requiredComponents.push(components[prop]);
            }
        }

        return requiredComponents;
    }

    var _getDisabledComponents = function (components) {
        let disabledComponents = [];

        for (let comp in components) {
            if (components.hasOwnProperty(comp) &&
                components[comp].hasOwnProperty("properties") &&
                components[comp].properties.hasOwnProperty(_disableRolesKey) &&
                components[comp].properties[_disableRolesKey] !== "") {
                disabledComponents.push(components[comp]);
            }
        }

        return disabledComponents;
    }
    var _getEnabledComponents = function (components) {
        let enabledComponents = [];

        for (let comp in components) {
            if (components.hasOwnProperty(comp) &&
                components[comp].hasOwnProperty("properties") &&
                components[comp].properties.hasOwnProperty(_enableRolesKey) &&
                components[comp].properties[_enableRolesKey] !== "") {
                enabledComponents.push(components[comp]);
            }
        }
        return enabledComponents;
    }
   

    var _isInRole = function (roles) {
        let rolesArr = roles.split(",");
        let flag = false;
        $.grep(rolesArr, function (item) {
            if (hasRole(item))
                flag = true;
        });

        return flag;
    }
 
    var _applyComponentsRequired = function (components) {
        $.grep(components,
            function (component) {
                let hasRole = _isInRole(component.properties[_requiredRolesKey]);

                component.validate.required = hasRole || component.validate.required;
            });
    }

    var _applyComponentsDisabled = function(components) {
        $.grep(components,
            function(component) {
                let hasRole = _isInRole(component.properties[_disableRolesKey]);

                component.disabled = hasRole;
            });
    }

    
    var _applyComponentsEnabled = function (components) {
        $.grep(components,
            function(component) {
                let hasRole = _isInRole(component.properties[_enableRolesKey]);

                component.disabled = !hasRole;
                console.log(component + "  +  " + hasRole);
            });
    }
    var _applyComponentsVisible = function (components) {
        for (let prop in components) {
            if (components.hasOwnProperty(prop) &&
                !components[prop].hasOwnProperty("properties") ||
                (components[prop].hasOwnProperty("properties") &&
                !components[prop].properties.hasOwnProperty(_visibleRolesKey))) {

                continue;
            }

            if (components.hasOwnProperty(prop) &&
                components[prop].hasOwnProperty("properties") &&
                components[prop].properties.hasOwnProperty(_visibleRolesKey) &&
                components[prop].properties[_visibleRolesKey] !== "") {
                let hasRole = _isInRole(components[prop].properties[_visibleRolesKey]);

                components[prop].hidden = !hasRole;

                if (!hasRole && components[prop].hasOwnProperty("validate") && components[prop].validate.hasOwnProperty("required")) {
                    components[prop].validate.wasRequired = components[prop].validate.required;
                    components[prop].validate.required = false;
                }
            } else {
                components[prop].hidden = true;

                if (components[prop].hasOwnProperty("validate") && components[prop].validate.hasOwnProperty("required")) {
                    components[prop].validate.wasRequired = components[prop].validate.required;
                    components[prop].validate.required = false;
                }
            }
        }
    }

    var applyRoleRules = function ($scope) {
        let flattenedComponents = FormioUtils.flattenComponents($scope.form.components);

        let requiredComponents = _getRequiredComponents(flattenedComponents);
        let disabledComponents = _getDisabledComponents(flattenedComponents);
        let enabledComponents = _getEnabledComponents(flattenedComponents);
        _applyComponentsRequired(requiredComponents);
        _applyComponentsDisabled(disabledComponents);
        _applyComponentsVisible(flattenedComponents);
        _applyComponentsEnabled(enabledComponents);

        $scope.$applyAsync();
    }

    return {
        applyRoleRules: applyRoleRules,
        disableRolesKey: _disableRolesKey,
        visibleRolesKey: _visibleRolesKey,
        requiredRolesKey: _requiredRolesKey,
        enableRoleKey:_enableRolesKey
    }
}