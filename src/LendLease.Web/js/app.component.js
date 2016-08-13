System.register(['angular2/core', './customer/icustomer'], function(exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
        var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
        if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
        else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
        return c > 3 && r && Object.defineProperty(target, key, r), r;
    };
    var __metadata = (this && this.__metadata) || function (k, v) {
        if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
    };
    var core_1, icustomer_1;
    var AppComponent;
    return {
        setters:[
            function (core_1_1) {
                core_1 = core_1_1;
            },
            function (icustomer_1_1) {
                icustomer_1 = icustomer_1_1;
            }],
        execute: function() {
            AppComponent = (function () {
                function AppComponent() {
                    this.message = "Dashboard";
                    this.dashboardViewModel = null;
                    this.dashboardViewModel = new icustomer_1.DashboardViewModel();
                }
                AppComponent.prototype.ngOnInit = function () {
                    this.dashboardViewModel.customerCountTile = {
                        title: "Customers",
                        value: 10,
                        url: "Home",
                        iconCssClass: "fa fa-users fa-5x",
                        colorCssClass: "panel panel-primary"
                    };
                    //this.dashboardViewModel.scheduledPaymentCountTile = new TileViewModel("Scheduled Payments", 100, "Home", "fa fa-calendar fa-5x", "panel panel-yellow");
                    //this.dashboardViewModel.paymentRecievedCountTile = new TileViewModel("Payments Recieved", 75, "Home", "fa fa-book fa-5x", "panel panel-green");
                    //this.dashboardViewModel.paymentOverdueCountTile = new TileViewModel("Payments Overdue", 25, "Home", "fa fa-warning fa-5x", "panel panel-red");
                };
                AppComponent = __decorate([
                    core_1.Component({
                        selector: 'app',
                        templateUrl: "/partial/message"
                    }), 
                    __metadata('design:paramtypes', [])
                ], AppComponent);
                return AppComponent;
            }());
            exports_1("AppComponent", AppComponent);
        }
    }
});
//# sourceMappingURL=app.component.js.map