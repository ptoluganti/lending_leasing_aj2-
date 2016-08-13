System.register([], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var TileViewModel, DashboardViewModel;
    return {
        setters:[],
        execute: function() {
            TileViewModel = (function () {
                function TileViewModel(title, value, url, iconCssClass, colorCssClass) {
                    this.title = title;
                    this.value = value;
                    this.url = url;
                    this.iconCssClass = iconCssClass;
                    this.colorCssClass = colorCssClass;
                }
                return TileViewModel;
            }());
            exports_1("TileViewModel", TileViewModel);
            DashboardViewModel = (function () {
                function DashboardViewModel() {
                }
                return DashboardViewModel;
            }());
            exports_1("DashboardViewModel", DashboardViewModel);
        }
    }
});
//# sourceMappingURL=icustomer.js.map