import { Component } from "@angular/core";
import { Game } from "../Models/Games/game.model";
import { PegCode } from "../Models/Pegs/peg-code.model";

//TODO: Guess feedback rule where duplicates colours and wrong places.
//TODO: Point based scoring system.
//TODO: Five guess algorithm.

@Component({
    selector: ".app-component",
    templateUrl: "/app/templates/app.component.html"
})
export class AppComponent {
    private _colours: PegCode[] = [];
    private _currentGame: Game;
    private _playedGames: Game[] = [];

    constructor() {
        //Cannot loop through const enum, so have to list them out.
        this._colours.push(new PegCode(Colour.Blue));
        this._colours.push(new PegCode(Colour.Green));
        this._colours.push(new PegCode(Colour.Orange));
        this._colours.push(new PegCode(Colour.Purple));
        this._colours.push(new PegCode(Colour.Red));
        this._colours.push(new PegCode(Colour.Yellow));
    }

    private createGame() {
        this._currentGame = new Game();
    }
}