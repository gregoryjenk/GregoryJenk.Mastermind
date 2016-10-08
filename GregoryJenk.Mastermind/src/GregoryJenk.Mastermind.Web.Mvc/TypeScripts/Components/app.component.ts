import { Component } from "@angular/core";
import { Game } from "../Models/Games/game.model";

//TODO: Guess feedback rule where duplicates colours and wrong places.
//TODO: Point based scoring system.
//TODO: Five guess algorithm.

@Component({
    selector: ".app-component",
    templateUrl: "/app/templates/app.component.html"
})
export class AppComponent {
    private _colours: Colour[] = [];
    private _currentGame: Game;
    private _playedGames: Game[] = [];

    constructor() {
        //Cannot loop through const enum, so have to list them out.
        this._colours.push(Colour.Blue);
        this._colours.push(Colour.Green);
        this._colours.push(Colour.Orange);
        this._colours.push(Colour.Purple);
        this._colours.push(Colour.Red);
        this._colours.push(Colour.Yellow);
    }

    private startGame() {
        this._currentGame = new Game();
    }
}