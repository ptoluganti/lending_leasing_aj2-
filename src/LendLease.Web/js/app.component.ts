import {Component, OnInit} from "angular2/core";
import { ITileViewModel } from "./customer/tilecomponent";
import { DisplayTemplateComponent } from "./displaytemplate/app.displaytemplatecomponent";

@Component({
    selector: "app",
    templateUrl: "/partial/message",
    directives: [DisplayTemplateComponent]
})
export class AppComponent implements OnInit {
    message = "Dashboard";
    customerCountTile: any = {
        title: "Customers",
        value: 10,
        url: "Home",
        iconCssClass: "fa fa-users fa-5x",
        colorCssClass: "panel panel-primary"
    };
    scheduledPaymentCountTile: any = {
        title: "Scheduled Payments",
        value: 100,
        url: "Home",
        iconCssClass: "fa fa-calendar fa-5x",
        colorCssClass: "panel panel-yellow"
    };
    paymentRecievedCountTile: any = {
        title: "Payments Recieved",
        value: 75,
        url: "Home",
        iconCssClass: "fa fa-book fa-5x",
        colorCssClass: "panel panel-green"
    };
    paymentOverdueCountTile: any = {
        title: "Payments Overdue",
        value: 25,
        url: "Home",
        iconCssClass: "fa fa-warning fa-5x",
        colorCssClass: "panel panel-red"
    };

    constructor() {

    }

    ngOnInit() {
    }
}