import {Component, Input, OnInit} from "angular2/core";
import { ITileViewModel } from "../customer/tilecomponent";

@Component({
    selector: "displaytemplate",
    templateUrl: "/partial/displaytemplate"
})
export class DisplayTemplateComponent implements OnInit {

    @Input()
    tile: {
        title: string,
        value: number,
        url: string,
        iconCssClass: string,
        colorCssClass: string
    };

    constructor() {

    }

    ngOnInit() {
    }
}