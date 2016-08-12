import {Component} from 'angular2/core';

@Component({
    selector: 'app',
    templateUrl: "/partial/message"
    //template: '<h1>My First Angular 2 App</h1>'
})
export class AppComponent {
    message: string = "Test message";

}