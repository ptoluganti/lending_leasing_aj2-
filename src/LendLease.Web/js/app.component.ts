import {Component, OnInit} from 'angular2/core';
import { ITileViewModel, IDashboardViewModel } from './customer/icustomer';


@Component({
    selector: 'app',
    templateUrl: "/partial/message"
    //template: '<h1>My First Angular 2 App</h1>'
})
export class AppComponent implements OnInit {
    message: string = "Dashboard";
    dashboardViewModel: IDashboardViewModel = null;
    constructor() {
        
    }

    ngOnInit() {
        this.dashboardViewModel.customerCountTile = {
            title: "Customers",
            value: 10,
            url: "Home",
            iconCssClass: "fa fa-users fa-5x",
            colorCssClass: "panel panel-primary"
        };
        this.dashboardViewModel.scheduledPaymentCountTile = {
            title: "Scheduled Payments",
            value: 100,
            url: "Home",
            iconCssClass: "fa fa-calendar fa-5x",
            colorCssClass: "panel panel-yellow"
        };
        this.dashboardViewModel.paymentRecievedCountTile = {
            title: "Payments Recieved",
            value: 75,
            url: "Home",
            iconCssClass: "fa fa-book fa-5x",
            colorCssClass: "panel panel-green"
        };
        this.dashboardViewModel.paymentOverdueCountTile = {
            title: "Payments Overdue",
            value: 25,
            url: "Home",
            iconCssClass: "fa fa-warning fa-5x",
            colorCssClass: "panel panel-red"
        };
    }
}