﻿import { Component } from "@angular/core";
import { AppComponent } from "../app.component";

@Component({
    selector: "navigation-bar",
    templateUrl: "/app/templates/components/navigations/navigation-bar.component.html"
})
export class NavigationBarComponent {
    constructor(public parent: AppComponent) {
        
    }
}