//Import statements to tell Angular what modules to use.
import { Component } from "@angular/core";
//import { Game } from "../Models/Games/game.model";

//The component decorator describes the template/view with metadata.
@Component({
    selector: ".app-component",
    templateUrl: "/app/templates/app.component.html"
})
export class AppComponent {
    //The component class controls behaviour for the template/view.

    //game = new Game("Greg");

    //let colours = new string[ "", "", "", "", "", "" ];

    //TODO: Function to start a game.

    //TODO: Property for active game.
}

//TODO: Guess feedback rule where duplicates colours and wrong places.
//TODO: Point based scoring system.
//TODO: Five guess algorithm.