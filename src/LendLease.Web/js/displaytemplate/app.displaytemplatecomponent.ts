import {Component, Input, OnInit} from "angular2/core";
import { ITileViewModel } from "../customer/tilecomponent";

@Component({
    selector: "displaytemplate",
    templateUrl: "/partial/displaytemplate"
})
export class DisplayTemplateComponent implements OnInit {

    @Input()
    tile: ITileViewModel;

    constructor() {

    }

    ngOnInit() {
    }
}